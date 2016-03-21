using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SentosaWebsite.Models;
using SentosaWebsite.DAL;

namespace SentosaWebsite.Controllers
{
    public class RestaurantController : Controller
    {
        

        private DataGateway<Restaurant> dataGateway = new DataGateway<Restaurant>();
        // GET: Restaurant
        public ActionResult Index()
        {
            return View(dataGateway.SelectAll());
        }

        // GET: Restaurant
        public ActionResult DisplayPage()
        {
            ViewBag.Message = "lailai restaurant";

            return View(dataGateway.SelectAll());
        }

        // GET: Restaurant/Details/
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant myRestaurant = dataGateway.SelectById(id);
            if (myRestaurant == null)
            {
                return HttpNotFound();
            }
            ViewBag.Longitude = myRestaurant.restLocLong;
            ViewBag.Latitude = myRestaurant.restLocLat;
            return View(myRestaurant);
        }

        // GET: Restaurant/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Restaurant/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,restName,restDes,restType,restLocLat,restLocLong")] Restaurant myRestaurant)
        {
            if (ModelState.IsValid)
            {
                dataGateway.Insert(myRestaurant);
                dataGateway.Save();
                return RedirectToAction("Index");
            }

            return View(myRestaurant);
        }

        // GET: Restaurant/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant myRestaurant = dataGateway.SelectById(id);
            if (myRestaurant == null)
            {
                return HttpNotFound();
            }
            return View(myRestaurant);
        }

        // POST: Restaurant/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,restName,restDes,restType,restLocLat,restLocLong")] Restaurant myRestaurant)
        {
            if (ModelState.IsValid)
            {
                dataGateway.Update(myRestaurant);
                return RedirectToAction("Index");
            }
            return View(myRestaurant);
        }

        // GET: Restaurant/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant myRestaurant = dataGateway.SelectById(id);
            if (myRestaurant == null)
            {
                return HttpNotFound();
            }
            return View(myRestaurant);
        }

        // POST: Restaurant/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Restaurant myRestaurant = dataGateway.SelectById(id);
            dataGateway.Delete(id);
            return RedirectToAction("Index");
        }

        //Need to think a way to combine this with POST create later
        //Upload Photo
        [HttpPost]
        public ActionResult UploadPhoto(string myRestaurantImage,
        HttpPostedFileBase photo)
        {
            string path = Server.MapPath("~/Images/RestaurantImg/" +
          myRestaurantImage);

            if (photo != null)
                photo.SaveAs(path);

            return RedirectToAction("Index");
        }

        //Delete Photo
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePhoto(string photoFileName)
        {
            //Session["DeleteSuccess"] = "No";
            var photoName = "";
            photoName = photoFileName;
            string fullPath = Request.MapPath("~/Images/RestaurantImg/"
            + photoName);

            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
                //Session["DeleteSuccess"] = "Yes";
            }
            return RedirectToAction("Index");
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }



    }
}
