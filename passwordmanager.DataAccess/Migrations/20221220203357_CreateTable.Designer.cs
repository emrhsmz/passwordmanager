﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using passwordmanager.DataAccess.Concrete.EntityFramework.Context;

#nullable disable

namespace passwordmanager.DataAccess.Migrations
{
    [DbContext(typeof(PasswordManagerContext))]
    [Migration("20221220203357_CreateTable")]
    partial class CreateTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("passwordmanager.Entities.Concrete.AccountProperty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AccountName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreateBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifyBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlatformId")
                        .HasColumnType("int");

                    b.Property<int>("SafeId")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<int>("SystemTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PlatformId");

                    b.HasIndex("SafeId");

                    b.HasIndex("SystemTypeId");

                    b.ToTable("AccountProperties");
                });

            modelBuilder.Entity("passwordmanager.Entities.Concrete.Favorite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AccountPropertyId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AccountPropertyId");

                    b.ToTable("Favorites");
                });

            modelBuilder.Entity("passwordmanager.Entities.Concrete.Platform", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<int>("SystemTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("SystemTypeId");

                    b.ToTable("Platforms");
                });

            modelBuilder.Entity("passwordmanager.Entities.Concrete.Safe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Safes");
                });

            modelBuilder.Entity("passwordmanager.Entities.Concrete.SystemType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("SystemTypes");
                });

            modelBuilder.Entity("passwordmanager.Entities.Concrete.AccountProperty", b =>
                {
                    b.HasOne("passwordmanager.Entities.Concrete.Platform", "Platform")
                        .WithMany()
                        .HasForeignKey("PlatformId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("passwordmanager.Entities.Concrete.Safe", "Safe")
                        .WithMany("AccountProperties")
                        .HasForeignKey("SafeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("passwordmanager.Entities.Concrete.SystemType", "SystemType")
                        .WithMany("AccountProperties")
                        .HasForeignKey("SystemTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Platform");

                    b.Navigation("Safe");

                    b.Navigation("SystemType");
                });

            modelBuilder.Entity("passwordmanager.Entities.Concrete.Favorite", b =>
                {
                    b.HasOne("passwordmanager.Entities.Concrete.AccountProperty", "AccountProperty")
                        .WithMany("Favorites")
                        .HasForeignKey("AccountPropertyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("AccountProperty");
                });

            modelBuilder.Entity("passwordmanager.Entities.Concrete.Platform", b =>
                {
                    b.HasOne("passwordmanager.Entities.Concrete.SystemType", "SystemType")
                        .WithMany("Platforms")
                        .HasForeignKey("SystemTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("SystemType");
                });

            modelBuilder.Entity("passwordmanager.Entities.Concrete.AccountProperty", b =>
                {
                    b.Navigation("Favorites");
                });

            modelBuilder.Entity("passwordmanager.Entities.Concrete.Safe", b =>
                {
                    b.Navigation("AccountProperties");
                });

            modelBuilder.Entity("passwordmanager.Entities.Concrete.SystemType", b =>
                {
                    b.Navigation("AccountProperties");

                    b.Navigation("Platforms");
                });
#pragma warning restore 612, 618
        }
    }
}
