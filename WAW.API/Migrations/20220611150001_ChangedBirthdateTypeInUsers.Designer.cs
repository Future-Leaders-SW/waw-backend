﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WAW.API.Shared.Persistence.Contexts;

#nullable disable

namespace WAW.API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220611150001_ChangedBirthdateTypeInUsers")]
    partial class ChangedBirthdateTypeInUsers
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("WAW.API.Auth.Domain.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<string>("About")
                        .HasColumnType("longtext")
                        .HasColumnName("about");

                    b.Property<string>("Biography")
                        .HasColumnType("longtext")
                        .HasColumnName("biography");

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("birthdate");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("email");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("full_name");

                    b.Property<string>("Location")
                        .HasColumnType("longtext")
                        .HasColumnName("location");

                    b.Property<string>("PreferredName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("preferred_name");

                    b.HasKey("Id")
                        .HasName("p_k_users");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("WAW.API.Employers.Domain.Models.Company", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<string>("Address")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("address");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("p_k_companies");

                    b.ToTable("companies", (string)null);
                });

            modelBuilder.Entity("WAW.API.Job.Domain.Models.Offer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("description");

                    b.Property<string>("Image")
                        .HasMaxLength(2048)
                        .HasColumnType("varchar(2048)")
                        .HasColumnName("image");

                    b.Property<string>("SalaryRange")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("salary_range");

                    b.Property<bool>("Status")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("status");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("title");

                    b.HasKey("Id")
                        .HasName("p_k_offers");

                    b.ToTable("offers", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
