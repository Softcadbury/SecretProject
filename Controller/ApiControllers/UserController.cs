namespace Controller.ApiControllers
{
    using Infrastructure.BaseClasses;
    using Infrastructure.Messaging.Requests;
    using Infrastructure.Messaging.Responses;
    using Repository.Models;
    using Service.Services;
    using System.Collections.Generic;
    using System.Web.Http;

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
        [Route("{id:int}")]
        public IHttpActionResult Get(int id)
        {
            var request = new GetRequest(id);
            Response<User> response = userService.Get(request);

            return RenderResponse(response);
        }

        // GET: /api/users?pageIndex=0
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAll([FromUri] int pageIndex)
        {
            var request = new GetAllRequest(pageIndex, 20);
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

        // PUT: /api/users/1
        [HttpPut]
        [Route("{id:int}")]
        public IHttpActionResult Update(int id, [FromBody] User user)
        {
            var request = new UpdateRequest<User>(id, user);
            Response<User> response = userService.Update(request);

            return RenderResponse(response);
        }

        // DELETE: /api/users/1
        [HttpDelete]
        [Route("{id:int}")]
        public IHttpActionResult Remove(int id)
        {
            var request = new RemoveRequest(id);
            Response<Empty> response = userService.Remove(request);

            return RenderResponse(response);
        }
    }
}