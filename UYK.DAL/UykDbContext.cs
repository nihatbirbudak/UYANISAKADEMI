using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using UYK.Model;

namespace UYK.DAL
{
    public class UykDbContext : DbContext
    {
        public UykDbContext(DbContextOptions<UykDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                 .HasKey(z => z.Id);
            modelBuilder.Entity<Category>()
                 .HasKey(z => z.Id);
            modelBuilder.Entity<ProductCategories>()
                .HasKey(z => new { z.ProductId, z.CategoryId });
            modelBuilder.Entity<ProductCategories>()
                .HasOne(z => z.Product)
                .WithMany(m => m.ProductCategories)
                .HasForeignKey(f => f.ProductId);
            modelBuilder.Entity<ProductCategories>()
                .HasOne(z => z.Category)
                .WithMany(m => m.ProductCategories)
                .HasForeignKey(z => z.CategoryId);

            modelBuilder.Entity<Course>()
                .HasKey(z => z.Id);
            modelBuilder.Entity<ClassType>()
                .HasKey(z => z.Id);
            modelBuilder.Entity<CourseClassTpye>()
                .HasKey(z => new { z.CourseId, z.ClassTypeId, z.Id });
            modelBuilder.Entity<CourseClassTpye>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();
                
                
                
                
            modelBuilder.Entity<CourseClassTpye>()
                .HasOne(z => z.Course)
                .WithMany(m => m.CourseClassTpyes)
                .HasForeignKey(f => f.CourseId);
            modelBuilder.Entity<CourseClassTpye>()
                .HasOne(z => z.ClassType)
                .WithMany(m => m.CourseClassTpyes)
                .HasForeignKey(f => f.ClassTypeId);
                

            
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
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseCategoryType> CourseCategoryTypes { get; set; }
        public DbSet<ClassType> ClassTypes { get; set; }

    }
}
