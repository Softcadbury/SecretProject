﻿namespace Infrastructure.BaseClasses
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;

    /// <summary>
    /// A baseline definition that every configuration of models will inherit from
    /// </summary>
    public class ConfigurationBase<TModel> : EntityTypeConfiguration<TModel>
        where TModel : ModelBase
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public ConfigurationBase()
        {
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(m => m.CreatorId).IsOptional();
            Property(m => m.CreationDate).IsRequired();
            Property(m => m.ModificationDate).IsRequired();
        }
    }
}