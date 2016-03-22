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
        private DataGateway<TicketPrice> ticketDataGateway = new DataGateway<TicketPrice>();
        // GET: Attractions
        public ActionResult Index()
        { 
            //Attraction hi = new Attraction();

            //hi.atName = "nice to meet you";

            //Attraction input1 = new Attraction();
            //Attraction input2 = new Attraction();
            //Attraction input3 = new Attraction();
            //Attraction input4 = new Attraction();
            //Attraction input5 = new Attraction();
            //Attraction input6 = new Attraction();
            //Attraction input7 = new Attraction();
            //Attraction input8 = new Attraction();
            //Attraction input9 = new Attraction();
            //Attraction input10 = new Attraction();

            //input1.atName = "S.E.A. Aquarium"; input1.atDes = "Discover the awe-inspiring world of life in the ocean at the world’s largest aquarium. Step into S.E.A."; input1.atType = "Family"; input1.atLocLat = "1.2583091"; input1.atLocLat = "103.8205066";
            //input2.atName = "Dolphin Island"; input2.atDes = "Dolphin Island™ offers a range of programmes that gives you the opportunity to interact with Indo-Pacific Bottlenose dolphins and to learn about them. "; input2.atType = "Family"; input2.atLocLat = "1.2581827"; input2.atLocLat = "1.2581827";
            //input3.atName = "Skyline Luge Sentosa"; input3.atDes = "Invented in New Zealand over 29 years ago, and having hosted over 31 million rides worldwide, Skyline Luge Sentosa is the first-ever Luge introduced in Southeast Asia."; input3.atType = "Fun"; input3.atLocLat = "1.2520053"; input3.atLocLat = "103.8168874";
            //input4.atName = "Adventure Cove Waterpark"; input4.atDes = "Promising endless splashes of fun, Adventure Cove Waterpark is an aquatic adventure park with something for everyone. "; input4.atType = "Fun"; input4.atLocLat = "1.2580789"; input4.atLocLat = "103.8207051";
            //input5.atName = "Cranes Dance"; input5.atDes = "Watch the magical love story between a pair of mechanical cranes and how their love for each other transforms them into real birds"; input5.atType = "Family"; input5.atLocLat = "1.258626"; input5.atLocLat = "103.82193";
            //input6.atName = "Tiger Sky Tower truly"; input6.atDes = "Singapore's tallest observatory tower is a distinctive landmark, soaring high above the surrounding natural greenery."; input6.atType = "Family"; input6.atLocLat = "1.2549754"; input6.atLocLat = "103.8175937";
            //input7.atName = "Sentosa 4D Adventure Land"; input7.atDes = "Home to UNLIMITED FUN! Go on in an immersive 4-D movie, Journey 2: The Mysterious Island, The 4-D Experience. "; input7.atType = "Fun"; input7.atLocLat = "1.255284"; input7.atLocLat = "103.816766";
            //input8.atName = "Trick Eye Museum"; input8.atDes = "Trick Eye Museum is an attraction for people of all ages coming together with friends, families and their loved ones. Embark on the adventure as you enter the 3D Battlefield."; input8.atType = "Family"; input8.atLocLat = "1.256988"; input8.atLocLat = "103.84226729";
            //input9.atName = "Port of Lost Wonder"; input9.atDes = "Port of Lost Wonder"; input9.atType = "Family"; input9.atLocLat = "1.2505248"; input9.atLocLat = "103.8198936";
            //input10.atName = "Universal Studios Singapore"; input10.atDes = "Designed to provide a unique experience of family bonding, the attraction houses a signature water play area, themed islets for picnics and leisure activities and distinctive retail and dining experiences for the very young and young at heart."; input10.atType = "Fun"; input10.atLocLat = "1.2540421"; input10.atLocLat = "103.8238084";

            //dataGateway.Insert(input1);
            //dataGateway.Insert(input2);
            //dataGateway.Insert(input3);
            //dataGateway.Insert(input4);
            //dataGateway.Insert(input5);
            //dataGateway.Insert(input6);
            //dataGateway.Insert(input7);
            //dataGateway.Insert(input8);
            //dataGateway.Insert(input9);
            //dataGateway.Insert(input10);


            //dataGateway.Insert(hi);
            //    dataGateway.Save();
        
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

        //display ticket list
        public ActionResult test()
        {
            return View(ticketDataGateway.SelectAll());

        }

        //Get : Attraction/Edit
        public ActionResult DetailsTicketPrice(int? id) {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TicketPrice ticketprice = ticketDataGateway.SelectById(id);
            if (ticketprice == null)
            {
                return HttpNotFound();
            }
            
            return View(ticketprice);
        }


        public ActionResult DetailTicketPricing(int? id)
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
            IEnumerable<TicketPrice> result = ticketDataGateway.ticketById( (int) id, ticketDataGateway.SelectAll());
            //

            //TicketPrice ticketprice = ticketDataGateway.ticketById((int)id, ticketDataGateway.SelectAll());
            return View(result);
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
        public ActionResult Create([Bind(Include = "ID,atName,atDes,atType,atLocLat,atLocLong,atTransportMode,atTransportDes")] Attraction attraction) //,myticket,myOpeningHour
        {
            if (ModelState.IsValid)

            {
                //TicketPrice tkprice = new TicketPrice();
                //TicketPrice tktype = new TicketPrice();
                //tktype.lalaTest("My Ticket", "hello");
              
             //   attraction.setMyTicketType(tktype);
                dataGateway.Insert(attraction);
                dataGateway.Save();
                return RedirectToAction("Index");
            }

            return View(attraction);
        }
        // get create ticket

        public ActionResult CreateTicket(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Attraction attraction = dataGateway.SelectById(id);
            //if (attraction == null)
            //{
            //    return HttpNotFound();
            //}


            TicketPrice newTicket = new TicketPrice();
            //newTicket.atID = (int)id;
            //ticketDataGateway.Insert(newTicket);
            ViewBag.atID = (int)id;

            return View(newTicket);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateTicket([Bind(Include = "ID")] Attraction attraction,TicketPrice newTicket)
        {
            if (ModelState.IsValid)
            {
                //attraction.myTicket.ID = attraction.ID;
                //myTicket.ID = attraction.ID;
                //dataGateway.Update(attraction);




                //TicketPrice ticketID = new TicketPrice();
                //ticketID.atID = attraction.ID;
                //attraction.ID;
                newTicket.atID = attraction.ID;

                ticketDataGateway.Insert(newTicket);
                return RedirectToAction("Index");
            }
            return View();
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
        public ActionResult Edit([Bind(Include = "atID,atName,atDes,atType,atLocLat,atLocLong,atTransportMode,atTransportDes")] Attraction attraction)
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
