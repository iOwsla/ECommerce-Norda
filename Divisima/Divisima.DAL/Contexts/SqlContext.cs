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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // fluent api
            modelBuilder.Entity<Admin>().HasData(new Admin
            {
                ID = 1, 
                Name = "Ferhat", 
                Surname = "Aydın", 
                UserName = "owsla",
                Password = "202cb962ac59075b964b07152d234b70"
            });

            modelBuilder.Entity<Slide>().HasKey(x => x.Title).HasName("sda");
        }
    }
}
