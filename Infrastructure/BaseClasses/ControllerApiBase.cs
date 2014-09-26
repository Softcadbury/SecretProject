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

            return BadRequest(response.Message);
        }

        /// <summary>
        /// Aggregate errors in the model state in a string
        /// </summary>
        protected string RenderModelStateErrorsMessage()
        {
            string errorMessage = string.Empty;

            foreach (var values in ModelState.Values)
            {
                foreach (var errors in values.Errors)
                {
                    errorMessage += errors.ErrorMessage + "<br />";
                }
            }

            return errorMessage;
        }
    }
}