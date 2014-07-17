namespace Infrastructure.Messaging.Requests
{
    /// <summary>
    /// This class represents the request to delete a model
    /// </summary>
    public sealed class DeleteRequest
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public DeleteRequest(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}