using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using work_01.Models;

namespace work_01.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        RestuarentDbContext db = new RestuarentDbContext();
        public ActionResult Index()
        {
            return View(db.Orders.ToList());
        }
    }
}