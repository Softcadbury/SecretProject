namespace Service.ViewModels
{
    using Infrastructure.Configuration;
    using Resources;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Send contact email
    /// </summary>
    public class SendContactEmailViewModel
    {
        [Required(ErrorMessageResourceName = "Error_IsRequired", ErrorMessageResourceType = typeof(Resource))]
        [StringLength(LenghtLimits.EmailMessageMaxLenght, MinimumLength = LenghtLimits.EmailMessageMinLenght, ErrorMessageResourceName = "Error_BadLength", ErrorMessageResourceType = typeof(Resource))]
        [Display(Name = "Field_Message", ResourceType = typeof(Resource))]
        public string Message { get; set; }
    }
}