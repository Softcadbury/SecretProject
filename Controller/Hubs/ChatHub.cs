namespace Controller.Hubs
{
    using Microsoft.AspNet.SignalR;
    using Microsoft.AspNet.SignalR.Hubs;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Chat hub
    /// </summary>
    [HubName("chatHub")]
    public class ChatHub : Hub
    {
        private static readonly Dictionary<string, int> ChatRoomsParticipants;

        /// <summary>
        /// Static constructor
        /// </summary>
        static ChatHub()
        {
            ChatRoomsParticipants = new Dictionary<string, int>();
        }

        /// <summary>
        /// Called when a user disconnect
        /// </summary>
        public override Task OnDisconnected(bool stopCalled)
        {
            ChatRoomsParticipants.Remove(Context.User.Identity.Name);
            Clients.All.broadcastChatRoomsParticipantsUpdate(ChatRoomsParticipants.Values.GroupBy(v => v).ToDictionary(v => v.Key, v => v.Count()));

            return base.OnDisconnected(stopCalled);
        }

        /// <summary>
        /// Indicates users that the current user change of chat room
        /// </summary>
        public void ChatRoomsParticipantsUpdate(int newChatRoomId)
        {
            ChatRoomsParticipants[Context.User.Identity.Name] = newChatRoomId;
            Clients.All.broadcastChatRoomsParticipantsUpdate(ChatRoomsParticipants.Values.GroupBy(v => v).ToDictionary(v => v.Key, v => v.Count()));
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