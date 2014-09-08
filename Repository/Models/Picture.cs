namespace Repository.Models
{
    using Infrastructure.BaseClasses;

    /// <summary>
    /// Picture
    /// </summary>
    public class Picture : ModelBase
    {
        public User User { get; set; }
        public byte[] Content { get; set; }
    }
}