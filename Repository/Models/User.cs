namespace Repository.Models
{
    using Infrastructure.BaseClasses;
    using Infrastructure.Configuration;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// User
    /// </summary>
    public class User : ModelBase
    {
        [MaxLength(LenghtLimits.UserNameMaxLenght)]
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }

        public Picture Picture { get; set; }
    }
}