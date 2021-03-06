﻿namespace Infrastructure.ServiceResponses
{
    /// <summary>
    /// Used as return by services
    /// </summary>
    public class Response<TContent>
    {
        public bool IsSuccess { get; private set; }
        public TContent Content { get; private set; }
        public string Message { get; private set; }

        /// <summary>
        /// Create a success response with a content
        /// </summary>
        public static Response<TContent> CreateSuccess(TContent content)
        {
            return new Response<TContent> { IsSuccess = true, Content = content };
        }

        /// <summary>
        /// Create a success response
        /// </summary>
        public static Response<TContent> CreateSuccess()
        {
            return new Response<TContent> { IsSuccess = true };
        }

        /// <summary>
        /// Create an error response
        /// </summary>
        public static Response<TContent> CreateError(string message = null)
        {
            return new Response<TContent> { IsSuccess = false, Message = message };
        }
    }
}