namespace Repository.Contexts
{
    using System.Collections.Generic;
    using System.Data.Entity;

    using Repository.Models;

    /// <summary>
    /// Initializer for the application database
    /// </summary>
    public class SecretProjectInitializer : DropCreateDatabaseIfModelChanges<SecretProjectContext>
    {
        /// <summary>
        /// Initialize the database when created
        /// </summary>
        protected override void Seed(SecretProjectContext context)
        {
            var users = new List<User>
            {
                new User { Name = "Softcadbury" },
            };

            users.ForEach(s => context.Users.Add(s));
            context.SaveChanges();
        }
    }
}