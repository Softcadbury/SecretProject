namespace Controller.Hubs
{
    using Microsoft.AspNet.SignalR;
    using Microsoft.AspNet.SignalR.Hubs;
    using Repository.Models;
    using Service.Services;
    using System.Collections.Generic;

    /// <summary>
    /// Chat hub
    /// </summary>
    [HubName("chatHub")]
    public class ChatHub : Hub
    {
        private static readonly Dictionary<int, int> chatRoomsParticipants;

        /// <summary>
        /// Static constructor
        /// </summary>
        static ChatHub()
        {
            var chatRoomService = new ChatRoomService();
            List<ChatRoom> chatRooms = chatRoomService.GetPage(1, 20).Content;

            chatRoomsParticipants = new Dictionary<int, int>();
            chatRooms.ForEach(cr => chatRoomsParticipants.Add(cr.Id, 0));
        }

        /// <summary>
        /// Indicates users that the current user change of chat room
        /// </summary>
        public void ChatRoomsParticipantsUpdate(int oldChatRoomId, int newChatRoomId)
        {
            chatRoomsParticipants[oldChatRoomId] = chatRoomsParticipants[oldChatRoomId] > 0 ? chatRoomsParticipants[oldChatRoomId] - 1 : 0;
            chatRoomsParticipants[newChatRoomId] = chatRoomsParticipants[newChatRoomId] + 1;

            Clients.All.broadcastChatRoomsParticipantsUpdate(chatRoomsParticipants);
        }

        /// <summary>
        /// Send a message to users in the specified chat room
        /// </summary>
        public void SendMessageToChatRoom(int chatRoomId, string user, string message)
        {
            Clients.All.broadcastMessageToChatRoom(user, message);
        }
    }
}