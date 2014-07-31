namespace Service.Services
{
    using Infrastructure.BaseClasses;
    using Infrastructure.Services;

    using Repository.Models;
    using Repository.Repositories;

    /// <summary>
    /// User service
    /// </summary>
    [MethodsAllowed(ServiceMethods.Get | ServiceMethods.GetPage | ServiceMethods.Add | ServiceMethods.Update | ServiceMethods.Remove)]
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
    }
}