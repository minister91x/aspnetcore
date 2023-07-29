namespace WebCoreAPI
{
    public class CustomeMiddleWare
    {
        private readonly RequestDelegate _next;
        public CustomeMiddleWare(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await context.Response.WriteAsync("<div> Hello from Simple Middleware </div>");
            context.Response.OnStarting((state) =>
            {
                context.Response.Headers.Add("Correlation-ID", "QUANNT");
                return Task.FromResult(0);
            }, context);
        }
    }
}
