using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace APIDemo
{
    public class BasicAuthenticationAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            else
            {
                string authenticationToken = actionContext.Request.Headers.Authorization.Parameter;
                string decodeAuthenticationToken =
                    Encoding.UTF8.GetString(Convert.FromBase64String(authenticationToken));
                string[] usernameAndPasswordArray = decodeAuthenticationToken.Split(':');
                string userName = usernameAndPasswordArray[0];
                string password = usernameAndPasswordArray[1];

                if(EmployeeSecurity.Login(userName,password))
                {
                    //Thread.CurrentPrincipal= new GenericPrincipal(new GenericIdentity(userName),null);
                }
                else
                {
                    actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                }
            }
        }
    }
}