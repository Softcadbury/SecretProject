namespace Service.Requests.User
{
    using Service.ViewModels.Account;

    /// <summary>
    /// This class represents the request to update the user's passeword
    /// </summary>
    public sealed class UpdatePasswordRequest
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public UpdatePasswordRequest(int userId, ChangePasswordViewModel changePassword)
        {
            UserId = userId;
            ChangePassword = changePassword;
        }

        public int UserId { get; private set; }
        public ChangePasswordViewModel ChangePassword { get; private set; }
    }
}