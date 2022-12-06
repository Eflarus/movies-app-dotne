using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

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
            Dictionary<string, object> logString = new Dictionary<string, object>();
            logString.Add("Path", httpContext.Request.Path);
            logString.Add("Method", httpContext.Request.Method);
            logString.Add("Host", httpContext.Request.Host.Value);
            logString.Add("Protocol", httpContext.Request.Protocol);
            logString.Add("Scheme", httpContext.Request.Scheme);
            logString.Add("Params", httpContext.Request.Query);
            
            logger.LogTrace($"Request to Actors: {JsonConvert.SerializeObject(logString)}");
        }
        await _next(httpContext);
    }
}