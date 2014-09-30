namespace Service.Services
{
    using Infrastructure.ServiceResponses;
    using Resources;
    using Service.ViewModels.Account;
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
        public Response<Empty> RegisterUser(RegistrationViewModel registration)
        {
            try
            {
                var propertyValues = new
                    {
                        Email = registration.Email,
                        CreationDate = DateTime.UtcNow,
                        ModificationDate = DateTime.UtcNow
                    };

                WebSecurity.CreateUserAndAccount(registration.UserName, registration.Password, propertyValues);
                WebSecurity.Login(registration.UserName, registration.Password);
                FormsAuthentication.SetAuthCookie(registration.UserName, true);

                return Response<Empty>.CreateSuccess();
            }
            catch
            {
                return Response<Empty>.CreateError(Resource.Error_CannotRegistered);
            }
        }

        /// <summary>
        /// Login a user
        /// </summary>
        public Response<Empty> LoginUser(LoginViewModel login)
        {
            if (WebSecurity.Login(login.UserName, login.Password, true))
            {
                FormsAuthentication.SetAuthCookie(login.UserName, true);

                return Response<Empty>.CreateSuccess();
            }
            else
            {
                return Response<Empty>.CreateError(Resource.Error_CannotLogin);
            }
        }
    }
}