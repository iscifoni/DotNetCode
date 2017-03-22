using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace BlackListMiddleware
{
    public class BlackListMiddleware
    {
        RequestDelegate _next;
        List<string> _urlBlackList = new List<string>()
        {
            "/Home/About"
        };

        public BlackListMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var urlToCheck = context.Request.Path;
            if (urlToCheck.HasValue && _urlBlackList.Any(p => urlToCheck.StartsWithSegments(p)))
            {
                context.Response.StatusCode = 404;
            }
            else
            {
                await _next.Invoke(context);
            }
        }
    }
}
