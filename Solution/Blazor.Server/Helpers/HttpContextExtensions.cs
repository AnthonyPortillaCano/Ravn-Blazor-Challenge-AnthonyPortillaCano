using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Blazor.Server.Helpers
{
    public static class HttpContextExtensions
    {
        public static  double InsertParametersPageInResponse<T>(this HttpContext context,
          IEnumerable<T> query, int QuantityRecordsShow)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            double count =  query.Count();
            double totalPages = Math.Ceiling(count / QuantityRecordsShow);
            context.Response.Headers.Add("totalPages", totalPages.ToString());
            return totalPages;
        }
    }
}
