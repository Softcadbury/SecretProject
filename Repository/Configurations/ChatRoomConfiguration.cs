namespace Repository.Configurations
{
    using Repository.Models;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;

    /// <summary>
    /// Configuration for the model ChatRoom
    /// </summary>
    public class ChatRoomConfiguration : EntityTypeConfiguration<ChatRoom>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public ChatRoomConfiguration()
        {
            Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("ChatRoom");
            });
        }
    }
}