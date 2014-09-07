namespace Repository.Configurations
{
    using Repository.Models;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;

    /// <summary>
    /// Configuration for the model Picture
    /// </summary>
    public class PictureConfiguration : EntityTypeConfiguration<Picture>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public PictureConfiguration()
        {
            Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Picture");
            });
        }
    }
}