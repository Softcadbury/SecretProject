namespace Service.Services
{
    using Infrastructure.BaseClasses;
    using Infrastructure.ServiceResponses;
    using Repository.Models;
    using Repository.Repositories;
    using Service.ViewModels.Account;
    using Service.ViewModels.User;
    using System.Collections.Generic;
    using WebMatrix.WebData;

    /// <summary>
    /// User service
    /// </summary>
    public class UserService : BaseService<User, UserViewModel, UserRepository>
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
        public Response<UserViewModel> GetCurrent()
        {
            return BaseGet(WebSecurity.CurrentUserId, u => u.Picture);
        }

        /// <summary>
        /// Get a list of users
        /// </summary>
        public Response<List<UserViewModel>> GetPage(int pageIndex, int pageSize)
        {
            return BaseGetPage(pageIndex, pageSize);
        }

        /// <summary>
        /// Update the current user
        /// </summary>
        public Response<UserViewModel> UpdateCurrent(UserViewModel user)
        {
            if (user.Id != WebSecurity.CurrentUserId)
            {
                return Response<UserViewModel>.CreateError(ErrorCodes.Forbidden);
            }

            User existingUser = Repository.GetByPredicate(u => u.UserName == user.UserName && u.Id != user.Id);

            if (existingUser != null)
            {
                return Response<UserViewModel>.CreateError(ErrorCodes.Conflict);
            }

            return BaseUpdate(user);
        }

        /// <summary>
        /// Update the password of the current user
        /// </summary>
        public Response<Empty> UpdateCurrentPassword(UpdateCurrentUserPasswordViewModel updateCurrentUserPassword)
        {
            if (!WebSecurity.ChangePassword(WebSecurity.CurrentUserName, updateCurrentUserPassword.ActualPassword, updateCurrentUserPassword.NewPassword))
            {
                return Response<Empty>.CreateError(ErrorCodes.Forbidden);
            }

            return Response<Empty>.CreateSuccess();
        }

        /// <summary>
        /// Remove the current user
        /// </summary>
        public Response<Empty> RemoveCurrent(RemoveCurrentUserViewModel removeCurrentUser)
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