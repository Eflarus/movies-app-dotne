using Microsoft.AspNetCore.Builder;

namespace MoviesApp.Middleware.ActorRequestLogMiddleware
{
    public static class ActorRequestLogMiddlewareExtensions
    {
        public static IApplicationBuilder UseActorRequestLog(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ActorRequestLogMiddleware>();
        }
    }
}