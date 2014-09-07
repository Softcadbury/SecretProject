namespace Infrastructure.BaseClasses
{
    using Infrastructure.Tools;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Validation;
    using System.Linq;
    using System.Linq.Expressions;

    /// <summary>
    /// A baseline definition that every repositories will inherit from
    /// </summary>
    public abstract class BaseRepository<TModel>
        where TModel : ModelBase
    {
        private readonly DbContext context;
        private readonly DbSet<TModel> dbSet;
        private readonly IQueryable<TModel> query;

        /// <summary>
        /// Constructor
        /// </summary>
        protected BaseRepository(DbContext context)
        {
            this.context = context;
            dbSet = context.Set<TModel>();
            query = dbSet;
        }

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            context.Dispose();
        }

        /// <summary>
        /// Get a single model from the database with its id
        /// </summary>
        public virtual TModel GetById(int id, params Expression<Func<TModel, object>>[] includeProperties)
        {
            return GetByPredicate(m => m.Id == id, includeProperties);
        }

        /// <summary>
        /// Get a list of models from the database with a predicate
        /// </summary>
        public TModel GetByPredicate(Expression<Func<TModel, bool>> wherePredicate, params Expression<Func<TModel, object>>[] includeProperties)
        {
            foreach (var property in includeProperties)
            {
                dbSet.Include(property);
            }

            return dbSet.Where(wherePredicate).FirstOrDefault();
        }

        /// <summary>
        /// Get a list of models from the database by pages (page starts at 1)
        /// </summary>
        public virtual List<TModel> GetPage(int pageIndex, int pageSize)
        {
            return query.OrderBy(m => m.Id).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }

        /// <summary>
        /// Add a model to the database
        /// </summary>
        public virtual TModel Add(TModel model)
        {
            model.CreationDate = DateTime.UtcNow;
            model.ModificationDate = DateTime.UtcNow;
            dbSet.Add(model);

            return model;
        }

        /// <summary>
        /// Update a model in the database
        /// </summary>
        public virtual TModel Update(TModel model)
        {
            var entry = context.Entry(model);

            if (entry.State == EntityState.Detached)
            {
                dbSet.Attach(model);
                entry = context.Entry(model);
            }

            model.ModificationDate = DateTime.UtcNow;
            entry.State = EntityState.Modified;

            return model;
        }

        /// <summary>
        /// Remove a model in the database
        /// </summary>
        public virtual void Remove(int id)
        {
            var model = GetById(id);

            if (context.Entry(model).State == EntityState.Detached)
            {
                dbSet.Attach(model);
            }

            dbSet.Remove(model);
        }

        /// <summary>
        /// Save changes in the database
        /// </summary>
        public int SaveChanges()
        {
            try
            {
                return context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Logging.Error(string.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                                                eve.Entry.Entity.GetType().Name, eve.Entry.State));

                    foreach (var ve in eve.ValidationErrors)
                    {
                        Logging.Error(string.Format("-> Property: \"{0}\", Error: \"{1}\"",
                                                    ve.PropertyName, ve.ErrorMessage));
                    }
                }

                throw;
            }
        }
    }
}