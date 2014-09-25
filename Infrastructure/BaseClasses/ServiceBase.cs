namespace Infrastructure.BaseClasses
{
    using Infrastructure.ServiceResponses;
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    using Infrastructure.Tools;

    /// <summary>
    /// A baseline definition that every services will inherit from
    /// </summary>
    public abstract class BaseService<TModel, TViewModel, TRepository>
        where TModel : ModelBase
        where TViewModel : ViewModelBase
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
        protected Response<TViewModel> BaseGet(int id, params Expression<Func<TModel, object>>[] includeProperties)
        {
            TModel model = Repository.GetById(id, includeProperties);

            if (model == null)
            {
                return Response<TViewModel>.CreateError(ErrorCodes.NotFound);
            }

            return Response<TViewModel>.CreateSuccess(model.ConvertToView<TViewModel>());
        }

        /// <summary>
        /// Get a list of models
        /// </summary>
        protected Response<List<TViewModel>> BaseGetPage(int pageIndex, int pageSize)
        {
            List<TModel> models = Repository.GetPage(pageIndex, pageSize);

            return Response<List<TViewModel>>.CreateSuccess(models.ConvertToViews<TViewModel>());
        }

        /// <summary>
        /// Add a model
        /// </summary>
        protected Response<TViewModel> BaseAdd(TViewModel viewModel)
        {
            TModel modelAdded = Repository.Add(viewModel.ConvertToModel<TModel>());
            Repository.SaveChanges();

            if (modelAdded == null)
            {
                return Response<TViewModel>.CreateError(ErrorCodes.NotAdded);
            }

            return Response<TViewModel>.CreateSuccess(modelAdded.ConvertToView<TViewModel>());
        }

        /// <summary>
        /// Update a model
        /// </summary>
        protected Response<TViewModel> BaseUpdate(TViewModel viewModel)
        {
            TModel modelUpdated = Repository.Update(viewModel.ConvertToModel<TModel>());
            Repository.SaveChanges();

            if (modelUpdated == null)
            {
                return Response<TViewModel>.CreateError(ErrorCodes.NotUpdated);
            }

            return Response<TViewModel>.CreateSuccess(modelUpdated.ConvertToView<TViewModel>());
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