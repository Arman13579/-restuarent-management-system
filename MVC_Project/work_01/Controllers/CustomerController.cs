using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using work_01.Models;

namespace work_01.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer

        RestuarentDbContext db = new RestuarentDbContext();
        public ActionResult Index()
        {


            return View(db.Customers.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Customer cr)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(cr);
                db.SaveChanges();
            }


            return View(cr);
        }
    }
}