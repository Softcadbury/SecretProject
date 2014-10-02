namespace Repository.Repositories
{
    using Infrastructure.BaseClasses;
    using Repository.Contexts;
    using Repository.Models;
    using System.Web.Security;
    using WebMatrix.WebData;

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

        /// <summary>
        /// Remove the current user
        /// </summary>
        public void RemoveCurrent()
        {
            ((SimpleMembershipProvider)Membership.Provider).DeleteAccount(WebSecurity.CurrentUserName);
            Membership.Provider.DeleteUser(WebSecurity.CurrentUserName, true);
        }
    }
}