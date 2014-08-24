namespace Controller.ApiControllers
{
    using Infrastructure.BaseClasses;
    using Infrastructure.Services.Requests;
    using Infrastructure.Services.Responses;
    using Repository.Models;
    using Service.Services;
    using Service.ViewModels.Account;
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
                return BadRequest();
            }

            var request = new GetPageRequest(pageIndex, 20);
            Response<List<User>> response = userService.GetPage(request);

            return RenderResponse(response);
        }

        // PUT: /api/users/1
        [HttpPut]
        [Route("{id:int}")]
        public IHttpActionResult Update(int id, [FromBody] User user)
        {
            if (!ModelState.IsValid || user == null)
            {
                return BadRequest();
            }

            var request = new UpdateRequest<User>(id, user);
            Response<User> response = userService.Update(request);

            return RenderResponse(response);
        }

        // PUT: /api/users/1/changePassword
        [HttpPut]
        [Route("{id:int}/changePassword")]
        public IHttpActionResult ChangePassword(int id, [FromBody] ChangePasswordViewModel changePassword)
        {
            if (!ModelState.IsValid || changePassword == null)
            {
                return BadRequest();
            }

            return null;
        }
    }
}