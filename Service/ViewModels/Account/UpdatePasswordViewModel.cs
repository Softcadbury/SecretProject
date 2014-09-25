namespace Service.ViewModels.Account
{
    using Infrastructure.Configurations;
    using Resources;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Change password
    /// </summary>
    public class UpdatePasswordViewModel
    {
        [Required(ErrorMessageResourceName = "Error_IsRequired", ErrorMessageResourceType = typeof(Resource))]
        [StringLength(LenghtLimits.PasswordMaxLenght, MinimumLength = LenghtLimits.PasswordMinLenght, ErrorMessageResourceName = "Error_BadLength", ErrorMessageResourceType = typeof(Resource))]
        [DataType(DataType.Password)]
        [Display(Name = "Field_PasswordActual", ResourceType = typeof(Resource))]
        public string ActualPassword { get; set; }

        [Required(ErrorMessageResourceName = "Error_IsRequired", ErrorMessageResourceType = typeof(Resource))]
        [StringLength(LenghtLimits.PasswordMaxLenght, MinimumLength = LenghtLimits.PasswordMinLenght, ErrorMessageResourceName = "Error_BadLength", ErrorMessageResourceType = typeof(Resource))]
        [DataType(DataType.Password)]
        [Display(Name = "Field_PasswordNew", ResourceType = typeof(Resource))]
        public string NewPassword { get; set; }

        [Compare("NewPassword", ErrorMessageResourceName = "Error_PasswordMatching", ErrorMessageResourceType = typeof(Resource))]
        [DataType(DataType.Password)]
        [Display(Name = "Field_PasswordConfirmation", ResourceType = typeof(Resource))]
        public string ConfirmPassword { get; set; }
    }
}