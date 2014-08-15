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
        public string UserName { get; set; }

        public string Email { get; set; }
    }
}