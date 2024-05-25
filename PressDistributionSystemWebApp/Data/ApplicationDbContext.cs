using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace PressDistributionSystemWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Distributor> Distributors { get; set; }
        public DbSet<Kiosk> Kiosks { get; set; }
        public DbSet<KioskPublication> KioskPublications { get; set; }
        public DbSet<Publication> Publications { get; set; }
        public DbSet<PublicationDistributor> PublicationDistributors { get; set; }
    }
}
