namespace Repository.Configurations
{
    using Infrastructure.BaseClasses;
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
            Property(m => m.Content).IsRequired().HasMaxLength(LenghtLimits.PictureMaxLenght);
            HasRequired(m => m.User).WithOptional(m => m.Picture).Map(m => m.MapKey("PictureId"));

            Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Picture");
            });
        }
    }
}