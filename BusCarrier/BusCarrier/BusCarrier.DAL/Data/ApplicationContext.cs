using BusCarrier.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BusCarrier.DAL.Data
{
    public class ApplicationContext : IdentityDbContext<IdentityUser<int>, IdentityRole<int>, int>
    {
        public DbSet<Route> Routes { get; set; }
        public DbSet<RouteTemplate> RouteTemplates { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceTemplate> ServiceTemplates { get; set; }
        public DbSet<Station> Stations { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

    }
}
