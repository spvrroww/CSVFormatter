using Models;

namespace CSVTest.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;
        private readonly RequestDelegate _delegate;

        public ExceptionHandlerMiddleware(ILogger<ExceptionHandlerMiddleware> logger, RequestDelegate requestdelegate)
        {
            _logger=logger;
            _delegate=requestdelegate;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _delegate(context);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Exception caught in middleware");
                HandleException(ex, context);
            }
        }


        private async Task HandleException(Exception ex, HttpContext context)
        {
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Response.ContentType = "application/json";

            await context.Response.WriteAsync(new ErrorModel { ErrorCode = StatusCodes.Status500InternalServerError, Message = "internal server error" }.ToString());
        }
    }
}
