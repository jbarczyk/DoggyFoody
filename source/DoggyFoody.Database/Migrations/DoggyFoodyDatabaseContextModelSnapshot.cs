﻿// <auto-generated />
using System;
using DoggyFoody.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DoggyFoody.Database.Migrations
{
    [DbContext(typeof(DoggyFoodyDatabaseContext))]
    partial class DoggyFoodyDatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DoggyFoody.Contracts.Database.Models.Advertisement", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content");

                    b.Property<string>("ImageAddress");

                    b.Property<long?>("ManufacturerId");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("ManufacturerId");

                    b.ToTable("Advertisements");
                });

            modelBuilder.Entity("DoggyFoody.Contracts.Database.Models.Column", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("ProductId");

                    b.Property<DateTime>("Published");

                    b.Property<string>("Text");

                    b.Property<string>("Title");

                    b.Property<long?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("Columns");
                });

            modelBuilder.Entity("DoggyFoody.Contracts.Database.Models.Comment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author");

                    b.Property<long?>("ProductId");

                    b.Property<DateTime>("Published");

                    b.Property<string>("Text");

                    b.Property<long?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("DoggyFoody.Contracts.Database.Models.Manufacturer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Manufacturers");
                });

            modelBuilder.Entity("DoggyFoody.Contracts.Database.Models.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("ImageAddress");

                    b.Property<string>("IngredientsInternal")
                        .HasColumnName("Ingredients");

                    b.Property<long>("ManufacturerId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("ManufacturerId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("DoggyFoody.Contracts.Database.Models.Rate", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("ProductId");

                    b.Property<int>("Score");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Rates");
                });

            modelBuilder.Entity("DoggyFoody.Contracts.Database.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<string>("Login");

                    b.Property<string>("Password");

                    b.Property<int>("UserType");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DoggyFoody.Contracts.Database.Models.Advertisement", b =>
                {
                    b.HasOne("DoggyFoody.Contracts.Database.Models.Manufacturer")
                        .WithMany("Advertisements")
                        .HasForeignKey("ManufacturerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DoggyFoody.Contracts.Database.Models.Column", b =>
                {
                    b.HasOne("DoggyFoody.Contracts.Database.Models.Product")
                        .WithMany("Columns")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("DoggyFoody.Contracts.Database.Models.User")
                        .WithMany("Columns")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("DoggyFoody.Contracts.Database.Models.Comment", b =>
                {
                    b.HasOne("DoggyFoody.Contracts.Database.Models.Product")
                        .WithMany("Comments")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DoggyFoody.Contracts.Database.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DoggyFoody.Contracts.Database.Models.Product", b =>
                {
                    b.HasOne("DoggyFoody.Contracts.Database.Models.Manufacturer")
                        .WithMany("Products")
                        .HasForeignKey("ManufacturerId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("DoggyFoody.Contracts.Database.Models.Rate", b =>
                {
                    b.HasOne("DoggyFoody.Contracts.Database.Models.Product")
                        .WithMany("Rates")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
