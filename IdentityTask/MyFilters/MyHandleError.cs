using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdentityTask.MyFilters
{
    public class MyHandleError :ActionFilterAttribute,IExceptionFilter
    {
      
        public void OnException(ExceptionContext filterContext)
        {
            ViewResult error = new ViewResult() { ViewName = "~/Views/Shared/404.html" };
            filterContext.Result = error;
        }

        
    }
}