namespace Infrastructure.Services.Requests
{
    using Infrastructure.BaseClasses;

    /// <summary>
    /// This class represents the request to update a model
    /// </summary>
    public sealed class UpdateRequest<TModel>
        where TModel : ModelBase
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public UpdateRequest(int id, TModel model)
        {
            Id = id;
            Model = model;
        }

        public int Id { get; private set; }
        public TModel Model { get; private set; }
    }
}