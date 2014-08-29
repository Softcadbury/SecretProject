namespace Controller.Controllers.Api
{
    using Infrastructure.BaseClasses;
    using Infrastructure.ServiceResponses;
    using Repository.Models;
    using Service.Services;
    using System.Collections.Generic;
    using System.Web.Http;

    /// <summary>
    /// ChatRoom controller
    /// </summary>
    [Authorize]
    [RoutePrefix("api/chatrooms")]
    public class ChatRoomController : ControllerApiBase
    {
        private readonly ChatRoomService chatRoomService;

        /// <summary>
        /// Constructor
        /// </summary>
        public ChatRoomController()
        {
            chatRoomService = new ChatRoomService();
        }

        // GET: /api/chatrooms?pageIndex=0
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetPage([FromUri] int pageIndex)
        {
            if (pageIndex < 0)
            {
                return BadRequest();
            }

            Response<List<ChatRoom>> response = chatRoomService.GetPage(pageIndex, 20);

            return RenderResponse(response);
        }
    }
}