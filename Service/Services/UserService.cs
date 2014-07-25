namespace Service.Services
{
    using Infrastructure.BaseClasses;
    using Infrastructure.ServiceBasePermission;

    using Repository.Models;
    using Repository.Repositories;

    /// <summary>
    /// User service
    /// </summary>
    [ServiceBasePermission(ServiceBaseMethods.Get | ServiceBaseMethods.GetPage | ServiceBaseMethods.Add | ServiceBaseMethods.Update | ServiceBaseMethods.Remove)]
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