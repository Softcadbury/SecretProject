namespace Infrastructure.Messaging.Requests
{
    /// <summary>
    /// This class represents the request to get a model
    /// </summary>
    public sealed class GetRequest
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public GetRequest(long id)
        {
            Id = id;
        }

        public long Id { get; private set; }
    }
}