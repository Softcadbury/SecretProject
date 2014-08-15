namespace Service.ViewModels.Account
{
    using Infrastructure.Configuration;
    using Resources;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Registration
    /// </summary>
    public class RegistrationViewModel
    {
        [Required(ErrorMessageResourceName = "Account_FieldRequiredError", ErrorMessageResourceType = typeof(Resource))]
        [StringLength(LenghtLimits.UserNameMaxLenght, MinimumLength = LenghtLimits.UserNameMinLenght, ErrorMessageResourceName = "Account_FieldMinimumLengthError", ErrorMessageResourceType = typeof(Resource))]
        [Display(Name = "Account_UserName", ResourceType = typeof(Resource))]
        public string UserName { get; set; }

        [Required(ErrorMessageResourceName = "Account_FieldRequiredError", ErrorMessageResourceType = typeof(Resource))]
        [EmailAddress(ErrorMessageResourceName = "Account_FieldValidationError", ErrorMessageResourceType = typeof(Resource), ErrorMessage = null)]
        [Display(Name = "Account_Email", ResourceType = typeof(Resource))]
        public string Email { get; set; }

        [Required(ErrorMessageResourceName = "Account_FieldRequiredError", ErrorMessageResourceType = typeof(Resource))]
        [StringLength(LenghtLimits.PasswordMaxLenght, MinimumLength = LenghtLimits.PasswordMinLenght, ErrorMessageResourceName = "Account_FieldMinimumLengthError", ErrorMessageResourceType = typeof(Resource))]
        [DataType(DataType.Password)]
        [Display(Name = "Account_Password", ResourceType = typeof(Resource))]
        public string Password { get; set; }

        [Compare("Password", ErrorMessageResourceName = "Account_PasswordMatchingError", ErrorMessageResourceType = typeof(Resource))]
        [DataType(DataType.Password)]
        [Display(Name = "Account_PasswordConfirmation", ResourceType = typeof(Resource))]
        public string ConfirmPassword { get; set; }
    }
}