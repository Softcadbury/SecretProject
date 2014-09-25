namespace Service.Services
{
    using Infrastructure.BaseClasses;
    using Infrastructure.ServiceResponses;
    using Repository.Models;
    using Repository.Repositories;
    using System.Collections.Generic;

    using Service.ViewModels.ChatRoom;

    /// <summary>
    /// ChatRoom service
    /// </summary>
    public class ChatRoomService : BaseService<ChatRoom, ChatRoomViewModel, ChatRoomRepository>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public ChatRoomService()
            : base(new ChatRoomRepository())
        {
        }

        /// <summary>
        /// Get a list of chat rooms
        /// </summary>
        public Response<List<ChatRoomViewModel>> GetPage(int pageIndex, int pageSize)
        {
            return BaseGetPage(pageIndex, pageSize);
        }
    }
}