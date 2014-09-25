namespace Repository.Configurations
{
    using Infrastructure.BaseClasses;
    using Infrastructure.Configurations;
    using Repository.Models;

    /// <summary>
    /// Configuration for the model User
    /// </summary>
    public class UserConfiguration : ConfigurationBase<User>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public UserConfiguration()
        {
            Property(m => m.UserName).IsRequired().HasMaxLength(LenghtLimits.UserNameMaxLenght);
            Property(m => m.Email).IsRequired().HasMaxLength(LenghtLimits.EmailMaxLenght);
            HasOptional(m => m.Picture).WithRequired(m => m.User).Map(m => m.MapKey("UserId"));

            Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("User");
            });
        }
    }
}