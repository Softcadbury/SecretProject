namespace Repository.Repositories
{
    using Infrastructure.BaseClasses;
    using Repository.Contexts;
    using Repository.Models;

    /// <summary>
    /// ChatRoom repository
    /// </summary>
    public class ChatRoomRepository : BaseRepository<ChatRoom>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public ChatRoomRepository()
            : base(new SecretProjectContext())
        {
        }
    }
}