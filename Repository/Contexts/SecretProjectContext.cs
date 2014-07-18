﻿namespace Repository.Contexts
{
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    using Infrastructure.Tools;

    using Repository.Configurations;
    using Repository.Models;

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

            modelBuilder.Configurations.Add(new UserConfiguration());
        }

        public DbSet<User> Users { get; set; }
    }
}