using CORE.NG.EXCEPTION;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace CORE.NG.API.Filters
{
    public class Validator : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!filterContext.ModelState.IsValid)
            {
                string message = string.Join(" | ", filterContext.ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
                throw new ValidationException(message);
            }
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {

        }
    }
}