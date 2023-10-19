using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Norda.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Norda.DAL.Contexts
{
    public class SqlContext : DbContext
    {

        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {

        }

        public DbSet<Slide> Slide { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductPicture> ProductPicture { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<District> District { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Street> Street { get; set; }
        public DbSet<Country> Country { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // fluent api
            modelBuilder.Entity<District>().HasOne(x => x.City).WithMany(x => x.Districts).OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Street>().HasOne(x => x.District).WithMany(x => x.Streets).OnDelete(DeleteBehavior.SetNull);

            //çoka çok ilişkilendirme
            modelBuilder.Entity<ProductCategory>().HasKey(x => new { x.ProductID, x.CategoryID });

            // Herhangi bir marka silinirse o markaya ait tüm ürünlerin silinmesini önlemek için yapılıyor.
            modelBuilder.Entity<Product>().HasOne(x => x.Brand).WithMany(x => x.Products).OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Order>().HasIndex(o => o.OrderNumber).IsUnique().HasDatabaseName("OrderNumberUnique");

            // Sınırsız Kategori Mantığı.
            modelBuilder.Entity<Category>().HasOne(x => x.ParentCategory).WithMany(x => x.SubCategories).HasForeignKey(x => x.ParentID);

            modelBuilder.Entity<Admin>().HasData(new Admin
            {
                ID = 1, 
                Name = "Ferhat", 
                Surname = "Aydın", 
                UserName = "owsla",
                Password = "202cb962ac59075b964b07152d234b70"
            });

        }
    }
}
