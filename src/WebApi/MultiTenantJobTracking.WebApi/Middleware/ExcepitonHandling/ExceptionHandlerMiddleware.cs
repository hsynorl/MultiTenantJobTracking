using System.Net;
using System.Security.Authentication;

namespace MultiTenantJobTracking.WebApi.Middleware.ExcepitonHandling
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ExceptionHandlerMiddleware> logger;

        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {

                await next.Invoke(context);
            }       
            catch (Exception ex)
            {
                logger.LogError($"Unexpected error: {ex.Message}. StackTrace: {ex.StackTrace}");
                await WriteResponse(context, HttpStatusCode.BadRequest, ex.Message);
            }

        }
        private static async Task WriteResponse(HttpContext context, HttpStatusCode statusCode, object responseObj)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            await context.Response.WriteAsJsonAsync(responseObj);
        }
    }
}
