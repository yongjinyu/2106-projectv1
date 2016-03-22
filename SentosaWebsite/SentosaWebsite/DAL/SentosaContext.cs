using System.Data.Entity;
using SentosaWebsite.Models;
namespace SentosaWebsite.DAL
{
    public class SentosaContext : DbContext
    {
        public SentosaContext(): base("lalal")
        {

        }
        public DbSet<Attraction> Attractions { get; set; }
        //insert more accordingly to the models

        public DbSet<Restaurant> Restaurants { get; set; }

        public System.Data.Entity.DbSet<SentosaWebsite.Models.TicketPrice> TicketPrices { get; set; }

        //public DbSet <Testing> Testing { get; set; }
    }
}