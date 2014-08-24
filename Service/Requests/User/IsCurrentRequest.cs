namespace Service.Requests.User
{
    /// <summary>
    /// This class represents the request to know if the user id is the id of the current user
    /// </summary>
    public sealed class IsCurrentRequest
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public IsCurrentRequest(int userId)
        {
            UserId = userId;
        }

        public int UserId { get; private set; }
    }
}