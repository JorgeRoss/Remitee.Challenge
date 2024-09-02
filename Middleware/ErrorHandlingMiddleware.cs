using System.Net;
using System.Text.Json;

namespace remitee_challenge.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await JsonSerializer.SerializeAsync(context.Response.Body,HandleExceptionAsync(context, ex));
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            HttpStatusCode status;
            string message;

            switch (ex)
            {
                case ApplicationException:
                    status = HttpStatusCode.BadRequest;
                    message = ex.Message;
                    break;
                case KeyNotFoundException:
                    status = HttpStatusCode.NotFound;
                    message = "Not Found";
                    break;
                default:
                    status = HttpStatusCode.InternalServerError;
                    message = "Error";
                    break;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)status;

            return context.Response.WriteAsync(new
            {
                StatusCode = context.Response.StatusCode,
                Message = message
            }.ToString());
        }
    }
}
