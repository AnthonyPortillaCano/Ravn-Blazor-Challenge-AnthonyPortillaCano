using Blazor.Shared;
using System.Collections.Generic;
using System.Linq;

namespace Blazor.Server.Helpers
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> Page<T>(this IEnumerable<T> list, Pagination pagination)
        {
            return list
                .Skip((pagination.Page - 1) * pagination.QuantityShow)
                .Take(pagination.QuantityShow);
        }
    }
}
