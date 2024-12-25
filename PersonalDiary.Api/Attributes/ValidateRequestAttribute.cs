using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace PersonalDiary.Api.Attributes
{
    public class ValidateRequestAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ModelState.Count == null || context.ModelState.IsValid) return;
            context.Result = new BadRequestObjectResult(new SerializableError(context.ModelState));
        }
    }
}
