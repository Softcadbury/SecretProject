namespace Service.ViewModels.Account
{
    using Infrastructure.Configuration;
    using Resources;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Change password
    /// </summary>
    public class ChangePasswordViewModel
    {
        [Required(ErrorMessageResourceName = "Account_FieldRequiredError", ErrorMessageResourceType = typeof(Resource))]
        [StringLength(LenghtLimits.PasswordMaxLenght, MinimumLength = LenghtLimits.PasswordMinLenght, ErrorMessageResourceName = "Account_FieldMinimumLengthError", ErrorMessageResourceType = typeof(Resource))]
        [DataType(DataType.Password)]
        [Display(Name = "Account_PasswordNew", ResourceType = typeof(Resource))]
        public string NewPassword { get; set; }

        [Required(ErrorMessageResourceName = "Account_FieldRequiredError", ErrorMessageResourceType = typeof(Resource))]
        [StringLength(LenghtLimits.PasswordMaxLenght, MinimumLength = LenghtLimits.PasswordMinLenght, ErrorMessageResourceName = "Account_FieldMinimumLengthError", ErrorMessageResourceType = typeof(Resource))]
        [DataType(DataType.Password)]
        [Display(Name = "Account_PasswordActual", ResourceType = typeof(Resource))]
        public string ActualPassword { get; set; }

        [Compare("ActualPassword", ErrorMessageResourceName = "Account_PasswordMatchingError", ErrorMessageResourceType = typeof(Resource))]
        [DataType(DataType.Password)]
        [Display(Name = "Account_PasswordConfirmation", ResourceType = typeof(Resource))]
        public string ConfirmPassword { get; set; }
    }
}