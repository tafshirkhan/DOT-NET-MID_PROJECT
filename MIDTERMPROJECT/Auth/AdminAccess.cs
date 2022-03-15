using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MIDTERMPROJECT.Auth
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AdminAccess : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var authenticated = base.AuthorizeCore(httpContext);
            if (!authenticated)
            {
                return false;
            }
            if (httpContext.Session["Type"].ToString().Equals("Admin") || httpContext.Session["Type"].ToString().Equals("Business User"))
            {
                return true;
            }
            return false;
            //return base.AuthorizeCore(httpContext);
        }
    }
}