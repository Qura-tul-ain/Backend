using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using online;
using System.IO;
using online.Models;
using System.ComponentModel.DataAnnotations;

namespace online.Controllers
{
    public class ProductsController : Controller
    {
        private onlineEntities2 db = new onlineEntities2();

        // GET: Products
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product productss)
        {
            try {
                string filename = Path.GetFileNameWithoutExtension(productss.ImageFile.FileName);
                string extension = Path.GetExtension(productss.ImageFile.FileName);
                filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
                productss.Images = "~/images/" + filename;
                filename = Path.Combine(Server.MapPath("~/images/"), filename);
                productss.ImageFile.SaveAs(filename);

                using (onlineEntities2 db = new onlineEntities2())
                {
                    if (db.Products.Any(x => x.ProductName == productss.ProductName))
                    {
                        ViewBag.DuplicateMessage = "Product Already exists";
                        return View(productss);
                    }


                    db.Products.Add(productss);
                    db.SaveChanges();
                }                                                                                                                           
            }
            catch(Exception ex)
            {

            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Successful";
            return View("Index");
        }
        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ImageId,ProductName,ProductDescp,BidAmount,AuctionDate,Category,Images")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
