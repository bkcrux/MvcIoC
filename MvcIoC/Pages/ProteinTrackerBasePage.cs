using Microsoft.Practices.Unity;
using MvcIoC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcIoC.Pages
{
    public class ProteinTrackerBasePage : WebViewPage
    {
        [Dependency]
        public IAnalyticsService AnalyticsService { get; set; }

        public override void Execute()
        {
            
        }
    }
}