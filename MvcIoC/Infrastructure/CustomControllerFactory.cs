﻿using MvcIoC.Controllers;
using MvcIoC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;

namespace MvcIoC.Infrastructure
{
    public class CustomControllerFactory : IControllerFactory
    {
        public IController CreateController(RequestContext requestContext, string controllerName)
        {
            if (controllerName.ToLower().StartsWith("protein"))
            {
                var repository = new ProteinRepository();
                var controller = new ProteinTrackerController(new ProteinTrackerService(repository));

                return controller;
            }
            
            var defaultFac = new DefaultControllerFactory();
            return defaultFac.CreateController(requestContext, controllerName);

        }

        public SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, string controllerName)
        {
            return SessionStateBehavior.Default;
        }

        public void ReleaseController(IController controller)
        {
            var disposable = controller as IDisposable;
            if (disposable != null)
            { 
                disposable.Dispose();
            }

        }
    }
}