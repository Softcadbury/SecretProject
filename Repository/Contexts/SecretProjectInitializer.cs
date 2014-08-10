namespace Repository.Contexts
{
    using System.Collections.Generic;
    using System.Data.Entity;

    using Repository.Models;

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

            chatRooms.ForEach(s => context.ChatRooms.Add(s));

            context.SaveChanges();
        }
    }
}