namespace Infrastructure.BaseClasses
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// A baseline definition that every view models will inherit from
    /// </summary>
    public abstract class ViewModelBase
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int? CreatorId { get; set; }

        [Required]
        public DateTime CreationDate { get; private set; }

        [Required]
        public DateTime ModificationDate { get; set; }
    }
}