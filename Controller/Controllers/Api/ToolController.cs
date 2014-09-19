namespace Controller.Controllers.Api
{
    using Infrastructure.BaseClasses;
    using Infrastructure.ServiceResponses;
    using Service.Services;
    using System.Web.Http;

    /// <summary>
    /// Tool controller
    /// </summary>
    [Authorize]
    [RoutePrefix("api/tools")]
    public class ToolController : ControllerApiBase
    {
        private readonly ToolService toolService;

        /// <summary>
        /// Constructor
        /// </summary>
        public ToolController()
        {
            toolService = new ToolService();
        }

        // POST: /api/tools/sendContactEmail
        [HttpPost]
        [Route("sendContactEmail")]
        public IHttpActionResult SendContactEmail()
        {
            Response<Empty> response = toolService.SendContactEmail();

            return RenderResponse(response);
        }
    }
}