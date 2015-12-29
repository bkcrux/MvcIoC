using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcIoC.Controllers;
using System.Web.Mvc;
using MvcIoC.Models;

namespace MvcIoC.Tests.Controllers
{
    [TestClass]
    public class ProteinTrackerControllerTest
    {
        [TestMethod]
        public void WhenNothingHasHappenedGoalAndTotalAreZero()
        {
            ProteinTrackerController controller = new ProteinTrackerController(new StubTracking());

            ViewResult result = controller.Index() as ViewResult;

            Assert.AreEqual(0, result.ViewBag.Total);
            Assert.AreEqual(0, result.ViewBag.Goal);

        }


        [TestMethod]
        public void WhenTotalIsNonZero_AndAmountAdded_TotalIsIncreased()
        {
            var service = new StubTracking();
            service.Total = 10;

            ProteinTrackerController controller = new ProteinTrackerController(service);

            ViewResult result = controller.AddProtein(15) as ViewResult;

            Assert.AreEqual(25, result.ViewBag.Total);
            Assert.AreEqual(0, result.ViewBag.Goal);


        }

        public class StubTracking : IProteinTrackerService
        {
            public int Goal
            {
                get; set;
            }

            public int Total
            {
                get; set;
            }

            public void AddProtein(int amount)
            {
                Total += amount;
            }
        }

    }
}
