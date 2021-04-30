﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PenaltyCalculator.Infrastructure;

namespace PenaltyCalculator.Infrastructure.Migrations
{
    [DbContext(typeof(PenaltyCalculatorDbContext))]
    [Migration("20210403155221_PenaltyBooking")]
    partial class PenaltyBooking
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PenaltyCalculator.Core.Entities.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CurrencyId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("PenaltyAmount")
                        .HasColumnType("float");

                    b.Property<int>("WeeklyHolidays")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CurrencyId");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CurrencyId = 1,
                            Name = "Türkiye",
                            PenaltyAmount = 10.0,
                            WeeklyHolidays = 96
                        },
                        new
                        {
                            Id = 2,
                            CurrencyId = 2,
                            Name = "Birleşik Arap Emirlikleri",
                            PenaltyAmount = 15.0,
                            WeeklyHolidays = 48
                        });
                });

            modelBuilder.Entity("PenaltyCalculator.Core.Entities.Currency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Currencies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Turk Lirası"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Dirhem"
                        });
                });

            modelBuilder.Entity("PenaltyCalculator.Core.Entities.Holiday", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Holidays");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CountryId = 1,
                            DateTime = new DateTime(1, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "19 Mayıs"
                        },
                        new
                        {
                            Id = 2,
                            CountryId = 2,
                            DateTime = new DateTime(1, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Arafat Dağı Günü"
                        });
                });

            modelBuilder.Entity("PenaltyCalculator.Core.Entities.Country", b =>
                {
                    b.HasOne("PenaltyCalculator.Core.Entities.Currency", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Currency");
                });

            modelBuilder.Entity("PenaltyCalculator.Core.Entities.Holiday", b =>
                {
                    b.HasOne("PenaltyCalculator.Core.Entities.Country", null)
                        .WithMany("Holidays")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PenaltyCalculator.Core.Entities.Country", b =>
                {
                    b.Navigation("Holidays");
                });
#pragma warning restore 612, 618
        }
    }
}