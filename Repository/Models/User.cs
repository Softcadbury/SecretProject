namespace Repository.Models
{
    using System.ComponentModel.DataAnnotations;

    using Infrastructure.BaseClasses;
    using Infrastructure.Configuration;

    /// <summary>
    /// User
    /// </summary>
    public class User : BaseModel
    {
        [MaxLength(LenghtLimits.UserNameMaxLenght)]
        public string UserName { get; set; }
    }
}