namespace Service.Account.Requests
{
    using Service.ViewModels.Account;

    /// <summary>
    /// This class represents the request to register a user
    /// </summary>
    public sealed class RegisterUserRequest
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public RegisterUserRequest(RegistrationViewModel model)
        {
            Model = model;
        }

        public RegistrationViewModel Model { get; private set; }
    }
}