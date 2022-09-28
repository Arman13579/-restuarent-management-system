using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using work_01.Models;
using work_01.ViewModels;
using System.IO;

namespace work_01.Controllers
{
    public class ItemController : Controller
    {
        // GET: Item

        RestuarentDbContext db = new RestuarentDbContext();
        public ActionResult Index()
        {
            return View(db.Items.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.categories = new SelectList(db.ItemCategories, "ItemCategoryId", "CategoryName");
            return View();
        }
        [HttpPost]
        public ActionResult Create(ItemViewModel tvm)
        {
            if (ModelState.IsValid)
            {
                if (tvm.Picture != null)
                {
                    string filePath = Path.Combine("~/Images", Guid.NewGuid().ToString() + Path.GetExtension(tvm.Picture.FileName));
                    tvm.Picture.SaveAs(Server.MapPath(filePath));

                    Item item = new Item
                    {
                       ItemName = tvm.ItemName,
                       ItemPrice = tvm.ItemPrice,
                       Quantity = tvm.Quantity,
                       PurchaseDate = tvm.PurchaseDate,
                       IsAvailable = tvm.IsAvailable,
                       Category = tvm.Category,
                       ItemPicture = filePath
                      
                    };
                    db.Items.Add(item);
                    db.SaveChanges();
                    return PartialView("_success");
                }
            }
            ViewBag.categories = new SelectList(db.ItemCategories, "ItemCategoryId", "CategoryName");
            return PartialView("_error");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();

            }
            ItemViewModel tvm = new ItemViewModel
            {
                ItemId = item.ItemId,
                ItemName=item.ItemName,
                ItemPrice = item.ItemPrice,
                Category = (int)item.Category,
                Quantity = item.Quantity,
                PurchaseDate = item.PurchaseDate,
                IsAvailable = item.IsAvailable,
                PicturePath = item.ItemPicture
            };
            ViewBag.categories = new SelectList(db.ItemCategories, "ItemCategoryId", "CategoryName");

            return View(tvm);
        }

        [HttpPost]
        public ActionResult Edit(ItemViewModel tvm)
        {
            if (ModelState.IsValid)
            {
                string filePath = tvm.PicturePath;
                if (tvm.Picture != null)
                {
                    filePath = Path.Combine("~/Images", Guid.NewGuid().ToString() + Path.GetExtension(tvm.Picture.FileName));
                    tvm.Picture.SaveAs(Server.MapPath(filePath));

                    Item item = new Item
                    {
                        ItemId = tvm.ItemId,
                        ItemName = tvm.ItemName,
                        ItemPrice = tvm.ItemPrice,
                        Quantity = tvm.Quantity,
                        PurchaseDate = tvm.PurchaseDate,
                        IsAvailable = tvm.IsAvailable,
                        Category = tvm.Category,
                        ItemPicture = filePath
                    };
                    db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    //return RedirectToAction("Index");
                }
                else
                {
                    Item item = new Item
                    {

                        ItemName = tvm.ItemName,
                        ItemPrice = tvm.ItemPrice,
                        Quantity = tvm.Quantity,
                        PurchaseDate = tvm.PurchaseDate,
                        IsAvailable = tvm.IsAvailable,
                        Category = tvm.Category,
                        ItemPicture = filePath
                    };
                    db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    //return RedirectToAction("Index");
                }
            }
            ViewBag.categories = new SelectList(db.ItemCategories, "ItemCategoryId", "CategoryName");
            return PartialView("_success");
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            Item item = db.Items.Find(id);
            string file_name = item.ItemPicture;
            string path = Server.MapPath(file_name);
            FileInfo file = new FileInfo(path);
            if (file.Exists)
            {
                file.Delete();
            }
            db.Items.Remove(item);
            db.SaveChanges();
            return PartialView("_deleteSuccess");
        }



    }


}