using Microsoft.EntityFrameworkCore;
using UYK.Model;

namespace UYK.DAL
{
    public class UykDbContext : DbContext
    {
        public UykDbContext(DbContextOptions<UykDbContext> options) : base(options)
        {

        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Ordered> Ordereds { get; set; }
        public DbSet<Complaint> Complaints { get; set; }

    }
}
