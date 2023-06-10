﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieProps.DAL.Context;

#nullable disable

namespace MovieProps.DAL.Migrations
{
    [DbContext(typeof(MoviePropsContext))]
    partial class MoviePropsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MovieProps.DAL.Contract.Model.BuyerItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BuyDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("BuyPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int?>("ItemId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<DateTime>("LastUpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ItemId")
                        .IsUnique();

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("BuyerItems");
                });

            modelBuilder.Entity("MovieProps.DAL.Contract.Model.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastUpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Price")
                        .HasPrecision(12, 3)
                        .HasColumnType("decimal(12,3)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("MovieProps.DAL.Contract.Model.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastUpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("MovieProps.DAL.Contract.Model.SellerItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int?>("ItemId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<DateTime>("LastUpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("Price")
                        .HasPrecision(12, 3)
                        .HasColumnType("decimal(12,3)");

                    b.Property<int?>("UserId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ItemId")
                        .IsUnique();

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("SellerItems");
                });

            modelBuilder.Entity("MovieProps.DAL.Contract.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("BirthDay")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastUpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MovieProps.DAL.Contract.Model.BuyerItem", b =>
                {
                    b.HasOne("MovieProps.DAL.Contract.Model.Item", "Item")
                        .WithOne()
                        .HasForeignKey("MovieProps.DAL.Contract.Model.BuyerItem", "ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieProps.DAL.Contract.Model.User", "User")
                        .WithOne()
                        .HasForeignKey("MovieProps.DAL.Contract.Model.BuyerItem", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MovieProps.DAL.Contract.Model.Item", b =>
                {
                    b.HasOne("MovieProps.DAL.Contract.Model.User", null)
                        .WithMany("Items")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("MovieProps.DAL.Contract.Model.SellerItem", b =>
                {
                    b.HasOne("MovieProps.DAL.Contract.Model.Item", "Item")
                        .WithOne()
                        .HasForeignKey("MovieProps.DAL.Contract.Model.SellerItem", "ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieProps.DAL.Contract.Model.User", "User")
                        .WithOne()
                        .HasForeignKey("MovieProps.DAL.Contract.Model.SellerItem", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MovieProps.DAL.Contract.Model.User", b =>
                {
                    b.HasOne("MovieProps.DAL.Contract.Model.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("MovieProps.DAL.Contract.Model.User", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
