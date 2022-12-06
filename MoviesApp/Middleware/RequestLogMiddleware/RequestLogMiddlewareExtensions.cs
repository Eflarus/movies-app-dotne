using Microsoft.AspNetCore.Builder;

namespace MoviesApp.Middleware.RequestLogMiddleware
{
    public static class RequestLogMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestLog(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestLogMiddleware>();
        }
    }
}