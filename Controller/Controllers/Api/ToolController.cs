namespace Controller.Controllers.Api
{
    using Infrastructure.BaseClasses;
    using Infrastructure.ServiceResponses;
    using Service.Services;
    using System.Web.Http;

    using Service.ViewModels;

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
        public IHttpActionResult SendContactEmail(SendContactEmailViewModel sendContactEmail)
        {
            if (!ModelState.IsValid || sendContactEmail == null)
            {
                return BadRequest(RenderErrorMessage());
            }

            Response<Empty> response = toolService.SendContactEmail(sendContactEmail);

            return RenderResponse(response);
        }
    }
}