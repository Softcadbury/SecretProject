namespace Repository.Models
{
    using Infrastructure.BaseClasses;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// ChatRoom
    /// </summary>
    public class ChatRoom : ModelBase
    {
        [Required]
        public string Title { get; set; }
    }
}