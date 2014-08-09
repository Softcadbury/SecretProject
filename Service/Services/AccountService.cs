namespace Service.Services
{
    using Infrastructure.Services.Responses;
    using Resources;
    using Service.Account.Requests;

    /// <summary>
    /// Account service
    /// </summary>
    public class AccountService
    {
        /// <summary>
        /// Register a user
        /// </summary>
        public Response<Empty> RegisterUser(RegisterUserRequest request)
        {
            return Response<Empty>.CreateError(ErrorCodes.Conflict, Resource.Account_CannotRegistered);
        }

        /// <summary>
        /// Connect a user
        /// </summary>
        public Response<Empty> ConnectUser(ConnectUserRequest request)
        {
            return Response<Empty>.CreateError(ErrorCodes.NotFound, Resource.Account_CannotConnect);
        }
    }
}