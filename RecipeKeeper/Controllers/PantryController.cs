using RecipeKeeper.Models;
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
            var model = new PantryListItem[0];
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
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }


    }

}