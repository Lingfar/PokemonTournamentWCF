using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class StadeController : Controller
    {
        private ServiceReference1.ServiceClient service = new ServiceReference1.ServiceClient();
        private ServiceReference1.StadeComposite ConvertFormCollectionToStadeComposite(FormCollection collection)
        {
            ServiceReference1.StadeComposite s = new ServiceReference1.StadeComposite();
            s.Nom = collection["Nom"];
            s.Type = (ServiceReference1.ETypeElement)Enum.Parse(typeof(ServiceReference1.ETypeElement), collection["Type"]);
            s.NbPlaces = Convert.ToInt32(collection["NbPlaces"]);
            s.Attaque = Convert.ToInt32(collection["Attaque"]);
            s.Defense = Convert.ToInt32(collection["Defense"]);
            return s;
        }
        private ServiceReference1.StadeComposite ConvertFormCollectionToStadeComposite(int id, FormCollection collection)
        {
            ServiceReference1.StadeComposite s = ConvertFormCollectionToStadeComposite(collection);
            s.Id = id;
            return s;
        }

        // GET: Stade
        public ActionResult Index()
        {
            return View(service.GetAllStades().Select(s => new Stade(s)).ToList());
        }

        // GET: Stade/Details/5
        public ActionResult Details(int id)
        {
            return View(new Stade(service.GetStadeById(id)));
        }

        // GET: Stade/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Stade/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                if (service.AddNewStade(ConvertFormCollectionToStadeComposite(collection)))
                    return RedirectToAction("Index");
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Stade/Edit/5
        public ActionResult Edit(int id)
        {
            return View(new Stade(service.GetStadeById(id)));
        }

        // POST: Stade/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                if (service.UpdateStade(ConvertFormCollectionToStadeComposite(id, collection)))
                    return RedirectToAction("Index");
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Stade/Delete/5
        public ActionResult Delete(int id)
        {
            return View(new Stade(service.GetStadeById(id)));
        }

        // POST: Stade/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                if (service.DeleteStadeById(id))
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
