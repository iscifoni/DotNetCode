using Microsoft.AspNetCore.Builder;

namespace BlackListMiddleware
{
    public static class BlackListMiddlewareBuilderExtention
    {
        public static IApplicationBuilder UseBlackList(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<BlackListMiddleware>();
        }
    }
}
