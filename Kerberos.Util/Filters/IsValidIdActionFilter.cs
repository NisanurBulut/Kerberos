using Kerberos.Business.Interfaces;
using Kerberos.Entities.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Kerberos.Util.Filters
{
    public class IsValidIdActionFilter<TEntity> : IActionFilter where TEntity : class, ITable, new()
    {
        private readonly IBaseService<TEntity> _baseService;
        public IsValidIdActionFilter(IBaseService<TEntity> baseService)
        {
            _baseService = baseService;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var dictionary = context.ActionArguments.Where(a => a.Key == "id").FirstOrDefault();
            var checkedId = (int)dictionary.Value;
            var entity = _baseService.GetByIdAsync(checkedId).Result;
            if (entity == null)
                context.Result = new NotFoundObjectResult($"{checkedId} idli nesne bulunamadı.");
        }
    }
}
