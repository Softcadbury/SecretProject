namespace Service.Account.Requests
{
    using Service.ViewModels.Account;

    /// <summary>
    /// This class represents the request to login a user
    /// </summary>
    public sealed class LoginUserRequest
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public LoginUserRequest(LoginViewModel model)
        {
            Model = model;
        }

        public LoginViewModel Model { get; private set; }
    }
}