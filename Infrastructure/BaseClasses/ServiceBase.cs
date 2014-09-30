namespace Infrastructure.BaseClasses
{
    using Infrastructure.Tools;
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

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
        protected TViewModel BaseGet(int id, params Expression<Func<TModel, object>>[] includeProperties)
        {
            TModel model = Repository.GetById(id, includeProperties);

            return model.ConvertToView<TViewModel>();
        }

        /// <summary>
        /// Get a list of models
        /// </summary>
        protected List<TViewModel> BaseGetPage(int pageIndex, int pageSize)
        {
            List<TModel> models = Repository.GetPage(pageIndex, pageSize);

            return models.ConvertToViews<TViewModel>();
        }

        /// <summary>
        /// Add a model
        /// </summary>
        protected TViewModel BaseAdd(TViewModel viewModel)
        {
            TModel modelAdded = Repository.Add(viewModel.ConvertToModel<TModel>());
            Repository.SaveChanges();

            return modelAdded.ConvertToView<TViewModel>();
        }

        /// <summary>
        /// Update a model
        /// </summary>
        protected TViewModel BaseUpdate(TViewModel viewModel)
        {
            TModel modelUpdated = Repository.Update(viewModel.ConvertToModel<TModel>());
            Repository.SaveChanges();

            return modelUpdated.ConvertToView<TViewModel>();
        }

        /// <summary>
        /// Remove a model
        /// </summary>
        protected void BaseRemove(int id)
        {
            Repository.Remove(id);
            Repository.SaveChanges();
        }
    }
}