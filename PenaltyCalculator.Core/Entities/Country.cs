using System.Collections.Generic;
using PenaltyCalculator.Core.Entities.Abstract;
namespace PenaltyCalculator.Core.Entities
{
    public class Country:BaseEntity
    {
        public string Name { get; set; }
        public Currency Currency { get; set; }
        public int CurrencyId { get; set; }
        public ICollection<Holiday>  Holidays { get; set; }
        public double PenaltyAmount { get; set; }
        public DayOfTheWeek WeeklyHolidays { get; set; }

    }
    public enum DayOfTheWeek
    {
        Monday=1,
        Tuesday=2,
        Wednesday=4,
        Thursday=8,
        Friday=16,
        Saturday=32,
        Sunday=64

    }
}