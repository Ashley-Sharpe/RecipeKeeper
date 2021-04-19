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
    public class BookController : Controller
    {
        
        // GET: Book
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new BookService(userId);
            var model = service.GetBooks();

            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            
            var service = CreateBookService();

           if (service.CreateBook(model))
            {
                TempData["SaveResult"] = "Your book was saved sucessfully!";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("Fail", "Book could not be created.");
            return View(model);   
        }
        public ActionResult Details(int id)
        {
            var svc = CreateBookService();
            var model = svc.GetBookById(id);

            return View(model);
        }

        private BookService CreateBookService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new BookService(userId);
            return service;
        }

    }
}