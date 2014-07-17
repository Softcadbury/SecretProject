namespace Controller.ApiControllers
{
    using System.Collections.Generic;
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

        // GET: /api/users?pageIndex=0&pageSize=20
        [HttpGet]
        [Route("")]
        public IHttpActionResult Get([FromUri] int pageIndex, [FromUri] int pageSize)
        {
            var request = new GetAllRequest(pageIndex, pageSize);
            Response<List<User>> response = userService.GetAll(request);

            return RenderResponse(response);
        }

        // POST: /api/users
        [HttpPost]
        [Route("")]
        public IHttpActionResult Add([FromBody] User user)
        {
            var request = new AddRequest<User>(user);
            Response<User> response = userService.Add(request);

            return RenderResponse(response);
        }
    }
}