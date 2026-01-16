using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RequestLoggingMiddleware> _logger;

    public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        var requestPath = context.Request.Path;
        var requestType = context.Request.Method;

        _logger.LogError($"ENTERING: {requestType.ToUpper()}: {requestPath} at {DateTime.Now}");
        await _next(context);
        _logger.LogError($"LEAVING: {requestType.ToUpper()}: {requestPath} at {DateTime.Now}");
    }
}