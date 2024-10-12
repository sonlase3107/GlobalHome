using System;

namespace TodoApi.Extentions;

public class CustomMiddleware
{
    private readonly RequestDelegate _next;

    public CustomMiddleware(RequestDelegate requestDelegate) => _next = requestDelegate;

    public async Task InvokeAsync(HttpContext httpContext)
    {
        Console.WriteLine(httpContext.Request.Headers.Keys);
        if (httpContext.Request.Headers.ContainsKey("code"))
        {
            await _next(httpContext);
        }
        httpContext.Response.StatusCode = StatusCodes.Status203NonAuthoritative;
        return;
    }
}
