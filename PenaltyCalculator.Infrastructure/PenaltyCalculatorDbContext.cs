using System;
using Microsoft.EntityFrameworkCore;
using PenaltyCalculator.Core.Entities;
namespace PenaltyCalculator.Infrastructure
{
    public class PenaltyCalculatorDbContext : DbContext
    {
        public PenaltyCalculatorDbContext(DbContextOptions<PenaltyCalculatorDbContext> options) : base(options)
        {

        }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Holiday> Holidays { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Currency>().HasData(new Currency()
            {
                Id = 1,
                Name = "Turk Lirası"
            }, new Currency()
            {
                Id = 2,
                Name = "Dirhem"

            });
            modelBuilder.Entity<Country>().HasData(new Country(){
                Id=1,
                Name="Türkiye",
                CurrencyId=1,
                PenaltyAmount=10,
                WeeklyHolidays=DayOfTheWeek.Saturday | DayOfTheWeek.Sunday
            }, new Country(){
                Id=2,
                Name="Birleşik Arap Emirlikleri",
                CurrencyId=2,
                PenaltyAmount=15,
                WeeklyHolidays=DayOfTheWeek.Friday | DayOfTheWeek.Saturday
            });
            modelBuilder.Entity<Holiday>().HasData(new Holiday(){
                CountryId=1,
                Id=1,
                Name="19 Mayıs",
                DateTime= new DateTime (1,5,19)
            },new Holiday(){
                Id=2,
                CountryId=2,
                Name="Arafat Dağı Günü",
                DateTime= new DateTime(1,7,19)
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}