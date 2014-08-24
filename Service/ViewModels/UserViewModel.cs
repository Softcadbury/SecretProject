namespace Service.ViewModels
{
    using Infrastructure.BaseClasses;
    using Infrastructure.Configuration;
    using Resources;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// User
    /// </summary>
    public class UserViewModel : ViewModelBase
    {
        [Required(ErrorMessageResourceName = "Account_FieldRequiredError", ErrorMessageResourceType = typeof(Resource))]
        [StringLength(LenghtLimits.UserNameMaxLenght, MinimumLength = LenghtLimits.UserNameMinLenght, ErrorMessageResourceName = "Account_FieldMinimumLengthError", ErrorMessageResourceType = typeof(Resource))]
        [Display(Name = "Account_UserName", ResourceType = typeof(Resource))]
        public string UserName { get; set; }

        [Required(ErrorMessageResourceName = "Account_FieldRequiredError", ErrorMessageResourceType = typeof(Resource))]
        [EmailAddress(ErrorMessageResourceName = "Account_FieldValidationError", ErrorMessageResourceType = typeof(Resource), ErrorMessage = null)]
        [Display(Name = "Account_Email", ResourceType = typeof(Resource))]
        public string Email { get; set; }
    }
}