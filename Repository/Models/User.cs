namespace Repository.Models
{
    using System.ComponentModel.DataAnnotations;

    using Infrastructure.BaseClasses;

    /// <summary>
    /// User
    /// </summary>
    public class User : BaseModel
    {
        [MaxLength(25)]
        public string Name { get; set; }
    }
}