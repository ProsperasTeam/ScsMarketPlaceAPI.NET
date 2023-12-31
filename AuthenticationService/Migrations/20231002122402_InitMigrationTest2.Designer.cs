﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using AuthenticationService.Persistence;

#nullable disable

namespace AuthenticationService.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231002122402_InitMigrationTest2")]
    partial class InitMigrationTest2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AuthenticationService.Models.Account.AccountModel", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("id"));

                    b.Property<DateTimeOffset>("collectedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("consumerId")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset>("denied")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("depositAcct")
                        .HasColumnType("text");

                    b.Property<long>("listingId")
                        .HasColumnType("bigint");

                    b.Property<string>("name")
                        .HasColumnType("text");

                    b.Property<long>("productId")
                        .HasColumnType("bigint");

                    b.HasKey("id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("AuthenticationService.Models.Config.ConfigOrgModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Relational:JsonPropertyName", "id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasAnnotation("Relational:JsonPropertyName", "name");

                    b.HasKey("Id");

                    b.ToTable("Configs");
                });

            modelBuilder.Entity("AuthenticationService.Models.Country.CountryModel", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("id"));

                    b.Property<string>("locale")
                        .HasColumnType("text");

                    b.Property<string>("name")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("AuthenticationService.Models.Organization.OrganizationModel", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("id"));

                    b.Property<string>("name")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("AuthenticationService.Models.ProductCategoryModel", b =>
                {
                    b.Property<long?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long?>("Id"));

                    b.Property<long?>("CountryId")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset?>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<long?>("HighAmount")
                        .HasColumnType("bigint");

                    b.Property<string>("Icon")
                        .HasColumnType("text");

                    b.Property<long?>("LowAmount")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset?>("Modified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int?>("OrderBy")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
