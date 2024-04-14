﻿// <auto-generated />
using System;
using KolevDiamonds.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KolevDiamonds.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240405105309_AddedAdmin")]
    partial class AddedAdmin
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.27")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("KolevDiamonds.Infrastructure.Data.Models.InvestmentCoin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Coin unique identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Circulation")
                        .HasColumnType("int")
                        .HasComment("Number of pieces in circulation");

                    b.Property<double>("Diameter")
                        .HasColumnType("float")
                        .HasComment("Diameter of the coin in millimeters");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Server file system image path");

                    b.Property<string>("LegalTender")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Legal tender value in the specified currency");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Manufacturer of the coin");

                    b.Property<int>("Metal")
                        .HasColumnType("int")
                        .HasComment("Type of metal");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)")
                        .HasComment("Name of the coin");

                    b.Property<string>("Packaging")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasComment("Packaging for the coin");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)")
                        .HasComment("Price of the product");

                    b.Property<double>("Purity")
                        .HasColumnType("float")
                        .HasComment("Purity of the metal expressed as a ratio");

                    b.Property<int>("Quality")
                        .HasColumnType("int")
                        .HasComment("Quality of the metal");

                    b.Property<double>("Weight")
                        .HasColumnType("float")
                        .HasComment("Weight of the metal in grams");

                    b.HasKey("Id");

                    b.ToTable("InvestmentCoins");

                    b.HasComment("Investment coin specifications");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Circulation = 10000,
                            Diameter = 22.050000000000001,
                            ImagePath = "https://upload.wikimedia.org/wikipedia/commons/3/3a/1959_sovereign_Elizabeth_II_obverse.jpg",
                            LegalTender = "GBP 1",
                            Manufacturer = "The Royal Mint",
                            Metal = 2,
                            Name = "Gold Sovereign",
                            Packaging = "Protective Capsule",
                            Price = 1000.00m,
                            Purity = 0.91669999999999996,
                            Quality = 1,
                            Weight = 7.9800000000000004
                        },
                        new
                        {
                            Id = 2,
                            Circulation = 5000,
                            Diameter = 40.600000000000001,
                            ImagePath = "https://assets.goldeneaglecoin.com/resource/productimages/2020-SE-obv.jpg",
                            LegalTender = "USD 1",
                            Manufacturer = "United States Mint",
                            Metal = 1,
                            Name = "Silver Eagle",
                            Packaging = "Plastic Tube",
                            Price = 50.00m,
                            Purity = 0.999,
                            Quality = 1,
                            Weight = 31.100000000000001
                        },
                        new
                        {
                            Id = 3,
                            Circulation = 1000,
                            Diameter = 30.0,
                            ImagePath = "https://media.tavid.ee/v7/_product_catalog_/1-oz-canadian-maple-leaf-silver-coin/canadian_maple_leaf_1oz_silver_coin_reverse.jpg?height=960&width=960&func=cropfit",
                            LegalTender = "CAD 50",
                            Manufacturer = "Royal Canadian Mint",
                            Metal = 1,
                            Name = "Silver Maple Leaf",
                            Packaging = "Assay Card",
                            Price = 500.00m,
                            Purity = 0.99950000000000006,
                            Quality = 3,
                            Weight = 31.100000000000001
                        });
                });

            modelBuilder.Entity("KolevDiamonds.Infrastructure.Data.Models.InvestmentDiamond", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Diamond unique identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("Carats")
                        .HasColumnType("float")
                        .HasComment("How much carats is the diamond");

                    b.Property<string>("CertifyingLaboratory")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasComment("The certifying gemological laboratory");

                    b.Property<int>("Clarity")
                        .HasColumnType("int")
                        .HasComment("What clarity is the diamond");

                    b.Property<int>("Colour")
                        .HasColumnType("int")
                        .HasComment("What color is the diamond");

                    b.Property<int>("Cut")
                        .HasColumnType("int")
                        .HasComment("How well the diamond is cut");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Server file system image path");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)")
                        .HasComment("Name of the diamond");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)")
                        .HasComment("Price of the product");

                    b.Property<string>("Proportions")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("The proportions of the diamond");

                    b.HasKey("Id");

                    b.ToTable("InvestmentDiamonds");

                    b.HasComment("Investment diamond specifications");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Carats = 1.0,
                            CertifyingLaboratory = "GIA",
                            Clarity = 3,
                            Colour = 2,
                            Cut = 1,
                            ImagePath = "https://www.diamondbanc.com/wp-content/uploads/2019/01/shutterstock_32731492-1024x681.jpg",
                            Name = "Round Brilliant Diamond",
                            Price = 5000.00m,
                            Proportions = "Excellent"
                        },
                        new
                        {
                            Id = 2,
                            Carats = 1.5,
                            CertifyingLaboratory = "IGI",
                            Clarity = 6,
                            Colour = 4,
                            Cut = 2,
                            ImagePath = "https://www.qualitydiamonds.co.uk/media/1132/princess-diamond-top.png",
                            Name = "Princess Cut Diamond",
                            Price = 7000.00m,
                            Proportions = "Very Good"
                        },
                        new
                        {
                            Id = 3,
                            Carats = 2.0,
                            CertifyingLaboratory = "HRD",
                            Clarity = 7,
                            Colour = 3,
                            Cut = 3,
                            ImagePath = "https://www.capediamonds.co.za/wp-content/uploads/2020/09/Emerald-Cut-Diamonds-Cape-Diamonds-Cape-Town-South-Africa.jpg",
                            Name = "Emerald Cut Diamond",
                            Price = 10000.00m,
                            Proportions = "Good"
                        });
                });

            modelBuilder.Entity("KolevDiamonds.Infrastructure.Data.Models.MetalBar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Metal bar unique identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Dimensions")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasComment("Dimensions of the metal bar (length x width)");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Server file system image path");

                    b.Property<int>("Metal")
                        .HasColumnType("int")
                        .HasComment("Type of metal");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)")
                        .HasComment("Name of the metal bar");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)")
                        .HasComment("Price of the product");

                    b.Property<string>("Purity")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)")
                        .HasComment("Purity of the metal expressed in carat for gold or sample for silver");

                    b.Property<double>("Weight")
                        .HasColumnType("float")
                        .HasComment("Weight of the metal bar in grams");

                    b.HasKey("Id");

                    b.ToTable("MetalBars");

                    b.HasComment("Metal bar specifications");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Dimensions = "27 x 47 mm",
                            ImagePath = "https://m.media-amazon.com/images/I/61ICiCEk3TL._AC_UF894,1000_QL80_.jpg",
                            Metal = 2,
                            Name = "Gold Bar",
                            Price = 15000.00m,
                            Purity = "24 Karat",
                            Weight = 1000.0
                        },
                        new
                        {
                            Id = 2,
                            Dimensions = "20 x 40 mm",
                            ImagePath = "https://www.monex.com/wp-content/uploads/2023/06/1-kilo-silver-bar-side.png",
                            Metal = 1,
                            Name = "Silver Bar",
                            Price = 500.00m,
                            Purity = "999.9/1000",
                            Weight = 1000.0
                        },
                        new
                        {
                            Id = 3,
                            Dimensions = "25 x 50 mm",
                            ImagePath = "https://images.squarespace-cdn.com/content/v1/5719f32620c64744b886bcd2/1612970177011-TLIGBQ4ZDOODFX0TOR42/rose-gold-bar.png",
                            Metal = 4,
                            Name = "Rose Gold Bar",
                            Price = 20000.00m,
                            Purity = "24 Karat",
                            Weight = 1000.0
                        });
                });

            modelBuilder.Entity("KolevDiamonds.Infrastructure.Data.Models.Necklace", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Necklace unique identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("Carats")
                        .HasColumnType("float")
                        .HasComment("How much carats is the main diamond used in the necklace");

                    b.Property<int>("Clarity")
                        .HasColumnType("int")
                        .HasComment("What clarity is the main diamond in the necklace");

                    b.Property<int>("Colour")
                        .HasColumnType("int")
                        .HasComment("What color is the main diamond");

                    b.Property<int>("Cut")
                        .HasColumnType("int")
                        .HasComment("How well the diamond is cut");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Server file system image path");

                    b.Property<double>("Length")
                        .HasColumnType("float")
                        .HasComment("Length of the necklace in millimeters");

                    b.Property<int>("Metal")
                        .HasColumnType("int")
                        .HasComment("Metal, which necklace is made of");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)")
                        .HasComment("Name of the necklace");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)")
                        .HasComment("Price of the product");

                    b.Property<string>("Purity")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)")
                        .HasComment("Purity of the metal expressed in carat for gold or sample for silver");

                    b.HasKey("Id");

                    b.ToTable("Necklaces");

                    b.HasComment("Necklace specifications");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Carats = 2.5,
                            Clarity = 5,
                            Colour = 4,
                            Cut = 1,
                            ImagePath = "https://i.etsystatic.com/6244698/r/il/8121e9/1697727663/il_570xN.1697727663_9elj.jpg",
                            Length = 450.0,
                            Metal = 2,
                            Name = "Diamond Solitaire Necklace",
                            Price = 1500.00m,
                            Purity = "18K"
                        },
                        new
                        {
                            Id = 2,
                            Carats = 3.0,
                            Clarity = 7,
                            Colour = 14,
                            Cut = 2,
                            ImagePath = "https://media.beaverbrooks.co.uk/i/beaverbrooks/G105854_0",
                            Length = 500.0,
                            Metal = 1,
                            Name = "Sapphire Halo Necklace",
                            Price = 2000.00m,
                            Purity = "925"
                        },
                        new
                        {
                            Id = 3,
                            Carats = 2.7999999999999998,
                            Clarity = 4,
                            Colour = 1,
                            Cut = 1,
                            ImagePath = "https://haverhill.com/cdn/shop/products/image_11085d78-83fb-429b-a153-15a90bc9ee30_1200x1200.jpg?v=1705428203",
                            Length = 480.0,
                            Metal = 1,
                            Name = "Emerald Pendant Necklace",
                            Price = 1800.00m,
                            Purity = "925"
                        });
                });

            modelBuilder.Entity("KolevDiamonds.Infrastructure.Data.Models.Ring", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Ring unique identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("Carats")
                        .HasColumnType("float")
                        .HasComment("How much carats is the main diamond used in the ring");

                    b.Property<int>("Clarity")
                        .HasColumnType("int")
                        .HasComment("What clarity is the main diamond in the ring");

                    b.Property<int>("Colour")
                        .HasColumnType("int")
                        .HasComment("What color is the main diamond");

                    b.Property<int>("Cut")
                        .HasColumnType("int")
                        .HasComment("How well the diamond is cut");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Server file system image path");

                    b.Property<int>("Metal")
                        .HasColumnType("int")
                        .HasComment("Metal, which ring is made of");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)")
                        .HasComment("Name of the ring");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)")
                        .HasComment("Price of the product");

                    b.Property<string>("Purity")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)")
                        .HasComment("Purity of the metal expressed in carat for gold or sample for silver");

                    b.HasKey("Id");

                    b.ToTable("Rings");

                    b.HasComment("Ring specifications");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Carats = 1.5,
                            Clarity = 5,
                            Colour = 4,
                            Cut = 2,
                            ImagePath = "https://www.tanishq.co.in/on/demandware.static/-/Sites-Tanishq-product-catalog/default/dw5721e8ec/images/hi-res/50D2FFFFRAA02_1.jpg",
                            Metal = 2,
                            Name = "Gold Diamond Ring",
                            Price = 1000.00m,
                            Purity = "18K"
                        },
                        new
                        {
                            Id = 2,
                            Carats = 4.0,
                            Clarity = 3,
                            Colour = 4,
                            Cut = 1,
                            ImagePath = "https://4.imimg.com/data4/QW/YU/FUSIONI-3520335/prod-image.jpg",
                            Metal = 2,
                            Name = "Gold Ring With Crown Diamond",
                            Price = 10020.00m,
                            Purity = "18K"
                        },
                        new
                        {
                            Id = 3,
                            Carats = 3.0,
                            Clarity = 5,
                            Colour = 4,
                            Cut = 1,
                            ImagePath = "https://love-and-co.com/cdn/shop/files/CR591-LGD_lifestyle.jpg?v=1697793277&width=2000",
                            Metal = 4,
                            Name = "Rose Gold Diamond Ring",
                            Price = 12000.00m,
                            Purity = "18K"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "9335a540-c8df-483c-a42f-ca016f7a06fd",
                            Email = "admin@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "admin@gmail.com",
                            NormalizedUserName = "admin@gmail.com",
                            PasswordHash = "AQAAAAEAACcQAAAAEMIDobjI3gJkJRI6/cVu+JGZsH9QeHDNWm9xBoP0sZH6Yvl5CCwxdcXALQ9XuEAw4A==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "c6fe2474-e5b1-41ca-957d-7e15e32b90a4",
                            TwoFactorEnabled = false,
                            UserName = "admin@gmail.com"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
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
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
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

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
