﻿using RecipeKeeper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecipeKeeper.Controllers
{
    [Authorize]
    public class IngredientController : Controller
    {
        // GET: Ingredient
        public ActionResult Index()
        {
            var model = new IngredientListItem[0];
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
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }

    }
}