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
        public void Send(string user, string message)
        {
            Clients.All.broadcastMessage(user, message);
        }
    }
}