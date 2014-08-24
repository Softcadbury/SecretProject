namespace Service.Services
{
    using Infrastructure.BaseClasses;
    using Infrastructure.Services.Requests;
    using Infrastructure.Services.Responses;
    using Repository.Models;
    using Repository.Repositories;
    using Service.Requests.User;
    using System.Collections.Generic;
    using System.Web;
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
            var request = new GetRequest(currentUserId);

            return Get(request);
        }

        /// <summary>
        /// Get a list of users
        /// </summary>
        public new Response<List<User>> GetPage(GetPageRequest request)
        {
            return base.GetPage(request);
        }

        /// <summary>
        /// Update a user
        /// </summary>
        public new Response<User> Update(UpdateRequest<User> request)
        {
            var isCurrentRequest = new IsCurrentRequest(request.Id);
            if (IsCurrent(isCurrentRequest).Content)
            {
                return Response<User>.CreateError(ErrorCodes.Unauthorized);
            }

            // todo: fix update exception
            return base.Update(request);
        }

        /// <summary>
        /// Update the user's passeword
        /// </summary>
        public Response<Empty> UpdatePassword(UpdatePasswordRequest request)
        {
            var isCurrentRequest = new IsCurrentRequest(request.UserId);
            if (IsCurrent(isCurrentRequest).Content)
            {
                return Response<Empty>.CreateError(ErrorCodes.Unauthorized);
            }

            // todo: update password
            return Response<Empty>.CreateSuccess();
        }

        /// <summary>
        /// Indicate if a the user id is the id of the current user
        /// </summary>
        public Response<bool> IsCurrent(IsCurrentRequest request)
        {
            string currentUserName = HttpContext.Current.User.Identity.Name;
            int currentUserId = WebSecurity.GetUserId(currentUserName);

            return Response<bool>.CreateSuccess(request.UserId == currentUserId);
        }
    }
}