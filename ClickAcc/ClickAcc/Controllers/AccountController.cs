using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ClickAcc.Configuration;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using ClickAcc.Models;

namespace ClickAcc.Controllers
{
    public class AccountController : Controller
    {
        private readonly ReCaptchaSettings _captchaSettings;
        private readonly IHttpClientFactory _httpClientFactory;

        public AccountController(IOptions<ReCaptchaSettings> captchaSettings, IHttpClientFactory httpClientFactory)
        {
            _captchaSettings = captchaSettings.Value;
            _httpClientFactory = httpClientFactory;
        }

        // ===== LOGIN =====
        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Email == "test@test.com" && model.Password == "password")
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Invalid login credentials.");
            }
            return View(model);
        }

        // ===== REGISTER =====
        [HttpGet]
        public IActionResult Register()
        {
            var model = new RegisterViewModel
            {
                ReCaptchaSiteKey = _captchaSettings.SiteKey
            };
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            var captchaResponse = Request.Form["g-recaptcha-response"];
            var isCaptchaValid = await VerifyCaptchaAsync(captchaResponse);

            if (!isCaptchaValid)
            {
                ModelState.AddModelError("", "Captcha validation failed. Please try again.");
            }

            if (ModelState.IsValid)
            {
                // TODO: Save user to DB
                return RedirectToAction("Login");
            }

            // ✅ Re-pass SiteKey to redisplay form correctly after failed POST
            model.ReCaptchaSiteKey = _captchaSettings.SiteKey;
            return View(model);
        }

        private async Task<bool> VerifyCaptchaAsync(string captchaResponse)
        {
            var client = _httpClientFactory.CreateClient();
            var result = await client.PostAsync(
                $"https://www.google.com/recaptcha/api/siteverify?secret={_captchaSettings.SecretKey}&response={captchaResponse}",
                null);

            var json = await result.Content.ReadAsStringAsync();
            using var doc = JsonDocument.Parse(json);
            return doc.RootElement.GetProperty("success").GetBoolean();
        }
    }
}
