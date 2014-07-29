namespace Infrastructure.Services.Requests
{
    /// <summary>
    /// This class represents the request to remove a model
    /// </summary>
    public sealed class RemoveRequest
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public RemoveRequest(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}