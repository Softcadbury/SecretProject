namespace Repository.Repositories
{
    using Infrastructure.BaseClasses;
    using Repository.Contexts;
    using Repository.Models;

    /// <summary>
    /// User repository
    /// </summary>
    public class UserRepository : BaseRepository<User>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public UserRepository()
            : base(new SecretProjectContext())
        {
        }
    }
}