﻿namespace Infrastructure.BaseClasses
{
    using System.Web.Http;

    using Infrastructure.Messaging.Responses;

    /// <summary>
    /// A baseline definition that every api controller will inherit from
    /// </summary>
    public abstract class BaseApiController : ApiController
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