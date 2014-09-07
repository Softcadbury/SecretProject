namespace Repository.Models
{
    using Infrastructure.BaseClasses;
    using Infrastructure.Configuration;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Picture
    /// </summary>
    public class Picture : ModelBase
    {
        [MaxLength(LenghtLimits.UserNameMaxLenght)]
        [Required]
        public byte[] Content { get; set; }
    }
}