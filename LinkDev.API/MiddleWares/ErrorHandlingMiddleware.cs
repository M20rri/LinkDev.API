using LinkDev.API.Exceptions;
using Newtonsoft.Json;
using System.Net;

namespace LinkDev.API.MiddleWares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ErrorHandlingMiddleware> logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var result = string.Empty;
            context.Response.ContentType = "application/json";

            switch (exception)
            {
                case ValidationException validationException:
                    context.Response.StatusCode = (int)HttpStatusCode.OK;

                    logger.LogError(JsonConvert.SerializeObject(validationException.Data));

                    result = JsonConvert.SerializeObject(new
                    {
                        message = "System Error",
                        statusCode = validationException.ErrorCode,
                        data = validationException.Data
                    });
                    break;
            }
            return context.Response.WriteAsync(result);



        }
    }
}
