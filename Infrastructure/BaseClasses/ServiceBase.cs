﻿namespace Infrastructure.BaseClasses
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
        /// <summary>
        /// Constructor
        /// </summary>
        protected BaseService(TRepository repository)
        {
            Repository = repository;
        }

        public readonly TRepository Repository;

        /// <summary>
        /// Get a model
        /// </summary>
        protected Response<TModel> BaseGet(int id)
        {
            TModel model = Repository.GetById(id);

            if (model == null)
            {
                return Response<TModel>.CreateError(ErrorCodes.NotFound);
            }

            return Response<TModel>.CreateSuccess(model);
        }

        /// <summary>
        /// Get a list of models
        /// </summary>
        protected Response<List<TModel>> BaseGetPage(int pageIndex, int pageSize)
        {
            List<TModel> models = Repository.GetPage(pageIndex, pageSize);

            return Response<List<TModel>>.CreateSuccess(models);
        }

        /// <summary>
        /// Add a model
        /// </summary>
        protected Response<TModel> BaseAdd(TModel model)
        {
            TModel modelAdded = Repository.Add(model);
            Repository.SaveChanges();

            if (modelAdded == null)
            {
                return Response<TModel>.CreateError(ErrorCodes.NotAdded);
            }

            return Response<TModel>.CreateSuccess(modelAdded);
        }

        /// <summary>
        /// Update a model
        /// </summary>
        protected Response<TModel> BaseUpdate(int id, TModel model)
        {
            if (id != model.Id)
            {
                return Response<TModel>.CreateError(ErrorCodes.BadRequest);
            }

            TModel modelUpdated = Repository.Update(model);
            Repository.SaveChanges();

            if (modelUpdated == null)
            {
                return Response<TModel>.CreateError(ErrorCodes.NotUpdated);
            }

            return Response<TModel>.CreateSuccess(modelUpdated);
        }

        /// <summary>
        /// Remove a model
        /// </summary>
        protected Response<Empty> BaseRemove(int id)
        {
            Repository.Remove(id);
            Repository.SaveChanges();

            return Response<Empty>.CreateSuccess();
        }
    }
}