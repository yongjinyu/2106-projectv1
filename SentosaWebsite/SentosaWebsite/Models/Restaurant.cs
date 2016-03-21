using System.Data.Entity;

namespace SentosaWebsite.Models
{
    public class Restaurant
    {
        public int ID { get; set; }
        public string restName { get; set; }
        public string restDes { get; set; }
        public string restType { get; set; }
        public string restLocLat { get; set; }
        public string restLocLong { get; set; }
      




        public string restImage
        //For the Images 
        {
            get { return restName.Replace(" ", string.Empty) + ".jpg"; }
        }
    }


}