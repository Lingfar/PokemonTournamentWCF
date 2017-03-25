using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class MatchController : Controller
    {
        private ServiceReference1.ServiceClient service = new ServiceReference1.ServiceClient();

        // GET: Match
        public ActionResult Index()
        {
            return View(service.GetAllMatches().Select(m => new Match(m)).ToList());
        }

        // GET: Match/Details/5
        public ActionResult Details(int id)
        {
            return View(new Match(service.GetMatchById(id)));
        }        
    }
}
