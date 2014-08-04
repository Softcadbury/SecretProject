namespace Controller.ViewModels.Account
{
    using System.ComponentModel.DataAnnotations;

    using Resources;

    /// <summary>
    /// Registration
    /// </summary>
    public class RegistrationViewModel
    {
        [Required(ErrorMessageResourceName = "Account_RequiredError", ErrorMessageResourceType = typeof(Resource))]
        [EmailAddress]
        [Display(Name = "Account_Email", ResourceType = typeof(Resource))]
        public string Email { get; set; }

        [Required(ErrorMessageResourceName = "Account_RequiredError", ErrorMessageResourceType = typeof(Resource))]
        [StringLength(100, MinimumLength = 6, ErrorMessageResourceName = "Account_MinimumLengthError", ErrorMessageResourceType = typeof(Resource))]
        [DataType(DataType.Password)]
        [Display(Name = "Account_Password", ResourceType = typeof(Resource))]
        public string Password { get; set; }

        [Compare("Password", ErrorMessageResourceName = "Account_PasswordMatchingError", ErrorMessageResourceType = typeof(Resource))]
        [DataType(DataType.Password)]
        [Display(Name = "Account_ConfirmPassword", ResourceType = typeof(Resource))]
        public string ConfirmPassword { get; set; }
    }
}