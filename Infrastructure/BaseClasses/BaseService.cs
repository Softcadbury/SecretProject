namespace Infrastructure.BaseClasses
{
    using System.Collections.Generic;

    using Infrastructure.Services.Requests;
    using Infrastructure.Services.Responses;

    /// <summary>
    /// A baseline definition that every services will inherit from
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
        protected Response<TModel> Get(GetRequest request)
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
        protected Response<List<TModel>> GetPage(GetPageRequest request)
        {
            List<TModel> models = repository.GetPage(request.PageIndex, request.PageSize);

            return Response<List<TModel>>.CreateSuccess(models);
        }

        /// <summary>
        /// Add a model
        /// </summary>
        protected Response<TModel> Add(AddRequest<TModel> request)
        {
            TModel model = repository.Add(request.Model);
            repository.SaveChanges();

            if (model == null)
            {
                return Response<TModel>.CreateError(ErrorCodes.NotAdded);
            }

            return Response<TModel>.CreateSuccess(model);
        }

        /// <summary>
        /// Update a model
        /// </summary>
        protected Response<TModel> Update(UpdateRequest<TModel> request)
        {
            TModel model = repository.Update(request.Model);
            repository.SaveChanges();

            if (model == null)
            {
                return Response<TModel>.CreateError(ErrorCodes.NotUpdated);
            }

            return Response<TModel>.CreateSuccess(model);
        }

        /// <summary>
        /// Remove a model
        /// </summary>
        protected Response<Empty> Remove(RemoveRequest request)
        {
            repository.Remove(request.Id);
            repository.SaveChanges();

            return Response<Empty>.CreateSuccess();
        }
    }
}