namespace Service.Services
{
    using System.Collections.Generic;
    using System.Web;
    using Infrastructure.BaseClasses;
    using Infrastructure.ServiceResponses;
    using Repository.Models;
    using Repository.Repositories;
    using Service.ViewModels.Account;
    using WebMatrix.WebData;

    /// <summary>
    /// User service
    /// </summary>
    public class UserService : BaseService<User, UserRepository>
    {
        private static readonly UserRepository UserRepository = new UserRepository();

        /// <summary>
        /// Constructor
        /// </summary>
        public UserService()
            : base(UserRepository)
        {
        }

        /// <summary>
        /// Get the current user
        /// </summary>
        public Response<User> GetCurrent()
        {
            string currentUserName = HttpContext.Current.User.Identity.Name;
            int currentUserId = WebSecurity.GetUserId(currentUserName);

            return BaseGet(currentUserId);
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
                return Response<User>.CreateError(ErrorCodes.Unauthorized);
            }

            // todo: fix update exception
            return BaseUpdate(userId, user);
        }

        /// <summary>
        /// Update the user's passeword
        /// </summary>
        public Response<Empty> UpdatePassword(int userId, ChangePasswordViewModel changePassword)
        {
            if (!IsCurrent(userId).Content)
            {
                return Response<Empty>.CreateError(ErrorCodes.Unauthorized);
            }

            // todo: update password
            return Response<Empty>.CreateSuccess();
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