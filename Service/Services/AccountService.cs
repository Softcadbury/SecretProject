namespace Service.Services
{
    using System;
    using System.Web.Security;
    using Infrastructure.ServiceResponses;
    using Resources;
    using Service.ViewModels.Account;
    using WebMatrix.WebData;

    /// <summary>
    /// Account service
    /// </summary>
    public class AccountService
    {
        /// <summary>
        /// Register a user
        /// </summary>
        public Response<Empty> RegisterUser(RegistrationViewModel model)
        {
            try
            {
                WebSecurity.CreateUserAndAccount(
                    model.UserName, model.Password,
                    propertyValues: new
                    {
                        Email = model.Email,
                        CreationDate = DateTime.UtcNow,
                        ModificationDate = DateTime.UtcNow
                    });

                WebSecurity.Login(model.UserName, model.Password);
                FormsAuthentication.SetAuthCookie(model.UserName, createPersistentCookie: false);

                return Response<Empty>.CreateSuccess();
            }
            catch
            {
                return Response<Empty>.CreateError(ErrorCodes.Conflict, Resource.Account_CannotRegistered);
            }
        }

        /// <summary>
        /// Login a user
        /// </summary>
        public Response<Empty> LoginUser(LoginViewModel model)
        {
            if (WebSecurity.Login(model.UserName, model.Password, persistCookie: true))
            {
                FormsAuthentication.SetAuthCookie(model.UserName, createPersistentCookie: true);

                return Response<Empty>.CreateSuccess();
            }
            else
            {
                return Response<Empty>.CreateError(ErrorCodes.NotFound, Resource.Account_CannotLogin);
            }
        }
    }
}