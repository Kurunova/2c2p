using System.Linq.Expressions;
using Processing.Core.Entities;

namespace Processing.Core.Interfaces;

public interface IRepository<TEntity>
    where TEntity : class, IEntity
{
    IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

    void Add(IEnumerable<TEntity> entity);

    void Add(TEntity entity);

    void Update(TEntity entity);
}