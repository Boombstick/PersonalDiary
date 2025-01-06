using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PersonalDiary.Application.Exceptions;

namespace PersonalDiary.Api.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            switch (context.Exception)
            {
                case NotFoundException _:
                    GetException(context, HttpStatusCode.NotFound);
                    break;

                default:
                    GetException(context, HttpStatusCode.InternalServerError);
                    break;
            }


        }
        private void GetException(ExceptionContext context, HttpStatusCode statusCode)
        {
            var message = context.Exception.InnerException?.Message ?? context.Exception.Message;
            var stackTrace = context.Exception.InnerException?.ToString() ?? context.Exception.ToString();
            //_logger.LogError($"{DateTime.UtcNow:yyyy-MM-dd hh:mm:ss.fff}: " +
            //                 $"{(_hideEx ? message : stackTrace)}");
            //var result = _hideEx
            //    ? new JsonResult(new { error = message })
            //    : new JsonResult(new { error = message, stackTrace });
            var result = new JsonResult(new { error = message, stackTrace });
            Complete(context, HttpStatusCode.NotFound, result);
        }
        private static void Complete(ExceptionContext context, HttpStatusCode code, IActionResult result)
        {
            context.HttpContext.Response.ContentType = "application/json";
            context.HttpContext.Response.StatusCode = (int)code;
            context.Result = result;
        }

    }
}
