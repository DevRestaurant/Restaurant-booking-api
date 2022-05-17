﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using restaurant_booking_Infrastructure.Contexts;

namespace restaurant_booking_Infrastructure.Migrations
{
    [DbContext(typeof(RbaContext))]
    partial class RbaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("restaurant_booking_Domain.Entities.AppUsers", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("Avatar")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("restaurant_booking_Domain.Entities.Customer", b =>
                {
                    b.Property<string>("AppUsersId")
                        .HasColumnType("text");

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.HasKey("AppUsersId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("restaurant_booking_Domain.Entities.GadgetProduct", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Category")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Image")
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<string>("ProductName")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("GadgetProducts");
                });

            modelBuilder.Entity("restaurant_booking_Domain.Entities.GoodsOrdered", b =>
                {
                    b.Property<string>("AppUsersId")
                        .HasColumnType("text");

                    b.Property<string>("AppUserId")
                        .HasColumnType("text");

                    b.Property<DateTime>("OrderDateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ProductId")
                        .HasColumnType("text");

                    b.Property<int>("QuantityOrdered")
                        .HasColumnType("integer");

                    b.Property<decimal>("TotalProductPrice")
                        .HasColumnType("numeric");

                    b.HasKey("AppUsersId");

                    b.HasIndex("AppUserId");

                    b.HasIndex("ProductId");

                    b.ToTable("CartProduct");
                });

            modelBuilder.Entity("restaurant_booking_Domain.Entities.Meal", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("MealName")
                        .HasColumnType("text");

                    b.Property<string>("ThumbNail")
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("Meals");
                });

            modelBuilder.Entity("restaurant_booking_Domain.Entities.MealPrice", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("MealId")
                        .HasColumnType("text");

                    b.Property<double>("PriceDetail")
                        .HasColumnType("double precision");

                    b.Property<int>("TypeOfTable")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("MealId");

                    b.ToTable("MealPrices");
                });

            modelBuilder.Entity("restaurant_booking_Domain.Entities.Reservation", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CustomerAppUsersId")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateBooked")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("FullName")
                        .HasColumnType("text");

                    b.Property<string>("HourBooked")
                        .HasColumnType("text");

                    b.Property<int>("NoOfPeople")
                        .HasColumnType("integer");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<int>("TypeOfTable")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("CustomerAppUsersId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("restaurant_booking_Domain.Entities.Reviews", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CustomerAppUsersId")
                        .HasColumnType("text");

                    b.Property<string>("Subject")
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("CustomerAppUsersId");

                    b.ToTable("Review");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("restaurant_booking_Domain.Entities.AppUsers", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("restaurant_booking_Domain.Entities.AppUsers", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("restaurant_booking_Domain.Entities.AppUsers", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("restaurant_booking_Domain.Entities.AppUsers", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("restaurant_booking_Domain.Entities.Customer", b =>
                {
                    b.HasOne("restaurant_booking_Domain.Entities.AppUsers", "AppUsers")
                        .WithOne("Customer")
                        .HasForeignKey("restaurant_booking_Domain.Entities.Customer", "AppUsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUsers");
                });

            modelBuilder.Entity("restaurant_booking_Domain.Entities.GoodsOrdered", b =>
                {
                    b.HasOne("restaurant_booking_Domain.Entities.AppUsers", "AppUser")
                        .WithMany()
                        .HasForeignKey("AppUserId");

                    b.HasOne("restaurant_booking_Domain.Entities.GadgetProduct", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");

                    b.Navigation("AppUser");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("restaurant_booking_Domain.Entities.MealPrice", b =>
                {
                    b.HasOne("restaurant_booking_Domain.Entities.Meal", "Meal")
                        .WithMany("MealPrices")
                        .HasForeignKey("MealId");

                    b.Navigation("Meal");
                });

            modelBuilder.Entity("restaurant_booking_Domain.Entities.Reservation", b =>
                {
                    b.HasOne("restaurant_booking_Domain.Entities.Customer", "Customer")
                        .WithMany("Reservations")
                        .HasForeignKey("CustomerAppUsersId");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("restaurant_booking_Domain.Entities.Reviews", b =>
                {
                    b.HasOne("restaurant_booking_Domain.Entities.Customer", "Customer")
                        .WithMany("Reviews")
                        .HasForeignKey("CustomerAppUsersId");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("restaurant_booking_Domain.Entities.AppUsers", b =>
                {
                    b.Navigation("Customer");
                });

            modelBuilder.Entity("restaurant_booking_Domain.Entities.Customer", b =>
                {
                    b.Navigation("Reservations");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("restaurant_booking_Domain.Entities.Meal", b =>
                {
                    b.Navigation("MealPrices");
                });
#pragma warning restore 612, 618
        }
    }
}
