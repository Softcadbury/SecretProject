namespace Service.Services
{
    using System.Collections.Generic;

    using Infrastructure.BaseClasses;
    using Infrastructure.Services.Requests;
    using Infrastructure.Services.Responses;

    using Repository.Models;
    using Repository.Repositories;

    /// <summary>
    /// User service
    /// </summary>
    public class UserService : BaseService<User, UserRepository>
    {
        private static readonly UserRepository UserRepository = new UserRepository();

        /// <summary>
        /// Constructor
        /// </summary>
        public UserService()
            : base(UserRepository)
        {
        }

        /// <summary>
        /// Get a model
        /// </summary>
        public new Response<User> Get(GetRequest request)
        {
            return base.Get(request);
        }

        /// <summary>
        /// Get a list of models
        /// </summary>
        public new Response<List<User>> GetPage(GetPageRequest request)
        {
            return base.GetPage(request);
        }

        /// <summary>
        /// Add a model
        /// </summary>
        public new Response<User> Add(AddRequest<User> request)
        {
            return base.Add(request);
        }

        /// <summary>
        /// Update a model
        /// </summary>
        public new Response<User> Update(UpdateRequest<User> request)
        {
            return base.Update(request);
        }

        /// <summary>
        /// Remove a model
        /// </summary>
        public new Response<Empty> Remove(RemoveRequest request)
        {
            return base.Remove(request);
        }
    }
}