namespace Service.Services
{
    using Infrastructure.BaseClasses;

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
            IsGetMethodAllowed = true;
            IsGetPageMethodAllowed = true;
            IsAddMethodAllowed = true;
            IsUpdateMethodAllowed = true;
            IsRemoveMethodAllowed = true;
        }
    }
}