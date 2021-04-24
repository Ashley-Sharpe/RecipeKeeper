﻿using Microsoft.AspNet.Identity;
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
            return View();
        }
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
        public ActionResult Edit(int id)
        {
            var service = CreateRecipeService();
            var detail = service.GetRecipeById(id);
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

        private RecipeService CreateRecipeService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new RecipeService(userId);
            return service;
        }

    }
}