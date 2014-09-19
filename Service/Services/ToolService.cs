namespace Service.Services
{
    using Infrastructure.ServiceResponses;

    /// <summary>
    /// Tool service
    /// </summary>
    public class ToolService
    {
        /// <summary>
        /// Send a contact email
        /// </summary>
        public Response<Empty> SendContactEmail()
        {
            return Response<Empty>.CreateSuccess();
        }
    }
}