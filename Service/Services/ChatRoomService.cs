namespace Service.Services
{
    using Infrastructure.BaseClasses;
    using Infrastructure.ServiceResponses;
    using Repository.Models;
    using Repository.Repositories;
    using Service.ViewModels.ChatRoom;
    using System.Collections.Generic;

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
            List<ChatRoomViewModel> chatRooms = BaseGetPage(pageIndex, pageSize);

            return Response<List<ChatRoomViewModel>>.CreateSuccess(chatRooms);
        }
    }
}