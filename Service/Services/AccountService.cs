namespace Service.Services
{
    using Infrastructure.Services.Responses;
    using Resources;
    using Service.Account.Requests;
    using System;
    using System.Web.Security;
    using WebMatrix.WebData;

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
            try
            {
                WebSecurity.CreateUserAndAccount(
                    request.Model.UserName, request.Model.Password,
                    propertyValues: new
                    {
                        CreationDate = DateTime.UtcNow,
                        ModificationDate = DateTime.UtcNow
                    });

                WebSecurity.Login(request.Model.UserName, request.Model.Password);
                FormsAuthentication.SetAuthCookie(request.Model.UserName, createPersistentCookie: false);

                return Response<Empty>.CreateSuccess();
            }
            catch
            {
                return Response<Empty>.CreateError(ErrorCodes.Conflict, Resource.Account_CannotRegistered);
            }
        }

        /// <summary>
        /// Connect a user
        /// </summary>
        public Response<Empty> ConnectUser(ConnectUserRequest request)
        {
            if (WebSecurity.Login(request.Model.UserName, request.Model.Password, persistCookie: true))
            {
                FormsAuthentication.SetAuthCookie(request.Model.UserName, createPersistentCookie: true);

                return Response<Empty>.CreateSuccess();
            }
            else
            {
                return Response<Empty>.CreateError(ErrorCodes.NotFound, Resource.Account_CannotConnect);
            }
        }
    }
}