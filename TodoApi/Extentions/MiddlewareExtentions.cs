using System;

namespace TodoApi.Extentions;

public static class MiddlewareExtentions
{
    public static IApplicationBuilder UseCustomMiddleware(this IApplicationBuilder app) => app.UseMiddleware<CustomMiddleware>();
}
