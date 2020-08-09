using DBClassLib.DBModels;
using DBClassLib.GenericRepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace DBClassLib.GenericRepositoryClasses
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : class
    {
        private FullStackDBModel _databaseContext;
        private DbSet<TEntity> _dbSet;

        public GenericRepository(FullStackDBModel context)
        {
            this._databaseContext = context;
            this._dbSet = context.Set<TEntity>();
        }

        public virtual bool CreateRecord(TEntity entity)
        {
            _dbSet.Add(entity);
            return true;
        }

        public virtual TEntity ReadRecord(Guid ID)
        {
            return _dbSet.Find(ID);
        }

        public virtual IEnumerable<TEntity> ReadRecords(Expression<Func<TEntity, bool>> filter = null,
                                                        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                                        string includeProperties = "")
        {
            IQueryable<TEntity> query = _dbSet;

            if(filter != null)
            {
                query = query.Where(filter);
            }

            foreach(string propertyToBeIncluded in includeProperties.Split(new char[] { ',','|'}, StringSplitOptions.RemoveEmptyEntries))
            {
                if(!string.IsNullOrWhiteSpace(propertyToBeIncluded.Trim()))
                {
                    query = query.Include(propertyToBeIncluded.Trim());
                }
            }

            if(orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query;
            }
        }

        public virtual bool UpdateRecord(TEntity entity)
        {
            _dbSet.Attach(entity);
            _databaseContext.Entry(entity).State = EntityState.Modified;
            return true;
        }

        public virtual bool DeleteRecord(TEntity entity)
        {
            _dbSet.Remove(entity);
            return true;
        }
    }
}
