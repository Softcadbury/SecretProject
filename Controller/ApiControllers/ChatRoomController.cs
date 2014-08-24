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
    /// ChatRoom controller
    /// </summary>
    [Authorize]
    [RoutePrefix("api/chatrooms")]
    public class ChatRoomController : ApiControllerBase
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

            var request = new GetPageRequest(pageIndex, 20);
            Response<List<ChatRoom>> response = chatRoomService.GetPage(request);

            return RenderResponse(response);
        }
    }
}