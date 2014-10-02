namespace Service.Services
{
    using Infrastructure.BaseClasses;
    using Infrastructure.ServiceResponses;
    using Repository.Models;
    using Repository.Repositories;
    using Resources;
    using Service.ViewModels.Account;
    using Service.ViewModels.User;
    using System.Collections.Generic;
    using System.Web.Security;
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
            UserViewModel user = BaseGet(WebSecurity.CurrentUserId, u => u.Picture);

            if (user == null)
            {
                return Response<UserViewModel>.CreateError(Resource.Error_NotFound);
            }

            return Response<UserViewModel>.CreateSuccess(user);
        }

        /// <summary>
        /// Get a list of users
        /// </summary>
        public Response<List<UserViewModel>> GetPage(int pageIndex, int pageSize)
        {
            List<UserViewModel> users = BaseGetPage(pageIndex, pageSize);

            return Response<List<UserViewModel>>.CreateSuccess(users);
        }

        /// <summary>
        /// Update the current user
        /// </summary>
        public Response<UserViewModel> UpdateCurrent(UserViewModel user)
        {
            if (user.Id != WebSecurity.CurrentUserId)
            {
                return Response<UserViewModel>.CreateError(Resource.Error_Forbidden);
            }

            User existingUser = Repository.GetByPredicate(u => u.UserName == user.UserName && u.Id != user.Id);

            if (existingUser != null)
            {
                return Response<UserViewModel>.CreateError(Resource.Error_ConflictUserName);
            }

            UserViewModel userUpdated = BaseUpdate(user);
            WebSecurity.Logout();
            FormsAuthentication.SetAuthCookie(user.UserName, true);

            return Response<UserViewModel>.CreateSuccess(userUpdated);
        }

        /// <summary>
        /// Update the password of the current user
        /// </summary>
        public Response<Empty> UpdateCurrentPassword(UpdateCurrentUserPasswordViewModel updateCurrentUserPassword)
        {
            if (!WebSecurity.ChangePassword(WebSecurity.CurrentUserName, updateCurrentUserPassword.ActualPassword, updateCurrentUserPassword.NewPassword))
            {
                return Response<Empty>.CreateError(Resource.Error_Forbidden);
            }

            return Response<Empty>.CreateSuccess();
        }

        /// <summary>
        /// Remove the current user
        /// </summary>
        public Response<Empty> RemoveCurrent(RemoveCurrentUserViewModel removeCurrentUser)
        {
            if (WebSecurity.Login(WebSecurity.CurrentUserName, removeCurrentUser.ActualPassword))
            {
                Repository.RemoveCurrent();
                WebSecurity.Logout();

                return Response<Empty>.CreateSuccess();
            }
            else
            {
                return Response<Empty>.CreateError(Resource.Error_IncorrectPassword);
            }
        }
    }
}