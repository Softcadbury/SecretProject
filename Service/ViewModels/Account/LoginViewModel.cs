﻿namespace Service.ViewModels.Account
{
    using Infrastructure.Configurations;
    using Resources;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Login
    /// </summary>
    public class LoginViewModel
    {
        [Required(ErrorMessageResourceName = "Error_IsRequired", ErrorMessageResourceType = typeof(Resource))]
        [StringLength(LenghtLimits.UserNameMaxLenght, MinimumLength = LenghtLimits.UserNameMinLenght, ErrorMessageResourceName = "Error_BadLength", ErrorMessageResourceType = typeof(Resource))]
        [Display(Name = "Field_UserName", ResourceType = typeof(Resource))]
        public string UserName { get; set; }

        [Required(ErrorMessageResourceName = "Error_IsRequired", ErrorMessageResourceType = typeof(Resource))]
        [StringLength(LenghtLimits.PasswordMaxLenght, MinimumLength = LenghtLimits.PasswordMinLenght, ErrorMessageResourceName = "Error_BadLength", ErrorMessageResourceType = typeof(Resource))]
        [DataType(DataType.Password)]
        [Display(Name = "Field_Password", ResourceType = typeof(Resource))]
        public string Password { get; set; }
    }
}