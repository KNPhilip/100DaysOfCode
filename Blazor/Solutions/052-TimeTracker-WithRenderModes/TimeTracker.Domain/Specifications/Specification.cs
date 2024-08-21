using System.Linq.Expressions;
using TimeTracker.Domain.Entities;

namespace TimeTracker.Domain.Specifications
{
    public abstract class Specification<TEntity> where TEntity : DbEntity
    {
        public Specification()
        {

        }

        public Specification(Expression<Func<TEntity, bool>> criteria)
        {
            Criteria = criteria;
        }

        public Expression<Func<TEntity, bool>>? Criteria { get; }
        public List<Expression<Func<TEntity, object>>>? Includes { get; } = [];
        public Expression<Func<TEntity, object>>? OrderBy { get; private set; }

        protected void AddInclude(Expression<Func<TEntity, object>> includeExpression)
        {
            Includes?.Add(includeExpression);
        }

        protected void AddOrderBy(Expression<Func<TEntity, object>> orderByExpression)
        {
            OrderBy = orderByExpression;
        }
    }
}
