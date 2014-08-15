namespace Controller.ApiControllers
{
    using Infrastructure.BaseClasses;
    using Infrastructure.Services.Requests;
    using Infrastructure.Services.Responses;
    using Repository.Models;
    using Service.Services;
    using System.Collections.Generic;
    using System.Web.Http;

    /// <summary>
    /// User controller
    /// </summary>
    [Authorize]
    [RoutePrefix("api/users")]
    public class UserController : ApiControllerBase
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
        [Route("current")]
        public IHttpActionResult GetCurrent()
        {
            Response<User> response = userService.GetCurrent();

            return RenderResponse(response);
        }

        // GET: /api/users?pageIndex=0
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetPage([FromUri] int pageIndex)
        {
            if (pageIndex < 0)
            {
                return BadRequest("");
            }

            var request = new GetPageRequest(pageIndex, 20);
            Response<List<User>> response = userService.GetPage(request);

            return RenderResponse(response);
        }
    }
}