namespace Healink.MiddlewareServices
{
    public class CustomMiddleWare : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("Hello from Custom Middleware");
        }
    }

    public static class ClassWithNoImplementationMiddleWareExtension
    {
        public static IApplicationBuilder UseClassWithNoImplementationMiddleWare(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomMiddleWare>();
        }
    }
}
