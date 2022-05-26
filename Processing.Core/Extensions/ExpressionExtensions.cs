using System.Linq.Expressions;
using LinqKit;

namespace Processing.Core.Extensions
{
    public static class ExpressionExtensions
    {
        public static Expression<Func<TEntity, bool>> Blank<TEntity>() => p => true;

        public static Expression<Func<TEntity, bool>> AndIf<TEntity>(
            this Expression<Func<TEntity, bool>> baseExpression,
            bool condition,
            Expression<Func<TEntity, bool>> predicate)
        {
            return condition
                ? baseExpression.And(predicate)
                : baseExpression;
        }
    }
}