using CustomMiddleware.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace CustomMiddleware.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseBasicAuth(this IApplicationBuilder app )
        {
            app.UseMiddleware<BasicAuthMiddleware>();
            return app;
        }
    }
}



