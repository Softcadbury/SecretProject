namespace Controller.Controllers.Api
{
    using Infrastructure.BaseClasses;
    using Infrastructure.ServiceResponses;
    using Service.Services;
    using Service.ViewModels;
    using Service.ViewModels.Account;
    using System.Collections.Generic;
    using System.Web.Http;

    using Service.ViewModels.User;

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
            Response<UserViewModel> response = userService.GetCurrent();

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

            Response<List<UserViewModel>> response = userService.GetPage(pageIndex, 20);

            return RenderResponse(response);
        }

        // PUT: /api/users/current
        [HttpPut]
        [Route("current")]
        public IHttpActionResult UpdateCurrent([FromBody] UserViewModel user)
        {
            if (!ModelState.IsValid || user == null)
            {
                return BadRequest(RenderErrorMessage());
            }

            Response<UserViewModel> response = userService.UpdateCurrent(user);

            return RenderResponse(response);
        }

        // PUT: /api/users/current/updatePassword
        [HttpPut]
        [Route("current/updatePassword")]
        public IHttpActionResult UpdateCurrentPassword([FromBody] UpdatePasswordViewModel updatePassword)
        {
            if (!ModelState.IsValid || updatePassword == null)
            {
                return BadRequest(RenderErrorMessage());
            }

            Response<Empty> response = userService.UpdateCurrentPassword(updatePassword);

            return RenderResponse(response);
        }

        // DELETE: /api/users/current
        [HttpDelete]
        [Route("current")]
        public IHttpActionResult RemoveCurrent([FromBody] DeleteAccountViewModel deleteAccount)
        {
            if (!ModelState.IsValid || deleteAccount == null)
            {
                return BadRequest(RenderErrorMessage());
            }

            Response<Empty> response = userService.RemoveCurrent(deleteAccount);

            return RenderResponse(response);
        }
    }
}