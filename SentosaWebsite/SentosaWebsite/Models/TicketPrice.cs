using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SentosaWebsite.Models
{
    public class TicketPrice 
    {
        public int ID { get; set; }
        public string ticketType { get; set; }
        public string price { get; set; }
        public int FK_id { get; private set; }

        public void lalaTest(string value, string value2, int at_Id)
        {
            ticketType = value;
            price = value2;
            FK_id = at_Id;
        }
    }
}