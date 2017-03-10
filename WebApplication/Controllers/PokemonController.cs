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

        private ServiceReference1.PokemonComposite ConvertFormCollectionToPokemonComposite(FormCollection collection)
        {
            ServiceReference1.PokemonComposite p = new ServiceReference1.PokemonComposite();
            p.Nom = collection["Nom"];
            p.Type = (ServiceReference1.ETypeElement)Enum.Parse(typeof(ServiceReference1.ETypeElement), collection["Type"]);
            p.Caracteristique = new ServiceReference1.CaracterisiqueComposite();
            p.Caracteristique.PV = Convert.ToInt32(collection["Caracteristiques.PV"]);
            p.Caracteristique.Attaque = Convert.ToInt32(collection["Caracteristiques.Attaque"]);
            p.Caracteristique.Defense = Convert.ToInt32(collection["Caracteristiques.Defense"]);
            p.Caracteristique.Vitesse = Convert.ToInt32(collection["Caracteristiques.Vitesse"]);
            p.Caracteristique.Esquive = Convert.ToInt32(collection["Caracteristiques.Esquive"]);
            return p;
        }

        private ServiceReference1.PokemonComposite ConvertFormCollectionToPokemonComposite(int id, int caracId, FormCollection collection)
        {
            ServiceReference1.PokemonComposite p = ConvertFormCollectionToPokemonComposite(collection);
            p.Id = id;
            p.Caracteristique.Id = caracId;
            return p;
        }

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
                if (service.AddNewPokemon(ConvertFormCollectionToPokemonComposite(collection)))
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
        public ActionResult Edit(int id, int caracId, FormCollection collection)
        {
            try
            {
                if (service.UpdatePokemon(ConvertFormCollectionToPokemonComposite(id, caracId, collection)))
                    return RedirectToAction("Index");
                else
                    return View();
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
