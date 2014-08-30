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
    using System.Web;
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
        /// Update a user
        /// </summary>
        public Response<User> Update(int userId, User user)
        {
            if (!IsCurrent(userId).Content)
            {
                return Response<User>.CreateError(ErrorCodes.Forbidden);
            }

            User existingUser = Repository.GetByPredicate(u => u.UserName == user.UserName && u.Id != user.Id).FirstOrDefault();

            if (existingUser != null)
            {
                return Response<User>.CreateError(ErrorCodes.Conflict);
            }

            return BaseUpdate(userId, user);
        }

        /// <summary>
        /// Update the user's passeword
        /// </summary>
        public Response<Empty> UpdatePassword(int userId, ChangePasswordViewModel changePassword)
        {
            if (!IsCurrent(userId).Content)
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

        /// <summary>
        /// Indicate if a the user id is the id of the current user
        /// </summary>
        public Response<bool> IsCurrent(int userId)
        {
            string currentUserName = HttpContext.Current.User.Identity.Name;
            int currentUserId = WebSecurity.GetUserId(currentUserName);

            return Response<bool>.CreateSuccess(userId == currentUserId);
        }
    }
}