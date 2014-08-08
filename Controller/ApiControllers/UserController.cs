﻿namespace Controller.ApiControllers
{
    using System.Collections.Generic;
    using System.Web.Http;
    using Infrastructure.BaseClasses;
    using Infrastructure.Services.Requests;
    using Infrastructure.Services.Responses;
    using Repository.Models;
    using Service.Services;

    /// <summary>
    /// User controller
    /// </summary>
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
        [Route("{id:int}")]
        public IHttpActionResult Get(int id)
        {
            if (id <= 0)
            {
                return BadRequest("");
            }

            var request = new GetRequest(id);
            Response<User> response = userService.Get(request);

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

        // POST: /api/users
        [HttpPost]
        [Route("")]
        public IHttpActionResult Add([FromBody] User user)
        {
            if (!ModelState.IsValid || user == null)
            {
                return BadRequest("");
            }

            var request = new AddRequest<User>(user);
            Response<User> response = userService.Add(request);

            return RenderResponse(response);
        }

        // PUT: /api/users/1
        [HttpPut]
        [Route("{id:int}")]
        public IHttpActionResult Update(int id, [FromBody] User user)
        {
            if (!ModelState.IsValid || user == null)
            {
                return BadRequest("");
            }

            var request = new UpdateRequest<User>(id, user);
            Response<User> response = userService.Update(request);

            return RenderResponse(response);
        }

        // DELETE: /api/users/1
        [HttpDelete]
        [Route("{id:int}")]
        public IHttpActionResult Remove(int id)
        {
            if (id <= 0)
            {
                return BadRequest("");
            }

            var request = new RemoveRequest(id);
            Response<Empty> response = userService.Remove(request);

            return RenderResponse(response);
        }
    }
}