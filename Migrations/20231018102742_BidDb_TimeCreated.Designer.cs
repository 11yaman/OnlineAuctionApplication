﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnlineAuctionApplication.Persistence;

#nullable disable

namespace OnlineAuctionApplication.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231018102742_BidDb_TimeCreated")]
    partial class BidDb_TimeCreated
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OnlineAuctionApplication.Persistence.Entities.AuctionDb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("SellerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("StartingPrice")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("SellerId");

                    b.ToTable("AuctionDbs");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            Description = "Description for Auction 1",
                            EndTime = new DateTime(2023, 10, 19, 12, 27, 42, 124, DateTimeKind.Local).AddTicks(929),
                            Name = "Auction 1",
                            SellerId = "-1",
                            StartingPrice = 100.0
                        },
                        new
                        {
                            Id = -2,
                            Description = "Description for Auction 2",
                            EndTime = new DateTime(2023, 10, 20, 12, 27, 42, 124, DateTimeKind.Local).AddTicks(1024),
                            Name = "Auction 2",
                            SellerId = "-2",
                            StartingPrice = 50.0
                        });
                });

            modelBuilder.Entity("OnlineAuctionApplication.Persistence.Entities.BidDb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<int>("AuctionId")
                        .HasColumnType("int");

                    b.Property<string>("BidderId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("TimeCreated")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AuctionId");

                    b.HasIndex("BidderId");

                    b.ToTable("BidDbs");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            Amount = 120.0,
                            AuctionId = -1,
                            BidderId = "-2",
                            TimeCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = -2,
                            Amount = 60.0,
                            AuctionId = -2,
                            BidderId = "-1",
                            TimeCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("OnlineAuctionApplication.Persistence.Entities.UserDb", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("UserDbs");

                    b.HasData(
                        new
                        {
                            Id = "-1",
                            Username = "user1"
                        },
                        new
                        {
                            Id = "-2",
                            Username = "user2"
                        });
                });

            modelBuilder.Entity("OnlineAuctionApplication.Persistence.Entities.AuctionDb", b =>
                {
                    b.HasOne("OnlineAuctionApplication.Persistence.Entities.UserDb", "Seller")
                        .WithMany("AuctionDbs")
                        .HasForeignKey("SellerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Seller");
                });

            modelBuilder.Entity("OnlineAuctionApplication.Persistence.Entities.BidDb", b =>
                {
                    b.HasOne("OnlineAuctionApplication.Persistence.Entities.AuctionDb", "Auction")
                        .WithMany("BidDbs")
                        .HasForeignKey("AuctionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineAuctionApplication.Persistence.Entities.UserDb", "Bidder")
                        .WithMany("BidDbs")
                        .HasForeignKey("BidderId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Auction");

                    b.Navigation("Bidder");
                });

            modelBuilder.Entity("OnlineAuctionApplication.Persistence.Entities.AuctionDb", b =>
                {
                    b.Navigation("BidDbs");
                });

            modelBuilder.Entity("OnlineAuctionApplication.Persistence.Entities.UserDb", b =>
                {
                    b.Navigation("AuctionDbs");

                    b.Navigation("BidDbs");
                });
#pragma warning restore 612, 618
        }
    }
}
