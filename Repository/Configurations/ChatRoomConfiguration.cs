namespace Repository.Configurations
{
    using Infrastructure.BaseClasses;
    using Infrastructure.Configurations;
    using Repository.Models;

    /// <summary>
    /// Configuration for the model ChatRoom
    /// </summary>
    public class ChatRoomConfiguration : ConfigurationBase<ChatRoom>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public ChatRoomConfiguration()
        {
            Property(m => m.Title).IsRequired().HasMaxLength(LenghtLimits.ChatRoomTitleMaxLenght);

            Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("ChatRoom");
            });
        }
    }
}