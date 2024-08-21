using Microsoft.EntityFrameworkCore;
using TimeTracker.Domain.Entities;

namespace TimeTracker.Domain.Specifications
{
    public static class SpecificationQueryBuilder
    {
        public static IQueryable<TEntity> GetQuery<TEntity>(
            IQueryable<TEntity> inputQuery, 
            Specification<TEntity> specification)
            where TEntity : DbEntity
        {
            if (specification.Criteria is not null)
            {
                inputQuery = inputQuery.Where(specification.Criteria);
            }

            if (specification.Includes is not null)
            {
                inputQuery = specification.Includes
                    .Aggregate(inputQuery, (current, include) => current.Include(include));
            }

            if (specification.OrderBy is not null)
            {
                inputQuery = inputQuery.OrderBy(specification.OrderBy);
            }

            return inputQuery;
        }
    }
}
