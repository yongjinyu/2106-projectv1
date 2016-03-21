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
    public class AttractionsController : Controller
    {
        //private AttractionDbContext db = new AttractionDbContext();
        //internal IDataGateway<Attraction> dataGateway;
        //private AttractionsGateway dataGateway = new AttractionsGateway();

        private DataGateway<Attraction> dataGateway = new DataGateway<Attraction>();
        // GET: Attractions
        public ActionResult Index()
        {
            return View(dataGateway.SelectAll());
        }

        // GET: Attractions
        public ActionResult DisplayPage()
        {
            ViewBag.Message = "Welcome to SENTOSA! List of our attraction can be viewed here!!";

            return View(dataGateway.SelectAll());
        }

        // GET: Attractions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attraction attraction = dataGateway.SelectById(id);
            if (attraction == null)
            {
                return HttpNotFound();
            }
            ViewBag.Longitude = attraction.atLocLong;
            ViewBag.Latitude = attraction.atLocLat;
            return View(attraction);
        }

        // GET: Attractions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Attractions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,atName,atDes,atType,atLocLat,atLocLong,atOpeningHourWeekend,atClosingHourWeekend,atOpeningHourWeekday,atClosingHourWeekday,atAdultPrice,atChildPrice,atHowToGetThere , testing")] Attraction attraction)
        {
            if (ModelState.IsValid)


            {
               // TicketPrice tkprice = new TicketPrice();
                TicketPrice tktype = new TicketPrice();
              //  tktype.lalaTest("My Ticket", "hello");
              
             //   attraction.setMyTicketType(tktype);
                dataGateway.Insert(attraction);
                dataGateway.Save();
                return RedirectToAction("Index");
            }

            return View(attraction);
        }

        // GET: Attractions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attraction attraction = dataGateway.SelectById(id);
            if (attraction == null)
            {
                return HttpNotFound();
            }
            return View(attraction);
        }

        // POST: Attractions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,atName,atDes,atType,atLocLat,atLocLong,atOpeningHourWeekend,atClosingHourWeekend,atOpeningHourWeekday,atClosingHourWeekday,atAdultPrice,atChildPrice,atHowToGetThere")] Attraction attraction)
        {
            if (ModelState.IsValid)
            {
                dataGateway.Update(attraction);
                return RedirectToAction("Index");
            }
            return View(attraction);
        }

        // GET: Attractions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attraction attraction = dataGateway.SelectById(id);
            if (attraction == null)
            {
                return HttpNotFound();
            }
            return View(attraction);
        }

        // POST: Attractions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Attraction attraction = dataGateway.SelectById(id);
            dataGateway.Delete(id);
            return RedirectToAction("Index");
        }

        //Need to think a way to combine this with POST create later
        //Upload Photo
        [HttpPost]
        public ActionResult UploadPhoto(string attractionsImage,
        HttpPostedFileBase photo)
        {
            string path = Server.MapPath("~/Images/Attractions/" +
          attractionsImage);

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
            string fullPath = Request.MapPath("~/Images/Attractions/"
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
