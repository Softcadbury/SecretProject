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
        [Required(ErrorMessageResourceName = "Error_IsRequired", ErrorMessageResourceType = typeof(Resource))]
        [StringLength(LenghtLimits.UserNameMaxLenght, MinimumLength = LenghtLimits.UserNameMinLenght, ErrorMessageResourceName = "Error_BadLength", ErrorMessageResourceType = typeof(Resource))]
        [Display(Name = "Field_UserName", ResourceType = typeof(Resource))]
        public string UserName { get; set; }

        [Required(ErrorMessageResourceName = "Error_IsRequired", ErrorMessageResourceType = typeof(Resource))]
        [EmailAddress(ErrorMessageResourceName = "Error_NotValid", ErrorMessageResourceType = typeof(Resource), ErrorMessage = null)]
        [Display(Name = "Field_Email", ResourceType = typeof(Resource))]
        public string Email { get; set; }

        [Required(ErrorMessageResourceName = "Error_IsRequired", ErrorMessageResourceType = typeof(Resource))]
        [StringLength(LenghtLimits.PasswordMaxLenght, MinimumLength = LenghtLimits.PasswordMinLenght, ErrorMessageResourceName = "Error_BadLength", ErrorMessageResourceType = typeof(Resource))]
        [DataType(DataType.Password)]
        [Display(Name = "Field_Password", ResourceType = typeof(Resource))]
        public string Password { get; set; }

        [Compare("Password", ErrorMessageResourceName = "Error_PasswordMatching", ErrorMessageResourceType = typeof(Resource))]
        [DataType(DataType.Password)]
        [Display(Name = "Field_PasswordConfirmation", ResourceType = typeof(Resource))]
        public string ConfirmPassword { get; set; }
    }
}