namespace Infrastructure.BaseClasses
{
    using System.Collections.Generic;
    using Infrastructure.ServiceResponses;

    /// <summary>
    /// A baseline definition that every services will inherit from
    /// </summary>
    public abstract class BaseService<TModel, TRepository>
        where TModel : ModelBase
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
        protected Response<TModel> Get(int id)
        {
            TModel model = repository.GetById(id);

            if (model == null)
            {
                return Response<TModel>.CreateError(ErrorCodes.NotFound);
            }

            return Response<TModel>.CreateSuccess(model);
        }

        /// <summary>
        /// Get a list of models
        /// </summary>
        protected Response<List<TModel>> GetPage(int pageIndex, int pageSize)
        {
            List<TModel> models = repository.GetPage(pageIndex, pageSize);

            return Response<List<TModel>>.CreateSuccess(models);
        }

        /// <summary>
        /// Add a model
        /// </summary>
        protected Response<TModel> Add(TModel model)
        {
            TModel modelAdded = repository.Add(model);
            repository.SaveChanges();

            if (modelAdded == null)
            {
                return Response<TModel>.CreateError(ErrorCodes.NotAdded);
            }

            return Response<TModel>.CreateSuccess(modelAdded);
        }

        /// <summary>
        /// Update a model
        /// </summary>
        protected Response<TModel> Update(int id, TModel model)
        {
            if (id != model.Id)
            {
                return Response<TModel>.CreateError(ErrorCodes.BadRequest);
            }

            TModel modelUpdated = repository.Update(model);
            repository.SaveChanges();

            if (modelUpdated == null)
            {
                return Response<TModel>.CreateError(ErrorCodes.NotUpdated);
            }

            return Response<TModel>.CreateSuccess(modelUpdated);
        }

        /// <summary>
        /// Remove a model
        /// </summary>
        protected Response<Empty> Remove(int id)
        {
            repository.Remove(id);
            repository.SaveChanges();

            return Response<Empty>.CreateSuccess();
        }
    }
}