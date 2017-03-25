using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class TournoiController : Controller
    {
        private ServiceReference1.ServiceClient service = new ServiceReference1.ServiceClient();

        // GET: Tournoi
        public ActionResult Index()
        {
            return View(service.GetAllTournois().Select(t => new Tournoi(t)).ToList());
        }

        // GET: Tournoi/Details/5
        public ActionResult Details(int id)
        {
            return View(new Tournoi(service.GetTournoiById(id)));
        }

        // GET: Tournoi/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tournoi/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                if (service.NewTournoi(collection["Nom"]))
                    return RedirectToAction("Index");
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Tournoi/Delete/5
        public ActionResult Delete(int id)
        {
            return View(new Tournoi(service.GetTournoiById(id)));
        }

        // POST: Tournoi/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                if (service.DeleteTournoiById(id))
                    return RedirectToAction("Index");
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
