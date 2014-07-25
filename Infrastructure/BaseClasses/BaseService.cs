namespace Infrastructure.BaseClasses
{
    using Infrastructure.Messaging.Requests;
    using Infrastructure.Messaging.Responses;
    using Infrastructure.ServiceBasePermission;
    using System;
    using System.Collections.Generic;
    using System.Linq;

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
            EnsureMethodRight(ServiceBaseMethods.Get);

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
            EnsureMethodRight(ServiceBaseMethods.GetPage);

            List<TModel> models = repository.GetPage(request.PageIndex, request.PageSize);

            return Response<List<TModel>>.CreateSuccess(models);
        }

        /// <summary>
        /// Add a model
        /// </summary>
        public Response<TModel> Add(AddRequest<TModel> request)
        {
            EnsureMethodRight(ServiceBaseMethods.Add);

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
            EnsureMethodRight(ServiceBaseMethods.Update);

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
            EnsureMethodRight(ServiceBaseMethods.Remove);

            repository.Remove(request.Id);
            repository.SaveChanges();

            return Response<Empty>.CreateSuccess();
        }

        /// <summary>
        /// Throw an exception if the method is not allowed
        /// </summary>
        private void EnsureMethodRight(ServiceBaseMethods methodToCkeck)
        {
            Attribute[] attributes = Attribute.GetCustomAttributes(GetType());

            if (attributes.OfType<ServiceBasePermissionAttribute>().Any(methodsAllowed => methodsAllowed.Flags.HasFlag(methodToCkeck)))
            {
                return;
            }

            throw new InvalidOperationException("The service doesn't allow this method");
        }
    }
}