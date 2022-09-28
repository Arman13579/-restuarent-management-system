using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using work_01.Models;

namespace work_01.Controllers
{
    public class TransactionController : Controller
    {

        RestuarentDbContext db = new RestuarentDbContext();
        // GET: Transaction
        public ActionResult Index()
        {
            return View(db.Transactions.ToList());
        }
    }
}