namespace Service.Services
{
    using Infrastructure.ServiceResponses;
    using Infrastructure.Tools;

    using Service.ViewModels;

    using WebMatrix.WebData;

    /// <summary>
    /// Tool service
    /// </summary>
    public class ToolService
    {
        /// <summary>
        /// Send a contact email
        /// </summary>
        public Response<Empty> SendContactEmail(SendContactEmailViewModel sendContactEmail)
        {
            Mailing.SendContact(WebSecurity.CurrentUserName, sendContactEmail.Message);

            return Response<Empty>.CreateSuccess();
        }
    }
}