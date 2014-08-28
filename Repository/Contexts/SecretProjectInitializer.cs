namespace Repository.Contexts
{
    using Repository.Models;
    using Repository.Repositories;
    using System.Collections.Generic;
    using System.Data.Entity;

    /// <summary>
    /// Initializer for the application database
    /// </summary>
    public class SecretProjectInitializer : DropCreateDatabaseIfModelChanges<SecretProjectContext>
    {
        /// <summary>
        /// Initialize the database when created
        /// </summary>
        protected override void Seed(SecretProjectContext context)
        {
            // Initialize chat rooms
            var chatRooms = new List<ChatRoom>
            {
                new ChatRoom { Title = "Video Games" },
                new ChatRoom { Title = "Sport" },
                new ChatRoom { Title = "Cinema" },
                new ChatRoom { Title = "Dating" }
            };

            var chatRoomRepository = new ChatRoomRepository();
            chatRooms.ForEach(c => chatRoomRepository.Add(c));
            chatRoomRepository.SaveChanges();
        }
    }
}