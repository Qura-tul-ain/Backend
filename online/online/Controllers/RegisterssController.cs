using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using online;
using System.Data.SqlClient;
using online.Models;
using System.Data.Entity.Infrastructure;

namespace online.Controllers
{
    public class RegisterssController : Controller
    {
        int ii = 12;
        int myid;
        string connectionstring = @"Data Source=DESKTOP-G0K5DQK;Initial Catalog=online;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework";
        private object db;
        private onlineEntities dbb = new onlineEntities();

        // GET: Register
        public ActionResult Index()
        {
            return View(dbb.RegisteredUsers.ToList());
        }

        // GET: Register/Details/5
        public ActionResult Details(string id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //RegisteredUser registeredUser = db.RegisteredUsers.Find(id);
            //if (registeredUser == null)
            //{
            //    return HttpNotFound();
            //}
            return View();
        }

        // GET: Register/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Register/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RegisterViewModel registeredUser)
        {
        
            try
            {
              
                RegisteredUser obj = new RegisteredUser();
                obj.Id = ii ;
                obj.Name = registeredUser.Name;
                obj.Password = registeredUser.Password;
                obj.Email = registeredUser.Email;
                obj.Adress = registeredUser.Address;
                obj.CNIC = registeredUser.CNIC;
                dbb.RegisteredUsers.Add(obj);
                ii++;
                dbb.SaveChanges();
              

                return RedirectToAction("Login", "Registerss");

            }catch(Exception ex)
            {
                return View(ex);
            }
        }

        // GET: Register/Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            int i = 1;
            int j = 0;
            onlineEntities db = new onlineEntities();
            try
            {
                RegisteredUser o = new RegisteredUser();
                foreach (var a in db.RegisteredUsers)
                {
                    if (a.Email == model.Email && a.Password == model.Password)
                    {
                        i = 0;
                        myid = a.Id;
                        if(a.Id==3)
                        {
                            return RedirectToAction("IndexAdmin", "Products");
                        }

                      
                    }
                }
                if(i==0)
                {
                   
                    return RedirectToAction("Index2", "Products");
                }
                else
                {
                    return View(model);
                }
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                return View(model);
            }
        }


        public ActionResult MyProducts()
        {
            List<Product> pro = new List<Product>();
            RegisteredUser o = new RegisteredUser();
            o.Id = 12;
            foreach (var a in dbb.Products)
            {
                if (o.Id == a.Id)
                {
                    pro.Add(a);
                }
            }
            return View(pro);
        }



        // GET: Register/Edit/5
        public ActionResult Edit(string id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //RegisteredUser registeredUser = db.RegisteredUsers.Find(id);
            //if (registeredUser == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(registeredUser);
            return View();
        }

        // POST: Register/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Email,CNIC,Adress,Password")] RegisteredUser registeredUser)
        {
            //if (ModelState.IsValid)
            //{
            //    db.Entry(registeredUser).State = EntityState.Modified;
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            return View(registeredUser);
        }

        // GET: Register/Delete/5
        public ActionResult Delete(string id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //RegisteredUser registeredUser = db.RegisteredUsers.Find(id);
            //if (registeredUser == null)
            //{
            //    return HttpNotFound();
            //}
            return View();
        }

        // POST: Register/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            //RegisteredUser registeredUser = db.RegisteredUsers.Find(id);
            //db.RegisteredUsers.Remove(registeredUser);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
            base.Dispose(disposing);
        }
    }
}
