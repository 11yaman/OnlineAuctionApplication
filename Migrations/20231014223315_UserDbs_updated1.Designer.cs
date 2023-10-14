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
    [Migration("20231014223315_UserDbs_updated1")]
    partial class UserDbs_updated1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OnlineAuctionApplication.Core.Models.Auction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("StartingPrice")
                        .HasColumnType("float");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Auction");
                });

            modelBuilder.Entity("OnlineAuctionApplication.Core.Models.Bid", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AuctionDbId")
                        .HasColumnType("int");

                    b.Property<int?>("AuctionId")
                        .HasColumnType("int");

                    b.Property<double>("BidAmount")
                        .HasColumnType("float");

                    b.Property<int>("BidderId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuctionDbId");

                    b.HasIndex("AuctionId");

                    b.HasIndex("BidderId");

                    b.ToTable("Bid");
                });

            modelBuilder.Entity("OnlineAuctionApplication.Core.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

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

                    b.Property<int>("SellerId")
                        .HasColumnType("int");

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
                            EndTime = new DateTime(2023, 10, 16, 0, 33, 15, 861, DateTimeKind.Local).AddTicks(4451),
                            Name = "Auction 1",
                            SellerId = -1,
                            StartingPrice = 100.0
                        },
                        new
                        {
                            Id = -2,
                            Description = "Description for Auction 2",
                            EndTime = new DateTime(2023, 10, 17, 0, 33, 15, 861, DateTimeKind.Local).AddTicks(4481),
                            Name = "Auction 2",
                            SellerId = -2,
                            StartingPrice = 50.0
                        });
                });

            modelBuilder.Entity("OnlineAuctionApplication.Persistence.Entities.BidDb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AuctionId")
                        .HasColumnType("int");

                    b.Property<double>("BidAmount")
                        .HasColumnType("float");

                    b.Property<int>("BidderId")
                        .HasColumnType("int");

                    b.Property<int?>("UserDbId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuctionId");

                    b.HasIndex("BidderId");

                    b.HasIndex("UserDbId");

                    b.ToTable("BidDbs");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            AuctionId = -1,
                            BidAmount = 120.0,
                            BidderId = -2
                        },
                        new
                        {
                            Id = -2,
                            AuctionId = -2,
                            BidAmount = 60.0,
                            BidderId = -1
                        });
                });

            modelBuilder.Entity("OnlineAuctionApplication.Persistence.Entities.UserDb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

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
                            Id = -1,
                            Username = "user1"
                        },
                        new
                        {
                            Id = -2,
                            Username = "user2"
                        });
                });

            modelBuilder.Entity("OnlineAuctionApplication.Core.Models.Auction", b =>
                {
                    b.HasOne("OnlineAuctionApplication.Core.Models.User", null)
                        .WithMany("Auctions")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("OnlineAuctionApplication.Core.Models.Bid", b =>
                {
                    b.HasOne("OnlineAuctionApplication.Persistence.Entities.AuctionDb", null)
                        .WithMany("BidDbs")
                        .HasForeignKey("AuctionDbId");

                    b.HasOne("OnlineAuctionApplication.Core.Models.Auction", null)
                        .WithMany("Bids")
                        .HasForeignKey("AuctionId");

                    b.HasOne("OnlineAuctionApplication.Core.Models.User", "Bidder")
                        .WithMany()
                        .HasForeignKey("BidderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bidder");
                });

            modelBuilder.Entity("OnlineAuctionApplication.Persistence.Entities.AuctionDb", b =>
                {
                    b.HasOne("OnlineAuctionApplication.Persistence.Entities.UserDb", "SellerDb")
                        .WithMany("AuctionDbs")
                        .HasForeignKey("SellerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SellerDb");
                });

            modelBuilder.Entity("OnlineAuctionApplication.Persistence.Entities.BidDb", b =>
                {
                    b.HasOne("OnlineAuctionApplication.Persistence.Entities.AuctionDb", "AuctionDb")
                        .WithMany()
                        .HasForeignKey("AuctionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineAuctionApplication.Persistence.Entities.UserDb", "BidderDb")
                        .WithMany()
                        .HasForeignKey("BidderId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("OnlineAuctionApplication.Persistence.Entities.UserDb", null)
                        .WithMany("BidDbs")
                        .HasForeignKey("UserDbId");

                    b.Navigation("AuctionDb");

                    b.Navigation("BidderDb");
                });

            modelBuilder.Entity("OnlineAuctionApplication.Core.Models.Auction", b =>
                {
                    b.Navigation("Bids");
                });

            modelBuilder.Entity("OnlineAuctionApplication.Core.Models.User", b =>
                {
                    b.Navigation("Auctions");
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
