using Microsoft.AspNet.Identity;
using RecipeKeeper.Data;
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
    [RoutePrefix("Recipe")]
    public class RecipeController : Controller
    {
        // GET: Recipe
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new RecipeService(userId);
            var model = service.GetRecipes();
            return View(model);
        }

        // GET : Create

        public ActionResult Create()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new IngredientService();
            List<Ingredient> ingredients = service.GetIngredientList().ToList();

            var query = from i in ingredients
                        select new SelectListItem()
                        {
                            Value = i.IngredientId.ToString(),
                            Text = i.IngredientName

                        };
            ViewBag.IngredientId = query;
            return View();
        }

        // THIS IS THE SEARCHABLE DROP DOWN LIST VIA JS - implement someday :D
        //    public JsonResult GetIngredient(string searchterm)
        //    {
        //    ApplicationDbContext context = new ApplicationDbContext();
        //    var dataList = context.Ingredients.ToList();
        //    if (searchterm != null)
        //    {
        //        dataList = context.Ingredients.Where(x => x.IngredientName.Contains(searchterm)).ToList();
        //    }

        //    var modifiedData = dataList.Select(x => new
        //    {
        //        id=x.IngredientId,
        //        text=x.IngredientName
        //    });
        //    return Json(modifiedData, JsonRequestBehavior.AllowGet);
        //    }
        //public JsonResult Save(string data)
        //{

        //    return Json(0, JsonRequestBehavior.AllowGet);
        //}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RecipeCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateRecipeService();


            if (service.CreateRecipe(model))
            {
                TempData["SaveResult"] = "Your recipe was created!";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Recipe could not be created.");
            return View(model);
        }
        public ActionResult Details(int id)
        {
            var svc = CreateRecipeService();
            var model = svc.GetRecipeById(id);

            return View(model);
        }
        [ActionName("EditRecipe")]
        public ActionResult Edit(int id)
        {
            var service = CreateRecipeService();
            var detail = service.GetRecipeById(id);

            var userId = Guid.Parse(User.Identity.GetUserId());



            var model =
            new RecipeEdit
            {
                RecipeId = detail.RecipeId,
                RecipeName = detail.RecipeName,
                RecipeType = detail.RecipeType,
                CuisineType = detail.CuisineType,
                PageNumber = detail.PageNumber,

            };
            return View(model);

        }
        //[Route("~/EditIngredients/{id}")]
        //[ActionName("EditIngredients")]
        [HttpGet]
        public ActionResult UpdateRecipeWithIngredients(int id)
        {
            var iservice = new IngredientService();
            List<Ingredient> ingredients = iservice.GetIngredientList().ToList();

            var query = from i in ingredients
                        select new SelectListItem()
                        {
                            Value = i.IngredientId.ToString(),
                            Text = i.IngredientName

                        };
            ViewBag.IngredientId = query;
            
            var service = CreateRecipeService();
            var detail = service.GetRecipeById(id);
            var model =
                new RecipeEdit
                {
                    RecipeId = detail.RecipeId,
                    RecipeName = detail.RecipeName,
                    Ingredients = detail.Ingredients,

                };
            return View(model);
        }

        //Post!

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditRecipe(int id, RecipeEdit model)
        {
            if (!ModelState.IsValid) return View(model);


            if (model.RecipeId != id)
            {
                ModelState.AddModelError("", "Id mismatch");
                return View(model);
            }
            var service = CreateRecipeService();

            if (service.UpdateRecipe(model))
            {
                TempData["SaveResult"] = "Your recipe was updated!";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your recipe could not be updated.");
            return View(model);
        }
        //[Route("~/EditIngredients/{id}")]
        //[ActionName("EditIngredients")]
        [HttpPost]
        public ActionResult UpdateRecipeWithIngredients(int id, RecipeEdit model)
        {
            if (!ModelState.IsValid) return View(model);


            if (model.RecipeId != id)
            {
                ModelState.AddModelError("", "Id mismatch");
                return View(model);
            }
            var service = CreateRecipeService();

            if (service.UpdateRecipeWithIngredients(model))
            {
                TempData["SaveResult"] = "Your recipe was updated!";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your recipe could not be updated.");
            return View();
        }


        public ActionResult Delete(int id)
        {
            var svc = CreateRecipeService();
            var model = svc.GetRecipeById(id);

            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateRecipeService();
            service.DeleteRecipe(id);
            TempData["SaveResult"] = "Your Recipe was deleted!";
            return RedirectToAction("Index");

        }
        private RecipeService CreateRecipeService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new RecipeService(userId);
            return service;
        }

    }
}
