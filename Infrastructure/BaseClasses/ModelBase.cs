namespace Infrastructure.BaseClasses
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// A baseline definition that every models will inherit from
    /// </summary>
    public abstract class ModelBase
    {
        [Required]
        public int Id { get; set; }

        public int? CreatorId { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

        [Required]
        public DateTime ModificationDate { get; set; }
    }
}