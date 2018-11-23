using online.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using online.Models;
using Microsoft.AspNet;
using Microsoft.AspNet.Identity;
namespace online.Controllers
{
    public class ProductViewController : Controller
    {
		// GET: ProductView
		public ActionResult Index()
		{
			onlineDbEntities db = new onlineDbEntities();
			List<Product> Viewlist = db.Products.ToList();
			List<ProductViewModel> List = new List<ProductViewModel>();
			foreach (Product a in Viewlist)
			{
				ProductViewModel ab = new ProductViewModel();
				ab.Product_Name = a.Product_Name;
				ab.Product_Description = a.Product_Description;
				ab.Minimum_Bid_Amount = a.Minimum_Bid_Amount;
				ab.Auction_Time = a.Auction_Time;
				ab.Select_Category = a.Select_Category;
				List.Add(ab);

			}
			return View(List);
		}
			// GET: ProductView/Details/5
		public ActionResult Details(int id)

        {
            return View();
        }

        // GET: ProductView/Create
        public ActionResult Create()

        {
            return View("create");
        }

        // POST: ProductView/Create
        [HttpPost]
        public ActionResult Create(ProductViewModel collection)
        {
            try
            {
				// TODO: Add insert logic here
				onlineDbEntities db = new onlineDbEntities();
				Product ac = new Product();
				ac.Product_Name = collection.Product_Name;
				ac.Product_Description = collection.Product_Description;
				ac.Minimum_Bid_Amount = collection.Minimum_Bid_Amount;
				ac.Auction_Time = collection.Auction_Time;
				ac.Select_Category = collection.Select_Category;

				db.Products.Add(ac);
				db.SaveChanges();



			}
			catch (Exception ex)
			{
				return View();
			}
			return RedirectToAction("Index");
		}

        // GET: ProductView/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductView/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductView/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductView/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
