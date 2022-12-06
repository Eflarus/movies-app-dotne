using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace MoviesApp.Middleware.ActorRequestLogMiddleware;

public class ActorRequestLogMiddleware
{
    private readonly RequestDelegate _next;

    public ActorRequestLogMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext httpContext, ILogger<ActorRequestLogMiddleware> logger)
    {
        if (httpContext.Request.Path.StartsWithSegments("/Actors"))
        {
            var q = httpContext.Request.Query.ToList();
            var sb = new StringBuilder();
            foreach (var param in q)
            {
                sb.Append($"{param.Key}={param.Value}; ");
            }

            logger.LogTrace($"Request to Actors: {httpContext.Request.Path} whith params: {sb.ToString()}");
        }
        await _next(httpContext);
    }
}