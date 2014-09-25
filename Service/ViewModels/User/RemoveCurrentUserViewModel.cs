namespace Service.ViewModels.Account
{
    using Infrastructure.Configurations;
    using Resources;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Remove current user
    /// </summary>
    public class RemoveCurrentUserViewModel
    {
        [Required(ErrorMessageResourceName = "Error_IsRequired", ErrorMessageResourceType = typeof(Resource))]
        [StringLength(LenghtLimits.PasswordMaxLenght, MinimumLength = LenghtLimits.PasswordMinLenght, ErrorMessageResourceName = "Error_BadLength", ErrorMessageResourceType = typeof(Resource))]
        [DataType(DataType.Password)]
        [Display(Name = "Field_PasswordActual", ResourceType = typeof(Resource))]
        public string Password { get; set; }
    }
}