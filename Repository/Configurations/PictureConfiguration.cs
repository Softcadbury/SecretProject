namespace Repository.Configurations
{
    using Infrastructure.Configuration;
    using Repository.Models;

    /// <summary>
    /// Configuration for the model Picture
    /// </summary>
    public class PictureConfiguration : ConfigurationBase<Picture>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public PictureConfiguration()
        {
            Property(m => m.Content).IsRequired().HasMaxLength(LenghtLimits.UserNameMaxLenght);
            HasRequired<User>(m => m.User).WithOptional(m => m.Picture).Map(m => m.MapKey("PictureId"));

            Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Picture");
            });
        }
    }
}