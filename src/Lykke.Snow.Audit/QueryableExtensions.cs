using System.Linq;
using Lykke.Snow.Audit.Abstractions;

namespace Lykke.Snow.Audit
{
    public static class QueryableExtensions
    {
        /// <summary>
        /// Applies audit filter to the query
        /// </summary>
        /// <param name="query"></param>
        /// <param name="filter"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IQueryable<IAuditModel<T>> ApplyFilter<T>(this IQueryable<IAuditModel<T>> query, AuditTrailFilter<T> filter)
        {
            if (!string.IsNullOrEmpty(filter.UserName))
                query = query.Where(x => x.UserName.ToLower().Contains(filter.UserName.ToLower()));

            if (!string.IsNullOrEmpty(filter.CorrelationId))
                query = query.Where(x => x.CorrelationId == filter.CorrelationId);

            if (!string.IsNullOrEmpty(filter.ReferenceId))
                query = query.Where(x => x.DataReference.ToLower().Contains(filter.ReferenceId.ToLower()));

            if (filter.DataTypes != null && filter.DataTypes.Any())
                query = query.Where(x => filter.DataTypes.Contains(x.DataType));

            if (filter.ActionType.HasValue)
                query = query.Where(x => x.Type == filter.ActionType.Value);

            if (!string.IsNullOrEmpty(filter.ActionTypeDetails))
                query = query.Where(x => x.ActionTypeDetails.ToLower().Contains(filter.ActionTypeDetails.ToLower()));

            if (filter.StartDateTime.HasValue)
                query = query.Where(x => x.Timestamp >= filter.StartDateTime.Value);

            if (filter.EndDateTime.HasValue)
                query = query.Where(x => x.Timestamp <= filter.EndDateTime.Value);

            return query;
        }
    }
}