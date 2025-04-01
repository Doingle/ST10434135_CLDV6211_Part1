using Microsoft.EntityFrameworkCore;
using ST10434135_CLDV6211_Part1.Models;

namespace ST10434135_CLDV6211_Part1.Data
{
    public class AppDbContext : DbContext
    {

        // Constructor
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // DbSets for each model class to create tables in the database
        public DbSet<Bookings> Bookings { get; set; }
        public DbSet<Events> Events { get; set; }
        public DbSet<Venues> Venues { get; set; }
        public DbSet<BookingSpecialists> BookingSpecialists { get; set; }
        public DbSet<Clients> Clients { get; set; }

    }
}
//----------------------------------------------EOF--------------------------------------------------//