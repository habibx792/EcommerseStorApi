using Microsoft.EntityFrameworkCore;
using ProjectClasses;
namespace EcommerApi.Models
{
    public class ProjectDbContext:DbContext
    {
        
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options):base(options) { 

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany()
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Order>()
                .HasOne(o=>o.ShipmentRider)
                .WithMany()
                .HasForeignKey(o=>o.ShipmentRiderId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<OrderProduct>()
                .HasKey(op=>new {op.OrderId, op.ProductId});
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get;set; }
        public DbSet<UserAddress> UserAddresses { get; set; }

        public DbSet<Order>Orders { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ShipmentRider> ShipmentRiders { get; set; }
        public DbSet<OrderProduct> orderProducts { get; set; }

    }
}
