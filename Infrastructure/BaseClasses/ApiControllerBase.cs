namespace Infrastructure.BaseClasses
{
    using System.Web.Http;

    using Infrastructure.Services.Responses;

    /// <summary>
    /// A baseline definition that every api controllers will inherit from
    /// </summary>
    [Authorize]
    public abstract class ApiControllerBase : ApiController
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