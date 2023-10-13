using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Divisima.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Divisima.DAL.Contexts
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // fluent api

            //çoka çok ilişkilendirme
            modelBuilder.Entity<ProductCategory>().HasKey(x => new { x.ProductID, x.CategoryID });

            // Herhangi bir marka silinirse o markaya ait tüm ürünlerin silinmesini önlemek için yapılıyor.
            modelBuilder.Entity<Product>().HasOne(x => x.Brand).WithMany(x => x.Products).OnDelete(DeleteBehavior.SetNull);

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
