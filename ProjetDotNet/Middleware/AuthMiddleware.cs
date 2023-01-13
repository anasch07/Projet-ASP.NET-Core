using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using ProjetDotNet.Data;
using ProjetDotNet.Data.Context;
using ProjetDotNet.Data.Repository;
using ProjetDotNet.Models;
using System.Threading.Tasks;

namespace ProjetDotNet.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class AuthMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string[] AuthRoutes = { 
            "/post/create",
            "/reply/create",
        };

        public AuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            var path = httpContext.Request.Path;
            if(!path.HasValue) return _next(httpContext);
            if (!AuthRoutes.Contains(path.Value)) return _next(httpContext);

            Console.WriteLine("Executing auth middleware with route: " + path.Value);
            string? uid = httpContext.Session.GetString("userid");
            if (uid == null)
            {
                httpContext.Response.Redirect("/login");
                return _next(httpContext);
            }

            UserRepository userRepository = new UserRepository(AppDbContext.Instance);
            User? user = userRepository.FindById(int.Parse(uid));
            if(user == null)
            {
                httpContext.Session.Remove("userid");
                httpContext.Response.Redirect("/login");
                return _next(httpContext);
            }

            httpContext.Items["user"] = user;
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