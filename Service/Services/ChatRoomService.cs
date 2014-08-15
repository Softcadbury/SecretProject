namespace Service.Services
{
    using Infrastructure.BaseClasses;
    using Infrastructure.Services.Requests;
    using Infrastructure.Services.Responses;
    using Repository.Models;
    using Repository.Repositories;
    using System.Collections.Generic;

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
        public new Response<List<ChatRoom>> GetPage(GetPageRequest request)
        {
            return base.GetPage(request);
        }
    }
}