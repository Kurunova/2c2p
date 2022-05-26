using System.Linq.Expressions;

namespace Processing.Core.Interfaces.Filters
{
    public interface IFilterSpecification<TRequestData, TEntity>
        where TRequestData : IRequestData
        where TEntity : class
    {
        Expression<Func<TEntity, bool>> GetExpression(TRequestData filterData);
    }
}