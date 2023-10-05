﻿// <auto-generated />
using System;
using BusinessService.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BusinessService.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231005144401_InitMigrations")]
    partial class InitMigrations
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BusinessService.Models.Business.BusinessModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("address1")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("address2")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("age")
                        .HasColumnType("integer");

                    b.Property<string>("city")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("consumerid")
                        .HasColumnType("integer");

                    b.Property<int?>("countryid")
                        .HasColumnType("integer");

                    b.Property<DateTime>("created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("deleted")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("modified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("postalcode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("stateid")
                        .HasColumnType("integer");

                    b.Property<string>("taxid")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("Business");
                });
#pragma warning restore 612, 618
        }
    }
}
