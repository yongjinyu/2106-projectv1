using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SentosaWebsite.Models
{
    public class Hour
    {
        public int ID { get; set; }
        public string openingHour { get; set; }
        public string closingHour { get; set; }
        public string day { get; set; }

        public void lalaTest(string value, string value2 , string value3)
        {
            openingHour = value;
            closingHour = value2;
            day = value3;
        }
    }
}