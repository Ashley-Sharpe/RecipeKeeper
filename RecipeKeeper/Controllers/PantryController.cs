using Microsoft.AspNet.Identity;
using RecipeKeeper.Models;
using RecipeKeeper.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecipeKeeper.Controllers
{
    [Authorize]
    public class PantryController : Controller
    {
        // GET: Pantry
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PantryService(userId);
            var model = service.GetPantry();

            return View(model);
        }
        //GET
        public ActionResult Create()
        {
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PantryCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreatePantryService();

            if (service.CreatePantry(model))
            {
                TempData["SaveResult"] = "Your pantry was created.";
                return RedirectToAction("Index");
            }
            
            ModelState.AddModelError("", "Note could not be created.");

            return View(model);

        }

        private PantryService CreatePantryService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PantryService(userId);
            return service;
        }

    }

}