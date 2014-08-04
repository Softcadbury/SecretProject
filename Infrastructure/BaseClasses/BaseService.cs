namespace Infrastructure.BaseClasses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Infrastructure.Services;
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
        public Response<TModel> Get(GetRequest request)
        {
            EnsureMethodRight(ServiceMethods.Get);

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
        public Response<List<TModel>> GetPage(GetPageRequest request)
        {
            EnsureMethodRight(ServiceMethods.GetPage);

            List<TModel> models = repository.GetPage(request.PageIndex, request.PageSize);

            return Response<List<TModel>>.CreateSuccess(models);
        }

        /// <summary>
        /// Add a model
        /// </summary>
        public Response<TModel> Add(AddRequest<TModel> request)
        {
            EnsureMethodRight(ServiceMethods.Add);

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
        public Response<TModel> Update(UpdateRequest<TModel> request)
        {
            EnsureMethodRight(ServiceMethods.Update);

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
        public Response<Empty> Remove(RemoveRequest request)
        {
            EnsureMethodRight(ServiceMethods.Remove);

            repository.Remove(request.Id);
            repository.SaveChanges();

            return Response<Empty>.CreateSuccess();
        }

        /// <summary>
        /// Throw an exception if the method is not allowed
        /// </summary>
        private void EnsureMethodRight(ServiceMethods methodToCkeck)
        {
            Attribute[] attributes = Attribute.GetCustomAttributes(GetType());

            if (attributes.OfType<MethodsAllowedAttribute>().Any(methodsAllowed => methodsAllowed.Flags.HasFlag(methodToCkeck)))
            {
                return;
            }

            throw new InvalidOperationException("The service doesn't allow this method");
        }
    }
}