using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace carRental.Models
{
    public class GlobalExceptionFilter : ExceptionFilterAttribute
    {
        private readonly ILogger<GlobalExceptionFilter> _logger;

        public GlobalExceptionFilter(ILogger<GlobalExceptionFilter> logger)
        {
            _logger = logger;
        }

        public override void OnException(ExceptionContext context)
        {
            var message = context.Exception.Message;

            switch(context.Exception.GetType().Name)
            {
                case nameof(RentalException):
                    _logger.LogWarning("Not found: {@exception}", context.Exception);
                    context.Result = new JsonResult(BuildErrorResponse(context, message)) {StatusCode = 422};
                    break;
                default:
                    context.Result = new JsonResult(BuildErrorResponse(context, message)) {StatusCode = 500};
                    break;
            }
        }

        private static ErrorResponse BuildErrorResponse(ExceptionContext context, string message)
        {
            return new ErrorResponse
            {
                Id = context.ActionDescriptor.Id,
                Message = message,
                ClassName = context.Exception.GetType().FullName
            };
        }
    }
}