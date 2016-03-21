using System.Data.Entity;

namespace SentosaWebsite.Models
{
    public class Attraction
    {
        public int ID { get; set; }
        public string atName { get; set; }
        public string atDes { get; set; }
        public string atType { get; set; }
        public string atLocLat { get; set; }
        public string atLocLong { get; set; }
        public string atOpeningHourWeekend { get; set; }
        public string atOpeningHourWeekday { get; set; }
        public string atClosingHourWeekend { get; set; }
        public string atClosingHourWeekday { get; set; }
        public string atAdultPrice { get; set; }
        public string atChildPrice { get; set;  }
        public string atHowToGetThere { get; set; }


        public TicketPrice testing { get; set; }
        // public TicketPrice price { get; set; }

        //public void setMyTicketType(TicketPrice obj)
        //{
        //    this.ticketType = value1;
        //    this.price = value2;
        //}


        public void setMyTicketType(TicketPrice obj)
        {
               this.testing = obj;
          
        }

        public string atImage
            //For the Images 
        {
            get { return atName.Replace(" ", string.Empty) + ".jpg"; }
        }
    }

}