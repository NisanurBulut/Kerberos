using Kerberos.DataTransferObject;
using Kerberos.Util.Builders.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Kerberos.Util.Filters
{
    public class JwtAuthorizeHelper
    {
        public static void CheckUserRole(AppUserDto activeUser, string roles, ActionExecutingContext context)
        {

            if (!string.IsNullOrEmpty(roles))
            {
                Status status = null;
                if (roles.Contains(","))
                {
                    StatusBuilderDirector statusBuilderDirector =
                        new StatusBuilderDirector(new MultiRolestatusBuilder());
                    status = statusBuilderDirector.CallGenerateStatus(activeUser, roles);
                }
                else
                {
                    StatusBuilderDirector statusBuilderDirector =
                      new StatusBuilderDirector(new SingleRolestatusBuilder());
                    status = statusBuilderDirector.CallGenerateStatus(activeUser, roles);
                }
                CheckStatus(status, context);
            }
        }
        private static void CheckStatus(Status status, ActionExecutingContext context)
        {
            if (!status.AccessStatus)
            {
                context.Result = new RedirectToActionResult("SignIn", "Account", null);
            }
        }
        public static AppUserDto GetActiveUser(HttpResponseMessage responseMessage)
        {
            return JsonConvert.DeserializeObject<AppUserDto>(responseMessage.Content.ReadAsStringAsync().Result);
        }
    }
}
