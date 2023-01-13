using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace ProjetDotNet.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class AuthMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string[] AuthRoutes = { 
            "/post/create",
            "/post/reply",
            "/post/"
        };

        public AuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            var path = httpContext.Request.Path;
            if(!path.HasValue) return _next(httpContext);
            Console.WriteLine("Executing auth middleware with route: " + path.Value);
            if (!AuthRoutes.Contains(path.Value)) return _next(httpContext);

            if (httpContext.Session.GetString("username") == null)
            {
                httpContext.Response.Redirect("/login/index");
            }
            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class AuthMiddlewareMiddlewareExtensions
    {
        public static IApplicationBuilder UseAuthenticationMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuthMiddleware>();
        }
    }
}