using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.Entity;

namespace Core.Extensions.Data
{
    public static class DataExtensions
    {
        public static IQueryable<T> IncludeMultiple<T>(this IQueryable<T> query,
            params Expression<Func<T, object>>[] predicates)
            where T : class, IEntity
        {
            if (predicates != null)
            {
                query = predicates.Aggregate(query, (current, include) => current.IncludeMultiple(include));

            }

            return query;
        }
    }
}
