namespace Infrastructure.BaseClasses
{
    using Infrastructure.ServiceResponses;
    using System.Web.Http;

    /// <summary>
    /// A baseline definition that every api controllers will inherit from
    /// </summary>
    [Authorize]
    public abstract class ControllerApiBase : ApiController
    {
        /// <summary>
        /// Render a response to an HttpActionResult
        /// </summary>
        protected IHttpActionResult RenderResponse<TContent>(Response<TContent> response)
        {
            if (response.IsSuccess)
            {
                return Ok(response.Content);
            }

            return InternalServerError();
        }
    }
}