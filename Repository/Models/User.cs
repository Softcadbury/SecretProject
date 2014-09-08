namespace Repository.Models
{
    using Infrastructure.BaseClasses;

    /// <summary>
    /// User
    /// </summary>
    public class User : ModelBase
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public Picture Picture { get; set; }
    }
}