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
        [Required(ErrorMessageResourceName = "Error_IsRequired", ErrorMessageResourceType = typeof(Resource))]
        [StringLength(LenghtLimits.UserNameMaxLenght, MinimumLength = LenghtLimits.UserNameMinLenght, ErrorMessageResourceName = "Error_BadLength", ErrorMessageResourceType = typeof(Resource))]
        [Display(Name = "Field_UserName", ResourceType = typeof(Resource))]
        public string UserName { get; set; }

        [Required(ErrorMessageResourceName = "Error_IsRequired", ErrorMessageResourceType = typeof(Resource))]
        [StringLength(LenghtLimits.EmailMaxLenght, MinimumLength = LenghtLimits.EmailMinLenght, ErrorMessageResourceName = "Error_BadLength", ErrorMessageResourceType = typeof(Resource))]
        [EmailAddress(ErrorMessageResourceName = "Error_NotValid", ErrorMessageResourceType = typeof(Resource), ErrorMessage = null)]
        [Display(Name = "Field_Email", ResourceType = typeof(Resource))]
        public string Email { get; set; }
    }
}