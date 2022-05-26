using System.Linq.Expressions;
using Processing.Core.Entities;
using Processing.Core.Interfaces.Filters;

namespace Processing.Core.Interfaces;

public interface IRepository<TEntity>
    where TEntity : class, IEntity
{
    IQueryable<TEntity> Find<TFilterSpecification, TRequestData>(TRequestData requestData)
        where TFilterSpecification : IFilterSpecification<TRequestData, TEntity>, new()
        where TRequestData : class, IRequestData;

    IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

    void Add(IEnumerable<TEntity> entity);

    void Add(TEntity entity);

    void Update(TEntity entity);
}