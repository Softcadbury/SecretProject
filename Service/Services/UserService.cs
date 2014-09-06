namespace Service.Services
{
    using Infrastructure.BaseClasses;
    using Infrastructure.ServiceResponses;
    using Repository.Models;
    using Repository.Repositories;
    using Service.ViewModels;
    using Service.ViewModels.Account;
    using System.Collections.Generic;
    using System.Linq;
    using WebMatrix.WebData;

    /// <summary>
    /// User service
    /// </summary>
    public class UserService : BaseService<User, UserRepository>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public UserService()
            : base(new UserRepository())
        {
        }

        /// <summary>
        /// Get the current user
        /// </summary>
        public Response<User> GetCurrent()
        {
            return BaseGet(WebSecurity.CurrentUserId);
        }

        /// <summary>
        /// Get a list of users
        /// </summary>
        public Response<List<User>> GetPage(int pageIndex, int pageSize)
        {
            return BaseGetPage(pageIndex, pageSize);
        }

        /// <summary>
        /// Update the current user
        /// </summary>
        public Response<User> UpdateCurrent(User user)
        {
            if (user.Id != WebSecurity.CurrentUserId)
            {
                return Response<User>.CreateError(ErrorCodes.Forbidden);
            }

            User existingUser = Repository.GetByPredicate(u => u.UserName == user.UserName && u.Id != user.Id).FirstOrDefault();

            if (existingUser != null)
            {
                return Response<User>.CreateError(ErrorCodes.Conflict);
            }

            return BaseUpdate(user);
        }

        /// <summary>
        /// Update the password of the current user
        /// </summary>
        public Response<Empty> UpdatePassword(int userId, ChangePasswordViewModel changePassword)
        {
            if (userId != WebSecurity.CurrentUserId)
            {
                return Response<Empty>.CreateError(ErrorCodes.Forbidden);
            }

            if (!WebSecurity.ChangePassword(WebSecurity.CurrentUserName, changePassword.ActualPassword, changePassword.NewPassword))
            {
                return Response<Empty>.CreateError(ErrorCodes.Forbidden);
            }

            return Response<Empty>.CreateSuccess();
        }

        /// <summary>
        /// Remove the current user
        /// </summary>
        public Response<Empty> RemoveCurrent(DeleteAccountViewModel deleteAccount)
        {
            // Todo: check password
            if (true)
            {
                return Response<Empty>.CreateError(ErrorCodes.Forbidden);
            }
            else
            {
                return BaseRemove(WebSecurity.CurrentUserId);
            }
        }
    }
}