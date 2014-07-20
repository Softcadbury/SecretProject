namespace Infrastructure.BaseClasses
{
    using System.Collections.Generic;

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
        /// Get a model
        /// </summary>
        public Response<TModel> Get(GetRequest request)
        {
            TModel model = repository.GetById(request.Id);

            if (model == null)
            {
                return Response<TModel>.CreateError(ErrorCodes.NotFound);
            }

            return Response<TModel>.CreateSuccess(model);
        }

        /// <summary>
        /// Get a list of models
        /// </summary>
        public Response<List<TModel>> GetAll(GetAllRequest request)
        {
            List<TModel> models = repository.GetAll(request.PageIndex, request.PageSize);

            return Response<List<TModel>>.CreateSuccess(models);
        }

        /// <summary>
        /// Add a model
        /// </summary>
        public Response<TModel> Add(AddRequest<TModel> request)
        {
            TModel model = repository.Add(request.Model);

            if (model == null)
            {
                return Response<TModel>.CreateError(ErrorCodes.NotAdded);
            }

            return Response<TModel>.CreateSuccess(model);
        }

        /// <summary>
        /// Update a model
        /// </summary>
        public Response<TModel> Update(UpdateRequest<TModel> request)
        {
            TModel model = repository.Update(request.Model);

            if (model == null)
            {
                return Response<TModel>.CreateError(ErrorCodes.NotUpdated);
            }

            return Response<TModel>.CreateSuccess(model);
        }

        /// <summary>
        /// Remove a model
        /// </summary>
        public Response<Empty> Remove(RemoveRequest request)
        {
            repository.Remove(request.Id);

            return Response<Empty>.CreateSuccess();
        }
    }
}