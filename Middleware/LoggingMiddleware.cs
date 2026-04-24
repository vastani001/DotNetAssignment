namespace UserManagementAPI.Middleware;

public class LoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<LoggingMiddleware> _logger;

    public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // Log the HTTP method and request path for visibility during development.
        _logger.LogInformation("Incoming request: {Method} {Path}", context.Request.Method, context.Request.Path);

        await _next(context);
    }
}
