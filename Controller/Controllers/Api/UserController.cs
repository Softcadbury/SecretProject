namespace Controller.Controllers.Api
{
    using Infrastructure.BaseClasses;
    using Infrastructure.ServiceResponses;
    using Repository.Models;
    using Service.Services;
    using Service.ViewModels;
    using Service.ViewModels.Account;
    using System.Collections.Generic;
    using System.Web.Http;

    /// <summary>
    /// User controller
    /// </summary>
    [Authorize]
    [RoutePrefix("api/users")]
    public class UserController : ControllerApiBase
    {
        private readonly UserService userService;

        /// <summary>
        /// Constructor
        /// </summary>
        public UserController()
        {
            userService = new UserService();
        }

        // GET: /api/users/current
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

            Response<List<User>> response = userService.GetPage(pageIndex, 20);

            return RenderResponse(response);
        }

        // PUT: /api/users/current
        [HttpPut]
        [Route("current")]
        public IHttpActionResult UpdateCurrent([FromBody] User user)
        {
            if (!ModelState.IsValid || user == null)
            {
                return BadRequest();
            }

            Response<User> response = userService.UpdateCurrent(user);

            return RenderResponse(response);
        }

        // PUT: /api/users/1/updatePassword
        [HttpPut]
        [Route("{id:int}/updatePassword")]
        public IHttpActionResult UpdatePassword(int id, [FromBody] ChangePasswordViewModel changePassword)
        {
            if (!ModelState.IsValid || changePassword == null)
            {
                return BadRequest();
            }

            Response<Empty> response = userService.UpdatePassword(id, changePassword);

            return RenderResponse(response);
        }

        // DELETE: /api/users/current
        [HttpDelete]
        [Route("current")]
        public IHttpActionResult RemoveCurrent([FromBody] DeleteAccountViewModel deleteAccount)
        {
            if (!ModelState.IsValid || deleteAccount == null)
            {
                return BadRequest();
            }

            Response<Empty> response = userService.RemoveCurrent(deleteAccount);

            return RenderResponse(response);
        }
    }
}