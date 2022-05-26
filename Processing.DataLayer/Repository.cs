using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Processing.Core.Entities;
using Processing.Core.Interfaces;
using Processing.Core.Interfaces.Filters;

namespace Processing.DataLayer
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class, IEntity
    {
        private readonly DbSet<TEntity> _dbSet;
        private readonly DbContext _dbContext;

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext?.Set<TEntity>() ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public IQueryable<TEntity> Find<TFilterSpecification, TRequestData>(TRequestData requestData)
            where TFilterSpecification : IFilterSpecification<TRequestData, TEntity>, new()
            where TRequestData : class, IRequestData
        {
            var filterSpecification = new TFilterSpecification();
            var expression = filterSpecification.GetExpression(requestData);

            var entities = _dbSet.Where(expression);
            return entities;
        }
        
        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
            => _dbSet.Where(predicate);

        public void Add(IEnumerable<TEntity> entity)
        {
            _dbSet.AddRange(entity);
            _dbContext.SaveChanges();
        }

        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}