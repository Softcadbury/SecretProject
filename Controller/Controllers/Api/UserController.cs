namespace Controller.Controllers.Api
{
    using Infrastructure.BaseClasses;
    using Infrastructure.ServiceResponses;
    using Service.Services;
    using Service.ViewModels.Account;
    using Service.ViewModels.User;
    using System.Collections.Generic;
    using System.Web.Http;

    /// <summary>
    /// User controller
    /// </summary>
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

        // GET: /api/users?pageIndex=1
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
                return BadRequest(RenderModelStateErrorsMessage());
            }

            Response<UserViewModel> response = userService.UpdateCurrent(user);

            return RenderResponse(response);
        }

        // PUT: /api/users/current/updatePassword
        [HttpPut]
        [Route("current/updatePassword")]
        public IHttpActionResult UpdateCurrentPassword([FromBody] UpdateCurrentUserPasswordViewModel updateCurrentUserPassword)
        {
            if (!ModelState.IsValid || updateCurrentUserPassword == null)
            {
                return BadRequest(RenderModelStateErrorsMessage());
            }

            Response<Empty> response = userService.UpdateCurrentPassword(updateCurrentUserPassword);

            return RenderResponse(response);
        }

        // DELETE: /api/users/current
        [HttpDelete]
        [Route("current")]
        public IHttpActionResult RemoveCurrent([FromBody] RemoveCurrentUserViewModel removeCurrentUser)
        {
            if (!ModelState.IsValid || removeCurrentUser == null)
            {
                return BadRequest(RenderModelStateErrorsMessage());
            }

            Response<Empty> response = userService.RemoveCurrent(removeCurrentUser);

            return RenderResponse(response);
        }
    }
}