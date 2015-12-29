using MvcIoC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcIoC.Controllers
{
    public class ProteinTrackerController : Controller
    {
        private IProteinTrackerService proteinTrackingService;

        public ProteinTrackerController(IProteinTrackerService pts)
        {
            proteinTrackingService = pts;
        }

        
        // GET: ProteinTracker
        public ActionResult Index()
        {
            ViewBag.Total = proteinTrackingService.Total;
            ViewBag.Goal = proteinTrackingService.Goal;

            return View();
        }


        // POST: ProteinTracker/AddProtein
        [HttpPost]
        public ActionResult AddProtein(int amount)
        {
            proteinTrackingService.AddProtein(amount);
            ViewBag.Total = proteinTrackingService.Total;
            ViewBag.Goal = proteinTrackingService.Goal;

            return View("Index");
        }

        // GET: ProteinTracker/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProteinTracker/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProteinTracker/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ProteinTracker/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProteinTracker/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ProteinTracker/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProteinTracker/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
