﻿// <auto-generated />
using System;
using Divisima.DAL.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Divisima.DAL.Migrations
{
    [DbContext(typeof(SqlContext))]
    partial class SqlContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Divisima.DAL.Entities.Admin", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.HasKey("ID");

                    b.ToTable("Admin");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "Ferhat",
                            Password = "202cb962ac59075b964b07152d234b70",
                            Surname = "Aydın",
                            UserName = "owsla"
                        });
                });

            modelBuilder.Entity("Divisima.DAL.Entities.Brand", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.HasKey("ID");

                    b.ToTable("Brand");
                });

            modelBuilder.Entity("Divisima.DAL.Entities.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("DisplayIndex")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<int?>("ParentID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ParentID");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Divisima.DAL.Entities.Product", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int?>("BrandID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Detail")
                        .HasColumnType("text");

                    b.Property<int>("DisplayIndex")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Stock")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

                    b.HasIndex("BrandID");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("Divisima.DAL.Entities.ProductCategory", b =>
                {
                    b.Property<int?>("ProductID")
                        .HasColumnType("int");

                    b.Property<int?>("CategoryID")
                        .HasColumnType("int");

                    b.Property<int?>("ID")
                        .HasColumnType("int");

                    b.HasKey("ProductID", "CategoryID");

                    b.HasIndex("CategoryID");

                    b.ToTable("ProductCategory");
                });

            modelBuilder.Entity("Divisima.DAL.Entities.ProductPicture", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("DisplayIndex")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Picture")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ProductID");

                    b.ToTable("ProductPicture");
                });

            modelBuilder.Entity("Divisima.DAL.Entities.Slide", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Description")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<int>("DisplayIndex")
                        .HasColumnType("int");

                    b.Property<string>("Link")
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Picture")
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("ID");

                    b.ToTable("Slide");
                });

            modelBuilder.Entity("Divisima.DAL.Entities.Category", b =>
                {
                    b.HasOne("Divisima.DAL.Entities.Category", "ParentCategory")
                        .WithMany("SubCategories")
                        .HasForeignKey("ParentID");

                    b.Navigation("ParentCategory");
                });

            modelBuilder.Entity("Divisima.DAL.Entities.Product", b =>
                {
                    b.HasOne("Divisima.DAL.Entities.Brand", "Brand")
                        .WithMany("Products")
                        .HasForeignKey("BrandID")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("Divisima.DAL.Entities.ProductCategory", b =>
                {
                    b.HasOne("Divisima.DAL.Entities.Category", "Category")
                        .WithMany("ProductCategories")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.HasOne("Divisima.DAL.Entities.Product", "Product")
                        .WithMany("ProductCategories")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Divisima.DAL.Entities.ProductPicture", b =>
                {
                    b.HasOne("Divisima.DAL.Entities.Product", "Product")
                        .WithMany("ProductPictures")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Divisima.DAL.Entities.Brand", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Divisima.DAL.Entities.Category", b =>
                {
                    b.Navigation("ProductCategories");

                    b.Navigation("SubCategories");
                });

            modelBuilder.Entity("Divisima.DAL.Entities.Product", b =>
                {
                    b.Navigation("ProductCategories");

                    b.Navigation("ProductPictures");
                });
#pragma warning restore 612, 618
        }
    }
}
