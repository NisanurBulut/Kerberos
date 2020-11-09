using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kerberos.Util.Filters
{
   public class IsValidActionFilter:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var errors = context.ModelState.Values.SelectMany(a => a.Errors).Select(a => a.ErrorMessage);

            if(!context.ModelState.IsValid)
            {
                // status code 400
                context.Result = new BadRequestObjectResult(context.ModelState);
            }
            
        }
    }
}
