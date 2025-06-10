using System.ComponentModel.DataAnnotations;

namespace ClickAcc.Models
{
    public class RegisterViewModel
    {
        public required string Picture { get; set; }

        public required string Signature { get; set; }

        //
        // Application Access
        //
        [Required, DataType(DataType.Text), Display(Name = "Log On ID")] // can add [Required] before DataType in case it's needed (i.e. [Required, DataType(DataType.Text)])
        public required string LogOnID { get; set; }

        [Required, MinLength(6), DataType(DataType.Password)]
        public required string Password { get; set; }

        [Required, Compare("Password"), DataType(DataType.Password), Display(Name = "Confirm Password")]
        public required string ConfirmPassword { get; set; }

        [Required, DataType(DataType.Text), Display(Name = "User Group")]
        public required string UserGroup { get; set; }

        [Required, DataType(DataType.Text), Display(Name = "User Level")]
        public required string UserLevel { get; set; }

        [Required, DataType(DataType.Text), Display(Name = "Access Level")]
        public required string AccessLevel { get; set; }

        [Required, DataType(DataType.Text), Display(Name = "System Administrator")]
        public required string SystemAdministrator { get; set; }

        [DataType(DataType.Text)]
        public required string Language { get; set; }

        [DataType(DataType.Text)]
        public required string Status { get; set; }

        [Required, DataType(DataType.Text), Display(Name = "Idle Time")]
        public required string IdleTime { get; set; } // Time before logout

        //
        // User/Staff Information
        //
        [Required, DataType(DataType.Text)]
        public required string Username { get; set; }

        [DataType(DataType.Text)]
        public string? Nickname { get; set; }

        [Required, DataType(DataType.Text)]
        public required string Position { get; set; }

        [Required, DataType(DataType.Text), Display(Name = "Report To")]
        public required string ReportTo { get; set; }

        [Required, DataType(DataType.Date), Display(Name = "Joining Date")]
        public required string JoiningDate { get; set; }

        [Required, DataType(DataType.Date), Display(Name = "Resigned Date")]
        public required string ResignedDate { get; set; }

        [Display(Name = "Sales Quota")]
        public bool SalesQuota { get; set; }

        [Required, DataType(DataType.MultilineText)]
        public required string Address { get; set; }

        [Required, DataType(DataType.Text)]
        public required string City { get; set; }

        [Required, DataType(DataType.Text)]
        public required string State { get; set; }

        [Required, DataType(DataType.Text)]
        public required string Country { get; set; }

        [Required, DataType(DataType.Text), Display(Name = "Zip Code")]
        public required string ZipCode { get; set; }

        [Required, DataType(DataType.Text), Display(Name = "ID Number")]
        public required string IDNumber { get; set; }

        [Display(Name = "Sales Agent")]
        public bool SalesAgent { get; set; }

        [Required, DataType(DataType.Date)]
        public required string Birthday { get; set; }

        [Required, DataType(DataType.Text)]
        public required string Nationality { get; set; }

        //
        // Contact Information
        //
        [EmailAddress]
        public required string Email { get; set; }

        [Required, DataType(DataType.Text)]
        public required string Pager { get; set; }

        [Required, DataType(DataType.PhoneNumber), Display(Name = "Phone Number")]
        public required string PhoneNumber { get; set; }
        
        [Required, DataType(DataType.PhoneNumber), Display(Name = "Resident Phone Number")]
        public required string ResidentPhoneNumber { get; set; }

        [Required, DataType(DataType.Text), Display(Name = "Office Extension")]
        public required string OfficeExt { get; set; }

        [Required, DataType(DataType.Text), Display(Name = "Contact Person")]
        public required string ContactPerson { get; set; }

        [Required, DataType(DataType.PhoneNumber), Display(Name = "Contact Person Phone Number")]
        public required string ContactPersonPhoneNumber { get; set; }

        //
        // Staff Evaluation
        //
        [Required, DataType(DataType.Date), Display(Name = "Last Evaluation Date")]
        public required string LastEvaluationDate { get; set; }

        [Required, DataType(DataType.Date), Display(Name = "Next Evaluation Date")]
        public required string NextEvaluationDate { get; set; }

        //
        // Notes
        //
        [DataType(DataType.MultilineText)]
        public string? Notes { get; set; }

        //
        // Others
        //
        public string? ReCaptchaSiteKey { get; set; }
    }
}
