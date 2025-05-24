using System.ComponentModel.DataAnnotations;

namespace ClickAcc.Models
{
    public class RegisterViewModel
    {
        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, MinLength(6), DataType(DataType.Password)]
        public string Password { get; set; }

        [Required, Compare("Password"), DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

        // ✅ Add this to pass the site key to Razor view
        public string ReCaptchaSiteKey { get; set; }
    }
}
