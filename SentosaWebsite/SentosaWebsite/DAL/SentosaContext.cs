using System.Data.Entity;
using SentosaWebsite.Models;
namespace SentosaWebsite.DAL
{
    public class SentosaContext : DbContext
    {
        public SentosaContext(): base("toto6")
        {

        }
        public DbSet<Attraction> Attractions { get; set; }
        //insert more accordingly to the models

        public DbSet<Restaurant> Restaurants { get; set; }

        //public DbSet <Testing> Testing { get; set; }
    }
}