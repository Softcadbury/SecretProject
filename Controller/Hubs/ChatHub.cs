namespace Controller.Hubs
{
    using Microsoft.AspNet.SignalR;
    using Microsoft.AspNet.SignalR.Hubs;

    /// <summary>
    /// Chat hub
    /// </summary>
    [HubName("chatHub")]
    public class ChatHub : Hub
    {
        /// <summary>
        /// Send a message to users in the specified chat room
        /// </summary>
        public void SendMessageToChatRoom(int chatRoomId, string user, string message)
        {
            Clients.All.broadcastMessageToChatRoom(user, message);
        }
    }
}