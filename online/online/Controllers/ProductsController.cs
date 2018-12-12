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
        private onlineEntities db = new onlineEntities();

        // GET: Products
        public ActionResult Index()
        {
            //    Product p = new Product();
            //    using (onlineEntities2 db = new onlineEntities2())
            //    {
            //        p = db.Products.Where(x=>x.ImageId==id).FirstOrDefault();
            //    }
            //    return View(p);
            List<Product> lists = new List<Product>();
            lists = db.Products.ToList();
            return View(lists);

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
            //db.Products.Where(x => x.Category == "Fashion").ToList();
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
        public ActionResult Create(ProductViewModel productss)
        {
            try
            {
                string filename = Path.GetFileNameWithoutExtension(productss.ImageFile.FileName);
                string extension = Path.GetExtension(productss.ImageFile.FileName);
                filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
                productss.Images = "~/images/" + filename;
                filename = Path.Combine(Server.MapPath("~/images/"), filename);
                productss.ImageFile.SaveAs(filename);

                using (onlineEntities db = new onlineEntities())
                {
                    if (db.Products.Any(x => x.ProductName == productss.ProductName))
                    {
                        ViewBag.DuplicateMessage = "Product Already exists";
                        return View(productss);
                    }
                    Product p = new Product();
                    p.ProductName = productss.ProductName;
                    p.ProductDescp = productss.ProductDescp;
                    p.ImageId = productss.ImageId;
                    p.Images = productss.Images;
                    p.Category = productss.Category;
                    p.BidAmount = productss.BidAmount;
                    p.AuctionDate = productss.AuctionDate;
                    p.Id = 12345;

                    db.Products.Add(p);
                    db.SaveChanges();
                }
                //var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                //var result = await UserManager.CreateAsync(user, model.Password);
            }
            catch (Exception ex)
            {
                return View(ex);
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Successful";
            return RedirectToAction("Index");
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
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                product.Id = 123;
                db.Entry(product).State = EntityState.Modified;

                db.SaveChanges();
              
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

        public ActionResult Display()
        {
            List<Product> p = new List<Product>();
            Product p1 = new Product();
            p = db.Products.Where(x => x.Category == "Furniture").ToList();
            return View(p);

        }

        public ActionResult Displaycars()
        {
            List<Product> p = new List<Product>();
            Product p1 = new Product();
            p = db.Products.Where(x => x.Category == "Cars").ToList();
            return View(p);

        }

        public ActionResult Displayhouses()
        {
            List<Product> p = new List<Product>();
            Product p1 = new Product();
            p = db.Products.Where(x => x.Category == "Houses").ToList();
            return View(p);

        }
        public ActionResult DisplayFashion()
        {
            List<Product> p = new List<Product>();
            Product p1 = new Product();
            p = db.Products.Where(x => x.Category == "Fashion").ToList();
            return View(p);

        }
        public ActionResult DisplayArt()
        {
            List<Product> p = new List<Product>();
            Product p1 = new Product();
            p = db.Products.Where(x => x.Category == "Art").ToList();
            return View(p);

        }

        //public ActionResult EnterYourAmount( Product collection)
        //{
        //    try
        //    {
        //        int amount = Convert.ToInt32(collection.amount);
        //        //List<YourAmount> lists = new List<YourAmount>();
        //        //Product pp = new Product();
        //        List<YourAmount> lists = new List<YourAmount>();
        //        //lists = db.YourAmounts.Where(x => x.ImageId == collection.ImageId).ToList();


        //        YourAmount obj = new YourAmount();
        //        obj.ImageId = collection.ImageId;
        //        obj.YourAmount1 = amount;
        //        //obj.Id = " 8f7ac670 - 34b7 - 4b6d - 8b6c - e9c650d6e7e3";
        //        obj.Id = "12c";
        //        db.YourAmounts.Add(obj);
        //        db.SaveChanges();

        //    }catch(Exception ex)
        //    {
        //        return View(ex);
        //    }
        //    ModelState.Clear();
        //    return View("Index");
        //}

        public ActionResult EnterAmount()
        {
            return View();

        }
        [HttpPost]

        public ActionResult EnterAmount(Product collection)
        {
            YourAmount obj = new YourAmount();

            try
            {
                List<YourAmount> gooduser = new List<YourAmount>();
                if (collection.amount > collection.BidAmount)
                {
                    foreach(var a in db.YourAmounts)
                    {
                        if(a.ImageId==collection.ImageId)
                        {
                            gooduser.Add(a);
                        }
                    }
                    int i = 1;
                    foreach(var b in gooduser)
                    {
                        if(b.YourAmount1 > collection.amount)
                        {
                            i = 0;
                        }
                    }
                    if (i == 1)
                    {

                        //YourAmount obj = new YourAmount();
                        obj.YourAmount1 = collection.amount;
                        obj.ImageId = collection.ImageId;
                        obj.Id = ViewBag.id;
                        db.YourAmounts.Add(obj);
                        db.SaveChanges();
                    }
                    else
                    {
                        ViewBag.amountError = "Amount should be greater than all user's Bid Amount.";
                    }
                }
                else
                {
                    ViewBag.amountError = "Amount should be greater than Bid Amount.";
                }

            }
            catch (Exception ex)
            {

            }
            //Biding o = new Biding();
            //o.ImageId = obj.ImageId;
            //o.YourAmount1 = obj.YourAmount1;
            //o.Id = obj.Id;
            //o.AmountId = obj.AmountId;
            return View();
        }
        // view all users ,bid on any product..

        public ActionResult Allusers(int? id)
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


            //return View(product);
            //db.Products.Where(x => x.Category == "Fashion").ToList();
            BidingDetails obj = new BidingDetails();
            List<YourAmount> selectiveuser = new List<YourAmount>();
            List<RegisteredUser> u = new List<RegisteredUser>();
            //obj.pro = db.Products.Where(x => x.ImageId == product.ImageId).ToList();

            foreach (var a in db.YourAmounts)
            {
                if (a.ImageId == product.ImageId)
                {
                    selectiveuser.Add(a);
                }
            }

            foreach (var a in selectiveuser)
            {
                foreach (var b in db.RegisteredUsers)
                {
                    if (a.Id == b.Id)
                    {
                        u.Add(b);
                    }
                }


            }
            obj.user = u;
            obj.pro = db.Products.Where(x => x.ImageId == product.ImageId).ToList();
            obj.bid = db.YourAmounts.Where(x => x.ImageId == product.ImageId).ToList();
            return View(obj);
    }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        //public async Task<ActionResult> Register(RegisterViewModel model)
        //{
        //	if (ModelState.IsValid)
        //	{

        //if (result.Succeeded)
        //{
        //	await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

        // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
        // Send an email with this link
        // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
        // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
        // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

        //			onlineEntities db = new onlineEntities();
        //			RegisteredUser user4 = new RegisteredUser();
        //			var userdbmodel = db.RegisteredUsers.Where(a => a.Email.Equals(model.Email)).FirstOrDefault();
        //			user4.Name = model.Name;
        //			user4.Email = model.Email;
        //			user4.CNIC = model.CNIC;
        //			user4.Adress = model.Address;
        //			user4.Password = model.Password;

        //			//user4.FK_R_ID = userdbmodel.Id;
        //			db.RegisteredUsers.Add(user4);
        //			db.SaveChanges();



        //			return RedirectToAction("Create", "Products");
        //		}
        //		//AddErrors(result);


        //	// If we got this far, something failed, redisplay for
        //	return View(model);
        //}
    }
}