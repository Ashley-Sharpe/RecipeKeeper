using RecipeKeeper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecipeKeeper.Data;
using static RecipeKeeper.Data.Ingredient;
using RecipeKeeper.service;

namespace RecipeKeeper.Controllers
{
    [Authorize]
    public class IngredientController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Ingredient
        public ActionResult Index()
        {
            var service = new IngredientService();
            var model = service.GetIngredients();
            
            return View(model);
        }
        //GET: Create Ingredient
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IngredientCreate model)
        {
            if (!ModelState.IsValid)
            {
               return View(model);
           
            }
            var service = new IngredientService();
            service.CreateIngredient(model);
            return RedirectToAction("Index");

         


            
        }

    }
}