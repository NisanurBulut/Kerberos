using Kerberos.DataTransferObject;
using Kerberos.Entities.Concrete;
using Kerberos.Util.Builders.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Kerberos.Util.Filters
{
    public class JwtAuthorize : ActionFilterAttribute
    {
        public string Roles { get; set; }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var token = context.HttpContext.Session.GetString("token");
            if (string.IsNullOrEmpty(token))
            {
                context.Result = new RedirectToActionResult("SignIn", "Account", null);
            }
           
            using var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage responseMessage = httpClient.GetAsync("http://localhost:56789/api/Auth/ActiveUser").Result;
            if (responseMessage.StatusCode == HttpStatusCode.OK)
            {
               var activeUser = JwtAuthorizeHelper.GetActiveUser(responseMessage);
                JwtAuthorizeHelper.CheckUserRole(activeUser,Roles,context);
                // admin 
                // admin, member

                
            }
            else if (responseMessage.StatusCode == HttpStatusCode.Unauthorized)
            {
                context.HttpContext.Session.Remove("token");
                context.Result = new RedirectToActionResult("SignIn", "Account", null);
            }
            else
            {
                var statusCode = responseMessage.StatusCode.ToString();
                context.Result = new RedirectToActionResult("ApiError", "Account", new { code = statusCode });
            }
        }
    }
}
