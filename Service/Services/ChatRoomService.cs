namespace Service.Services
{
    using System.Collections.Generic;
    using Infrastructure.BaseClasses;
    using Infrastructure.ServiceResponses;
    using Repository.Models;
    using Repository.Repositories;

    /// <summary>
    /// ChatRoom service
    /// </summary>
    public class ChatRoomService : BaseService<ChatRoom, ChatRoomRepository>
    {
        private static readonly ChatRoomRepository ChatRoomRepository = new ChatRoomRepository();

        /// <summary>
        /// Constructor
        /// </summary>
        public ChatRoomService()
            : base(ChatRoomRepository)
        {
        }

        /// <summary>
        /// Get a list of chat rooms
        /// </summary>
        public Response<List<ChatRoom>> GetPage(int pageIndex, int pageSize)
        {
            return BaseGetPage(pageIndex, pageSize);
        }
    }
}