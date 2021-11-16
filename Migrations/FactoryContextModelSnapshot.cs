﻿// <auto-generated />
using System;
using Alere.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Alere.Migrations
{
    [DbContext(typeof(FactoryContext))]
    partial class FactoryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Alere.Models.Address", b =>
                {
                    b.Property<long>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Complement")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("District")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZipCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AddressId");

                    b.ToTable("Tbl_Address");
                });

            modelBuilder.Entity("Alere.Models.Food", b =>
                {
                    b.Property<long>("FoodId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ExpireAt")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsPerishable")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsReserved")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ManufacturedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ReservedUntil")
                        .HasColumnType("datetime2");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<string>("UrlImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("FoodId");

                    b.HasIndex("UserId");

                    b.ToTable("Tbl_Food");
                });

            modelBuilder.Entity("Alere.Models.Requisition", b =>
                {
                    b.Property<long>("RequisitionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2")
                        .HasColumnName("Requisition_Date");

                    b.Property<long?>("DonorId")
                        .HasColumnType("bigint");

                    b.Property<long?>("FoodId")
                        .HasColumnType("bigint");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("ReceiverId")
                        .HasColumnType("bigint");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("RequisitionId");

                    b.HasIndex("DonorId");

                    b.HasIndex("FoodId");

                    b.HasIndex("ReceiverId");

                    b.ToTable("Tbl_Requisition");
                });

            modelBuilder.Entity("Alere.Models.User", b =>
                {
                    b.Property<long>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("AddressId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Photo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.HasIndex("AddressId");

                    b.ToTable("Tbl_User");
                });

            modelBuilder.Entity("Alere.Models.Food", b =>
                {
                    b.HasOne("Alere.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Alere.Models.Requisition", b =>
                {
                    b.HasOne("Alere.Models.User", "Donor")
                        .WithMany("OrdersReceived")
                        .HasForeignKey("DonorId");

                    b.HasOne("Alere.Models.Food", "Food")
                        .WithMany()
                        .HasForeignKey("FoodId");

                    b.HasOne("Alere.Models.User", "Receiver")
                        .WithMany("OrdersPlaced")
                        .HasForeignKey("ReceiverId");

                    b.Navigation("Donor");

                    b.Navigation("Food");

                    b.Navigation("Receiver");
                });

            modelBuilder.Entity("Alere.Models.User", b =>
                {
                    b.HasOne("Alere.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.Navigation("Address");
                });

            modelBuilder.Entity("Alere.Models.User", b =>
                {
                    b.Navigation("OrdersPlaced");

                    b.Navigation("OrdersReceived");
                });
#pragma warning restore 612, 618
        }
    }
}
