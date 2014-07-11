namespace Controller.ApiControllers
{
    using System.Web.Http;

    using Infrastructure.BaseClasses;
    using Infrastructure.Messaging.Requests;
    using Infrastructure.Messaging.Responses;

    using Repository.Models;

    using Service.Services;

    /// <summary>
    /// User controller
    /// </summary>
    [RoutePrefix("api/users")]
    public class UserController : BaseApiController
    {
        private readonly UserService userService;

        /// <summary>
        /// Constructor
        /// </summary>
        public UserController()
        {
            userService = new UserService();
        }

        // GET: /api/users/1
        [HttpGet]
        [Route("{id:long}")]
        public IHttpActionResult Get(long id)
        {
            var request = new GetRequest(id);
            Response<User> response = userService.Get(request);

            return RenderResponse(response);
        }
    }
}