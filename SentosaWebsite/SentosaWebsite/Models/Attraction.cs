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
        public string atTransportMode { get; set; }
        public string atTransportDes { get; set; }

        // for setting ticketprice 
        public TicketPrice myTicket { get; set; }
        // for setting opening hour
        public Hour myOpeningHour {get ; set;}


        // public TicketPrice price { get; set; }
        //public void setMyTicketType(TicketPrice obj)
        //{
        //    this.ticketType = value1;
        //    this.price = value2;
        //}


        //public void setMyTicketType(TicketPrice obj)
        //{
        //    this.myTicket = obj;

        //}
        public void setMyOpeningHour(Hour obj2)
        {
            this.myOpeningHour = obj2;
        }
        public string atImage
            //For the Images 
        {
            get { return atName.Replace(" ", string.Empty) + ".jpg"; }
        }
    }

}