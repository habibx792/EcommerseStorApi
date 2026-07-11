using Microsoft.EntityFrameworkCore;
using ProjectClasses;
namespace EcommerApi.Models
{
    public class ProjectDbContext:DbContext
    {
        
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options):base(options) { 

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get;set; }
        public DbSet<UserAddress> UserAddresses { get; set; }
        public DbSet<Order>Orders { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ShipmentRider> ShipmentRiders { get; set; }

    }
}
