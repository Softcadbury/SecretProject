namespace Infrastructure.Tools
{
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;

    using Infrastructure.BaseClasses;

    /// <summary>
    /// Generic mapper.
    /// </summary>
    public static class GenericMapper
    {
        /// <summary>
        /// Convert the model to a view
        /// </summary>
        /// <typeparam name="TView">Type of the view</typeparam>
        /// <param name="model">The model</param>
        /// <returns>The view</returns>
        public static TView ConvertToView<TView>(this ModelBase model)
            where TView : ViewModelBase
        {
            if (model == null)
            {
                return default(TView);
            }

            return (TView)Mapper.Map(model, model.GetType(), typeof(TView));
        }

        /// <summary>
        /// Convert the list of models to a list of views
        /// </summary>
        /// <typeparam name="TView">Type of the view</typeparam>
        /// <param name="model">The list of models</param>
        /// <returns>The list of views</returns>
        public static List<TView> ConvertToViews<TView>(this IEnumerable<ModelBase> model)
            where TView : ViewModelBase
        {
            return model.Select(m => m.ConvertToView<TView>()).ToList();
        }

        /// <summary>
        /// Convert the view to a model
        /// </summary>
        /// <typeparam name="TModel">Type of the model</typeparam>
        /// <param name="view">The view</param>
        /// <returns>The model</returns>
        public static TModel ConvertToModel<TModel>(this ViewModelBase view)
            where TModel : ModelBase
        {
            if (view == null)
            {
                return default(TModel);
            }

            return (TModel)Mapper.Map(view, view.GetType(), typeof(TModel));
        }

        /// <summary>
        /// Convert the list of views to a list of models
        /// </summary>
        /// <typeparam name="TModel">Type of the model</typeparam>
        /// <param name="view">The list of views</param>
        /// <returns>The list of models</returns>
        public static List<TModel> ConvertToModels<TModel>(this IEnumerable<ViewModelBase> view)
            where TModel : ModelBase
        {
            return view.Select(v => v.ConvertToModel<TModel>()).ToList();
        }
    }
}