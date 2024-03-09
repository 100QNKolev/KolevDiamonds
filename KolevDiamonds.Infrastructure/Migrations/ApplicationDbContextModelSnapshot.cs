﻿// <auto-generated />
using System;
using KolevDiamonds.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KolevDiamonds.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.27")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("KolevDiamonds.Infrastructure.Data.Models.InvestmentCoin", b =>
                {
                    b.Property<int>("CoindId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Coin unique identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CoindId"), 1L, 1);

                    b.Property<int>("Circulation")
                        .HasColumnType("int")
                        .HasComment("Number of pieces in circulation");

                    b.Property<double>("Diameter")
                        .HasColumnType("float")
                        .HasComment("Diameter of the coin in millimeters");

                    b.Property<string>("LegalTender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Legal tender value in the specified currency");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Manufacturer of the coin");

                    b.Property<int>("Metal")
                        .HasColumnType("int")
                        .HasComment("Type of metal");

                    b.Property<string>("Packaging")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Packaging for the coin");

                    b.Property<double>("Purity")
                        .HasColumnType("float")
                        .HasComment("Purity of the metal expressed as a ratio");

                    b.Property<int>("Quality")
                        .HasColumnType("int")
                        .HasComment("Quality of the metal");

                    b.Property<double>("Weight")
                        .HasColumnType("float")
                        .HasComment("Weight of the metal in grams");

                    b.HasKey("CoindId");

                    b.ToTable("InvestmentCoins");

                    b.HasComment("Investment coin specifications");
                });

            modelBuilder.Entity("KolevDiamonds.Infrastructure.Data.Models.InvestmentDiamond", b =>
                {
                    b.Property<int>("DiamondId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Diamond unique identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DiamondId"), 1L, 1);

                    b.Property<double>("Carats")
                        .HasColumnType("float")
                        .HasComment("How much carats is the diamond");

                    b.Property<string>("CertifyingLaboratory")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
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

                    b.Property<string>("Proportions")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("The proportions of the diamond");

                    b.HasKey("DiamondId");

                    b.ToTable("InvestmentDiamonds");

                    b.HasComment("Investment diamond specifications");
                });

            modelBuilder.Entity("KolevDiamonds.Infrastructure.Data.Models.MetalBar", b =>
                {
                    b.Property<int>("BarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Metal bar unique identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BarId"), 1L, 1);

                    b.Property<string>("Dimensions")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Dimensions of the metal bar (length x width)");

                    b.Property<int>("Metal")
                        .HasColumnType("int")
                        .HasComment("Type of metal");

                    b.Property<string>("Purity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Purity of the metal expressed in carat for gold or sample for silver");

                    b.Property<double>("Weight")
                        .HasColumnType("float")
                        .HasComment("Weight of the metal bar");

                    b.HasKey("BarId");

                    b.ToTable("MetalBars");

                    b.HasComment("Metal bar specifications");
                });

            modelBuilder.Entity("KolevDiamonds.Infrastructure.Data.Models.Necklace", b =>
                {
                    b.Property<int>("NecklaceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Necklace unique identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NecklaceId"), 1L, 1);

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

                    b.Property<double>("Length")
                        .HasColumnType("float")
                        .HasComment("Length of the necklace in millimeters");

                    b.Property<int>("Metal")
                        .HasColumnType("int")
                        .HasComment("Metal, which necklace is made of");

                    b.Property<string>("Purity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Purity of the metal expressed in carat for gold or sample for silver");

                    b.HasKey("NecklaceId");

                    b.ToTable("Necklaces");

                    b.HasComment("Necklace specifications");
                });

            modelBuilder.Entity("KolevDiamonds.Infrastructure.Data.Models.Ring", b =>
                {
                    b.Property<int>("RingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Ring unique identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RingId"), 1L, 1);

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

                    b.Property<int>("Metal")
                        .HasColumnType("int")
                        .HasComment("Metal, which ring is made of");

                    b.Property<string>("Purity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Purity of the metal expressed in carat for gold or sample for silver");

                    b.HasKey("RingId");

                    b.ToTable("Rings");

                    b.HasComment("Ring specifications");
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
