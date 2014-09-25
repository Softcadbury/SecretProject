namespace Infrastructure.Tools
{
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;

    using Infrastructure.BaseClasses;

    /// <summary>
    /// Class to manage mapping of models and view models
    /// </summary>
    public static class GenericMapper
    {
        /// <summary>
        /// Convert the model to a view model
        /// </summary>
        /// <typeparam name="TViewModel">Type of the view model</typeparam>
        /// <param name="model">The model</param>
        /// <returns>The view model</returns>
        public static TViewModel ConvertToView<TViewModel>(this ModelBase model)
            where TViewModel : ViewModelBase
        {
            if (model == null)
            {
                return default(TViewModel);
            }

            return (TViewModel)Mapper.Map(model, model.GetType(), typeof(TViewModel));
        }

        /// <summary>
        /// Convert the list of models to a list of view models
        /// </summary>
        /// <typeparam name="TViewModel">Type of the view model</typeparam>
        /// <param name="model">The list of models</param>
        /// <returns>The list of view models</returns>
        public static List<TViewModel> ConvertToViews<TViewModel>(this IEnumerable<ModelBase> model)
            where TViewModel : ViewModelBase
        {
            return model.Select(m => m.ConvertToView<TViewModel>()).ToList();
        }

        /// <summary>
        /// Convert the view model to a model
        /// </summary>
        /// <typeparam name="TModel">Type of the model</typeparam>
        /// <param name="viewModel">The view model</param>
        /// <returns>The model</returns>
        public static TModel ConvertToModel<TModel>(this ViewModelBase viewModel)
            where TModel : ModelBase
        {
            if (viewModel == null)
            {
                return default(TModel);
            }

            return (TModel)Mapper.Map(viewModel, viewModel.GetType(), typeof(TModel));
        }

        /// <summary>
        /// Convert the list of view models to a list of models
        /// </summary>
        /// <typeparam name="TModel">Type of the model</typeparam>
        /// <param name="viewModel">The list of view models</param>
        /// <returns>The list of models</returns>
        public static List<TModel> ConvertToModels<TModel>(this IEnumerable<ViewModelBase> viewModel)
            where TModel : ModelBase
        {
            return viewModel.Select(v => v.ConvertToModel<TModel>()).ToList();
        }
    }
}