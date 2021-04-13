using RecipeKeeper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecipeKeeper.Controllers
{
    public class PantryController : Controller
    {
        // GET: Pantry
        public ActionResult Index()
        {
            var model = new PantryListItem[0];
            return View(model);
        }
    }
}