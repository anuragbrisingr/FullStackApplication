using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DBClassLib.GenericRepositoryInterfaces
{
    public interface IGenericRepository<TEntity>
        where TEntity : class
    {
        bool CreateRecord(TEntity entity);
        TEntity ReadRecord(Guid ID);
        IEnumerable<TEntity> ReadRecords(Expression<Func<TEntity, bool>> filter = null,
                                         Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                         string includeProperties = "");
        bool UpdateRecord(TEntity entity);
        bool DeleteRecord(TEntity entity);
    }
}
