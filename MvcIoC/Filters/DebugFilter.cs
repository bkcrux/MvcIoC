using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcIoC.Filters
{
    public class DebugFilter : ActionFilterAttribute
    {
        private IDebugMessageService debugMessageService;

        public DebugFilter(IDebugMessageService dms)
        {
            debugMessageService = dms;
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            filterContext.HttpContext.Response.Write(DebugMessageService.Message);
             
            base.OnActionExecuted(filterContext);
        }

        public interface IDebugMessageService
        {
            string Message { get; }
        }

        public class DebugMessageService : IDebugMessageService
        {
            public string Message
            {
                get { return DateTime.Now.ToString(); }
            }

        }
    }
}