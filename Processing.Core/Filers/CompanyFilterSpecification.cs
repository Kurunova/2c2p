using System.Linq.Expressions;
using Processing.Core.Entities;
using Processing.Core.Extensions;
using Processing.Core.Interfaces.Filters;

namespace Processing.Core.Filers
{
    public class TransactionFilterSpecification : IFilterSpecification<TransactionSearchRequestData, Transaction>
    {
        public Expression<Func<Transaction, bool>> GetExpression(TransactionSearchRequestData filterData)
        {
            var condition = ExpressionExtensions.Blank<Transaction>();
            
            condition = condition.AndIf(filterData.CurrencyCode != null, entity => filterData.CurrencyCode == entity.CurrencyCode);
            condition = condition.AndIf(filterData.From.HasValue, entity => entity.TransactionDate >= filterData.From);
            condition = condition.AndIf(filterData.To.HasValue, entity => filterData.To >= entity.TransactionDate);
            condition = condition.AndIf(filterData.Status.HasValue, entity => filterData.Status == entity.Status);

            return condition;
        }
    }
}