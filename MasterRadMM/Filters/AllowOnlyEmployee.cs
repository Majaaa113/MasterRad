using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace MasterRadMM.Filters
{
    public sealed class AllowOnlyEmployee : Attribute, IActionFilter
    {
        private readonly IHttpContextAccessor _httpContext;

        public AllowOnlyEmployee(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (_httpContext.HttpContext.Session.GetInt32("EmployeeId") == null)
            {
                _httpContext.HttpContext.Response.Redirect("/Account/Login");
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            
        }
    }
}
