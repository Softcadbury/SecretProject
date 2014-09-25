﻿namespace Service.ViewModels.ChatRoom
{
    using Infrastructure.BaseClasses;
    using Infrastructure.Configuration;
    using Resources;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// User
    /// </summary>
    public class ChatRoomViewModel : ViewModelBase
    {
        [Required(ErrorMessageResourceName = "Error_IsRequired", ErrorMessageResourceType = typeof(Resource))]
        [StringLength(LenghtLimits.ChatRoomTitleMaxLenght, MinimumLength = LenghtLimits.ChatRoomTitleMinLenght, ErrorMessageResourceName = "Error_BadLength", ErrorMessageResourceType = typeof(Resource))]
        [Display(Name = "Field_Title", ResourceType = typeof(Resource))]
        public string Title { get; set; }
    }
}