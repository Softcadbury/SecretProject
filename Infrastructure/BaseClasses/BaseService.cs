namespace Infrastructure.BaseClasses
{
    using Infrastructure.Messaging.Requests;
    using Infrastructure.Messaging.Responses;

    /// <summary>
    /// A baseline definition that every service will inherit from
    /// </summary>
    public abstract class BaseService<TModel, TRepository>
        where TModel : BaseModel
        where TRepository : BaseRepository<TModel>
    {
        private readonly TRepository repository;

        /// <summary>
        /// Constructor
        /// </summary>
        protected BaseService(TRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Get a user
        /// </summary>
        public Response<TModel> Get(GetRequest request)
        {
            var model = repository.GetById(request.Id);

            if (model == null)
            {
                return Response<TModel>.CreateError(ErrorCodes.NotFound);
            }

            return Response<TModel>.CreateSuccess(model);
        }
    }
}