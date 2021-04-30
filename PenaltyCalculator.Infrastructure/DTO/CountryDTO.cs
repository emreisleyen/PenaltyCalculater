using System;
using System.Collections.Generic;
using PenaltyCalculator.Core.Entities;

namespace PenaltyCalculator.Infrastructure.DTO
{
    public class CountryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CurrencyDTO Currency { get; set; }
        public int CurrencyId { get; set; }
        public ICollection<HolidayDTO> Holidays { get; set; }
        public DayOfTheWeek WeeklyHolidays { get; set; }
        public double PenaltyAmount { get; set; }
    }

    public class CurrencyDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class HolidayDTO
    {
        public string Name { get; set; }
        public DateTime DateTime { get; set; }
        public CountryDTO Country { get; set; }
        public int CountryId { get; set; }
    }
}