using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using work_01.Models;

namespace work_01.Controllers
{
    public class OrderDetailController : Controller
    {
        // GET: OrderDetail
        RestuarentDbContext db = new RestuarentDbContext();
        public ActionResult Index()
        {
            return View(db.OrderDetails.ToList());
        }
    }
}