using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using work_01.Models;

namespace work_01.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category

        RestuarentDbContext db = new RestuarentDbContext();
        public ActionResult Index()
        {
            return View(db.ItemCategories.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ItemCategory category)
        {
            if (ModelState.IsValid)
            {

                db.ItemCategories.Add(category);
                db.SaveChanges();
            }

            return PartialView("_success"); 
        }

    }
}