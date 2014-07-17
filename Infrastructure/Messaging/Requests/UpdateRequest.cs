namespace Infrastructure.Messaging.Requests
{
    using Infrastructure.BaseClasses;

    /// <summary>
    /// This class represents the request to update a model
    /// </summary>
    public sealed class UpdateRequest<TModel>
        where TModel : BaseModel
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public UpdateRequest(long id, TModel model)
        {
            Id = id;
            Model = model;
        }

        public long Id { get; private set; }
        public TModel Model { get; private set; }
    }
}