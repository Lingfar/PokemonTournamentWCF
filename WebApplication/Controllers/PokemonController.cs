using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class PokemonController : Controller
    {
        private ServiceReference1.ServiceClient service = new ServiceReference1.ServiceClient();

        // GET: Pokemon
        public ActionResult Index()
        {
            return View(service.GetAllPokemons().Select(p => new Pokemon(p)).ToList());
        }

        // GET: Pokemon/Details/5
        public ActionResult Details(int id)
        {
            return View(new Pokemon(service.GetPokemonById(id)));
        }

        // GET: Pokemon/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pokemon/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                ServiceReference1.PokemonComposite p = new ServiceReference1.PokemonComposite();
                p.Nom = collection["Nom"];
                p.Type = (ServiceReference1.ETypeElement) Enum.Parse(typeof(ServiceReference1.ETypeElement), collection["Type"]);
                p.Caracteristique = new ServiceReference1.CaracterisiqueComposite();

                if (service.AddNewPokemon(p))
                    return RedirectToAction("Index");
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Pokemon/Edit/5
        public ActionResult Edit(int id)
        {
            return View(new Pokemon(service.GetPokemonById(id)));
        }

        // POST: Pokemon/Edit/5
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

        // GET: Pokemon/Delete/5
        public ActionResult Delete(int id)
        {
            return View(new Pokemon(service.GetPokemonById(id)));
        }

        // POST: Pokemon/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                if (service.DeletePokemonById(id))
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
