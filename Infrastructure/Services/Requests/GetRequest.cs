namespace Infrastructure.Services.Requests
{
    /// <summary>
    /// This class represents the request to get a model
    /// </summary>
    public sealed class GetRequest
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public GetRequest(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}