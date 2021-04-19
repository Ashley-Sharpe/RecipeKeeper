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
        public ActionResult Details(int id)
        {
            var svc = CreatePantryService();
            var model = svc.GetPantryDetailsById(id);

            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreatePantryService();
            var detail = service.GetPantryDetailsById(id);
            var model = new PantryEdit
            {
                PantryId = detail.PantryId,
                IngredientName = detail.IngredientName,
                InStock = detail.InStock,
                Location = detail.Location,
                Quantity = detail.Quantity
            };
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