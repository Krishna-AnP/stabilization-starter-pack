namespace PatchApi.Middleware;

public class CorrelationIdMiddleware
{
    private readonly RequestDelegate _next;

    public CorrelationIdMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        var id = Guid.NewGuid().ToString();

        context.Response.Headers["X-Correlation-ID"] = id;

        await _next(context);
    }
}
