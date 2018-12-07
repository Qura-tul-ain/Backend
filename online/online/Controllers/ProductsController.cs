//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.Linq;
//using System.Net;
//using System.Web;
//using System.Web.Mvc;
//using online;
//using System.IO;
//using online.Models;
//using System.ComponentModel.DataAnnotations;

//namespace online.Controllers
//{
//    public class ProductsController : Controller
//    {
//        private onlineEntities2 db = new onlineEntities2();

//        // GET: Products
//        public ActionResult Index()
//        {
//            //    Product p = new Product();
//            //    using (onlineEntities2 db = new onlineEntities2())
//            //    {
//            //        p = db.Products.Where(x=>x.ImageId==id).FirstOrDefault();
//            //    }
//            //    return View(p);
//            List<Product> lists = new List<Product>();
//            lists = db.Products.ToList();
//            return View(lists);

//        }


//        // GET: Products/Details/5
//        public ActionResult Details(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Product product = db.Products.Find(id);
//            if (product == null)
//            {
//                return HttpNotFound();
//            }
//            return View(product);
//        }

//        // GET: Products/Create
//        public ActionResult Create()
//        {
//            return View();
//        }

//        // POST: Products/Create
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create(ProductViewModel productss)
//        {
//            try {
//                string filename = Path.GetFileNameWithoutExtension(productss.ImageFile.FileName);
//                string extension = Path.GetExtension(productss.ImageFile.FileName);
//                filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
//                productss.Images = "~/images/" + filename;
//                filename = Path.Combine(Server.MapPath("~/images/"), filename);
//                productss.ImageFile.SaveAs(filename);

//                using (onlineEntities2 db = new onlineEntities2())
//                {
//                    if (db.Products.Any(x => x.ProductName == productss.ProductName))
//                    {
//                        ViewBag.DuplicateMessage = "Product Already exists";
//                        return View(productss);
//                    }
//                    Product p = new Product();
//                    p.ProductName = productss.ProductName;
//                    p.ProductDescp = productss.ProductDescp;
//                    p.ImageId = productss.ImageId;
//                    p.Images = productss.Images;
//                    p.Category = productss.Category;
//                    p.BidAmount = productss.BidAmount;
//                    p.AuctionDate = productss.AuctionDate;


//                    db.Products.Add(p);
//                    db.SaveChanges();
//                }
//            }
//            catch (Exception ex)
//            {

//            }
//            ModelState.Clear();
//            ViewBag.SuccessMessage = "Successful";
//            return RedirectToAction("Index");
//        }
//        // GET: Products/Edit/5
//        public ActionResult Edit(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Product product = db.Products.Find(id);
//            if (product == null)
//            {
//                return HttpNotFound();
//            }
//            return View(product);
//        }

//        // POST: Products/Edit/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit([Bind(Include = "ImageId,ProductName,ProductDescp,BidAmount,AuctionDate,Category,Images")] Product product)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(product).State = EntityState.Modified;
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            return View(product);
//        }

//        // GET: Products/Delete/5
//        public ActionResult Delete(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Product product = db.Products.Find(id);
//            if (product == null)
//            {
//                return HttpNotFound();
//            }
//            return View(product);
//        }

//        // POST: Products/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(int id)
//        {
//            Product product = db.Products.Find(id);
//            db.Products.Remove(product);
//            db.SaveChanges();
//            return RedirectToAction("Index");
//        }

//        public ActionResult Display()
//        {
//            List<Product> p = new List<Product>();
//            Product p1 = new Product();
//            p = db.Products.Where(x => x.Category == "2").ToList();
//            return View(p);

//        }

//        //public ActionResult EnterYourAmount( Product collection)
//        //{
//        //    try
//        //    {
//        //        int amount = Convert.ToInt32(collection.amount);
//        //        //List<YourAmount> lists = new List<YourAmount>();
//        //        //Product pp = new Product();
//        //        List<YourAmount> lists = new List<YourAmount>();
//        //        //lists = db.YourAmounts.Where(x => x.ImageId == collection.ImageId).ToList();


//        //        YourAmount obj = new YourAmount();
//        //        obj.ImageId = collection.ImageId;
//        //        obj.YourAmount1 = amount;
//        //        //obj.Id = " 8f7ac670 - 34b7 - 4b6d - 8b6c - e9c650d6e7e3";
//        //        obj.Id = "12c";
//        //        db.YourAmounts.Add(obj);
//        //        db.SaveChanges();

//        //    }catch(Exception ex)
//        //    {
//        //        return View(ex);
//        //    }
//        //    ModelState.Clear();
//        //    return View("Index");
//        //}

//        public ActionResult EnterAmount()
//        {
//            return View();

//        }
//        [HttpPost]

//        public ActionResult EnterAmount(Product collection)
//        { 
//             YourAmount obj = new YourAmount();

//            try
//            {

//                 if (collection.amount > collection.BidAmount )
//                {
//                    //YourAmount obj = new YourAmount();
//                    obj.YourAmount1 = collection.amount;
//                    obj.ImageId = collection.ImageId;
//                    obj.Id = "8f7ac670-34b7-4b6d-8b6c-e9c650d6e7e3";
//                    db.YourAmounts.Add(obj);
//                    db.SaveChanges();
                
//                }
//                else
//                {
//                    ViewBag.amountError= "Amount should be greater than Bid Amount.";
//                }    

//            }
//            catch(Exception ex)
//            {

//            }
//            //Biding o = new Biding();
//            //o.ImageId = obj.ImageId;
//            //o.YourAmount1 = obj.YourAmount1;
//            //o.Id = obj.Id;
//            //o.AmountId = obj.AmountId;
//            return View();
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }
//    }
//}