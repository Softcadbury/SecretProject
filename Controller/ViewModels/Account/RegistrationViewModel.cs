namespace Controller.ViewModels.Account
{
    using System.ComponentModel.DataAnnotations;

    using Resources;

    /// <summary>
    /// Registration
    /// </summary>
    public class RegistrationViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Account_Email", ResourceType = typeof(Resource))]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Account_Password", ResourceType = typeof(Resource))]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Account_ConfirmPassword", ResourceType = typeof(Resource))]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}