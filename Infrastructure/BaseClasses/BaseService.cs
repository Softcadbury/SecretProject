namespace Infrastructure.BaseClasses
{
    using System;
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

        protected bool IsGetMethodAllowed { get; set; }
        protected bool IsGetAllMethodAllowed { get; set; }
        protected bool IsAddMethodAllowed { get; set; }
        protected bool IsUpdateMethodAllowed { get; set; }
        protected bool IsRemoveMethodAllowed { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        protected BaseService(TRepository repository)
        {
            this.repository = repository;

            IsGetMethodAllowed = true;
            IsGetAllMethodAllowed = true;
            IsAddMethodAllowed = true;
            IsUpdateMethodAllowed = true;
            IsRemoveMethodAllowed = true;
        }

        /// <summary>
        /// Get a model
        /// </summary>
        public Response<TModel> Get(GetRequest request)
        {
            if (!IsGetMethodAllowed)
            {
                throw new InvalidOperationException("The service doesn't allow this method");
            }

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
            if (!IsGetAllMethodAllowed)
            {
                throw new InvalidOperationException("The service doesn't allow this method");
            }

            List<TModel> models = repository.GetAll(request.PageIndex, request.PageSize);

            return Response<List<TModel>>.CreateSuccess(models);
        }

        /// <summary>
        /// Add a model
        /// </summary>
        public Response<TModel> Add(AddRequest<TModel> request)
        {
            if (!IsAddMethodAllowed)
            {
                throw new InvalidOperationException("The service doesn't allow this method");
            }

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
            if (!IsUpdateMethodAllowed)
            {
                throw new InvalidOperationException("The service doesn't allow this method");
            }

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
            if (!IsRemoveMethodAllowed)
            {
                throw new InvalidOperationException("The service doesn't allow this method");
            }

            repository.Remove(request.Id);

            return Response<Empty>.CreateSuccess();
        }
    }
}