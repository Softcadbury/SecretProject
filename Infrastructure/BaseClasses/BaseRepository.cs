namespace Infrastructure.BaseClasses
{
    using System.Collections.Generic;

    /// <summary>
    /// A baseline definition that every repository will inherit from
    /// </summary>
    public abstract class BaseRepository<TModel>
        where TModel : BaseModel
    {
        /// <summary>
        /// Get a single model from the database with its id
        /// </summary>
        public TModel GetById(long id)
        {
            return null;
        }

        /// <summary>
        /// Get all models from the database in a range
        /// </summary>
        public List<TModel> GetAll(int pageIndex, int pageSize)
        {
            return null;
        }
    }
}