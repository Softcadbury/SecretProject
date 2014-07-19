﻿namespace Repository.Configurations
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;

    using Repository.Models;

    /// <summary>
    /// Configuration for the model User
    /// </summary>
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public UserConfiguration()
        {
            Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("User");
            });
        }
    }
}