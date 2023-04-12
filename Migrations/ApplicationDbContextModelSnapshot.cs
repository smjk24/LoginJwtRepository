﻿// <auto-generated />
using Login.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Login.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Login.Model.Account", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserPassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserRole")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            UserName = "sanoop",
                            UserPassword = "12345",
                            UserRole = "SuperAdmin"
                        },
                        new
                        {
                            UserId = 2,
                            UserName = "kohli",
                            UserPassword = "1234",
                            UserRole = "User"
                        },
                        new
                        {
                            UserId = 3,
                            UserName = "Sachin",
                            UserPassword = "123",
                            UserRole = "Admin"
                        });
                });

            modelBuilder.Entity("Login.Model.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Countrys");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "India"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Aus"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Rsa"
                        });
                });

            modelBuilder.Entity("Login.Model.State", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("States");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CountryId = 1,
                            Name = "Kerala"
                        },
                        new
                        {
                            Id = 2,
                            CountryId = 1,
                            Name = "TamilNadu"
                        },
                        new
                        {
                            Id = 3,
                            CountryId = 1,
                            Name = "Goa"
                        },
                        new
                        {
                            Id = 4,
                            CountryId = 2,
                            Name = "Melbourne"
                        },
                        new
                        {
                            Id = 5,
                            CountryId = 2,
                            Name = "Sydney"
                        },
                        new
                        {
                            Id = 6,
                            CountryId = 3,
                            Name = "Johanousberg"
                        });
                });

            modelBuilder.Entity("Login.Model.State", b =>
                {
                    b.HasOne("Login.Model.Country", "GetCountry")
                        .WithMany("StateCollection")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
