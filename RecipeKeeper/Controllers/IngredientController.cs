using RecipeKeeper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecipeKeeper.Data;

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
            var service = CreateIngredientService();
            var model = service.GetIngredients();

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IngredientCreate model)
        {
            if (!ModelState.IsValid) return View(model);
         
             var service = CreateIngredientService();
           
           
            if (service.CreateIngredient(model)) 
            {
                TempData["SaveResult"] = "Your ingredient was created.";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Ingredient could not be created.");
            return View(model);
        } 

        public ActionResult Detail(int id)
        {
            var svc = CreateIngredientService();
            var model = svc.GetIngredientById(id);

            return View(model);
        }

        public ActionResult GetRecipeByIngredient(int id)
        {
            var svc = CreateIngredientService();
            var model = svc.GetRecipesByIngredient(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateIngredientService();
            var detail = service.GetIngredientById(id);
            var model =
                new IngredientEdit
                {
                    IngredientId = detail.IngredientId,
                    IngredientName = detail.IngredientName,
                    IngredientType = detail.IngredientType
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IngredientEdit model)
        {
            if(!ModelState.IsValid)return View(model);

            if(model.IngredientId != id)
            {
                ModelState.AddModelError("", "Id MisMatch");
                return View(model);
            }
            var service = CreateIngredientService();

            if (service.UpdateIngredient(model))
            {
                TempData["SaveResult"] = "Your ingredient was updated!";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your ingredient could not be updated.");
            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateIngredientService();
            var model = svc.GetIngredientById(id);

            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateIngredientService();
            service.DeleteIngredient(id);
            TempData["SaveResult"] = "Your ingredient was deleted!";
            return RedirectToAction("Index");

        }

        private static IngredientService CreateIngredientService()
        {
            return new IngredientService();
        }

        //GET: Create Ingredient
        public ActionResult Create()
        {
            return View();
        }

       
        
    }
}