namespace Infrastructure.BaseClasses
{
    using Infrastructure.ServiceResponses;
    using Infrastructure.Tools;
    using System.Linq;
    using System.Net.Http;
    using System.Threading;
    using System.Web;
    using System.Web.Http;
    using System.Web.Http.Controllers;

    /// <summary>
    /// A baseline definition that every api controllers will inherit from
    /// </summary>
    [Authorize]
    public abstract class ControllerApiBase : ApiController
    {
        /// <summary>
        /// Override Initialize method to manage internationalization
        /// </summary>
        protected override void Initialize(HttpControllerContext context)
        {
            string cultureName = Cookies.GetCulture(GetHttpContext(context.Request));

            if (string.IsNullOrEmpty(cultureName) && context.Request != null && context.Request.Headers.AcceptLanguage != null && context.Request.Headers.AcceptLanguage.Count > 0)
            {
                cultureName = context.Request.Headers.AcceptLanguage.First().Value;
            }

            cultureName = Culture.GetImplementedCulture(cultureName);
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(cultureName);
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;

            base.Initialize(context);
        }

        /// <summary>
        /// Allow to get the HttpContext
        /// </summary>
        public HttpContextWrapper GetHttpContext(HttpRequestMessage request)
        {
            if (request.Properties.ContainsKey("MS_HttpContext"))
            {
                return ((HttpContextWrapper)request.Properties["MS_HttpContext"]);
            }
            else if (HttpContext.Current != null)
            {
                return new HttpContextWrapper(HttpContext.Current);
            }
            else
            {
                return null;
            }
        }

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