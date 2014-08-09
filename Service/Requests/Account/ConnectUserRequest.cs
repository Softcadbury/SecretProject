namespace Service.Account.Requests
{
    using Service.ViewModels.Account;

    /// <summary>
    /// This class represents the request to connect a user
    /// </summary>
    public sealed class ConnectUserRequest
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public ConnectUserRequest(ConnectionViewModel model)
        {
            Model = model;
        }

        public ConnectionViewModel Model { get; private set; }
    }
}