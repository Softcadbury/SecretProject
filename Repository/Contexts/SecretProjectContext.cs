namespace Repository.Contexts
{
    using Infrastructure.Tools;
    using Repository.Configurations;
    using Repository.Models;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    /// <summary>
    /// Database context for the application
    /// </summary>
    public class SecretProjectContext : DbContext
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public SecretProjectContext()
            : base(Settings.ConnectionString)
        {
        }

        /// <summary>
        /// Manage actions when models are created
        /// </summary>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new ChatRoomConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<ChatRoom> ChatRooms { get; set; }
    }
}