namespace Infrastructure.BaseClasses
{
    using System.Collections.Generic;
    using System.Data.Entity;

    /// <summary>
    /// A baseline definition that every repository will inherit from
    /// </summary>
    public abstract class BaseRepository<TModel>
        where TModel : BaseModel
    {
        private readonly DbContext context;

        /// <summary>
        /// Constructor
        /// </summary>
        protected BaseRepository(DbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Get a single model from the database with its id
        /// </summary>
        public virtual TModel GetById(int id)
        {
            // todo
            return null;
        }

        /// <summary>
        /// Get all models from the database in a range
        /// </summary>
        public virtual List<TModel> GetAll(int pageIndex, int pageSize)
        {
            // todo
            return null;
        }

        /// <summary>
        /// Add a model to the database
        /// </summary>
        public virtual TModel Add(TModel model)
        {
            // todo
            return model;
        }

        /// <summary>
        /// Update a model in the database
        /// </summary>
        public virtual TModel Update(TModel model)
        {
            // todo
            return model;
        }

        /// <summary>
        /// Remove a model in the database
        /// </summary>
        public virtual void Remove(int id)
        {
            // todo
        }
    }
}