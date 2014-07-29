namespace Infrastructure.Services.Responses
{
    /// <summary>
    /// Used as return by services
    /// </summary>
    public class Response<TContent>
    {
        public TContent Content { get; private set; }
        public bool IsSuccess { get; private set; }
        public ErrorCodes ErrorCode { get; private set; }

        /// <summary>
        /// Create a success response
        /// </summary>
        public static Response<TContent> CreateSuccess(TContent content)
        {
            return new Response<TContent> { Content = content, IsSuccess = true };
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
        public static Response<TContent> CreateError(ErrorCodes errorCode)
        {
            return new Response<TContent> { IsSuccess = false, ErrorCode = errorCode };
        }
    }
}