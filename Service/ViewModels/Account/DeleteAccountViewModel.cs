namespace Service.ViewModels
{
    using Infrastructure.Configuration;
    using Resources;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// User
    /// </summary>
    public class DeleteAccountViewModel
    {
        [Required(ErrorMessageResourceName = "Account_FieldRequiredError", ErrorMessageResourceType = typeof(Resource))]
        [StringLength(LenghtLimits.PasswordMaxLenght, MinimumLength = LenghtLimits.PasswordMinLenght, ErrorMessageResourceName = "Account_FieldMinimumLengthError", ErrorMessageResourceType = typeof(Resource))]
        [DataType(DataType.Password)]
        [Display(Name = "Account_PasswordActual", ResourceType = typeof(Resource))]
        public string Password { get; set; }
    }
}