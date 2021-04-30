using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PenaltyCalculator.Core.Entities;
using PenaltyCalculator.Infrastructure.DTO;
using PenaltyCalculator.Infrastructure.Repository.Abstract;
using PenaltyCalculator.Infrastructure.Service.Abstract;

namespace PenaltyCalculator.Infrastructure.Service
{
    public class PenaltyCalculatorService : IPenaltyCalculatorService
    {
        private static readonly Dictionary<int, DayOfTheWeek> Converter = new()
        {
            {1, DayOfTheWeek.Monday},
            {2, DayOfTheWeek.Tuesday},
            {3, DayOfTheWeek.Wednesday},
            {4, DayOfTheWeek.Thursday},
            {5, DayOfTheWeek.Friday},
            {6, DayOfTheWeek.Saturday},
            {0, DayOfTheWeek.Sunday}
        };
        private readonly IRepository<Country> _repository;

        public PenaltyCalculatorService(IRepository<Country> repository)
        {
            _repository = repository;
        }

        public PenaltyCalculationResultDTO Calculate(DateTime checkoutDate, DateTime returnDate, int countryId)
        {
            var country = _repository.GetQueryable()
                .Include(x => x.Holidays)
                .Include(x => x.Currency)
                .FirstOrDefault(x => x.Id == countryId);
            var penaltyDay = checkoutDate.AddDays(11);
            double penaltyAmount = 0;
            var calculatedDays = 0;
            if (penaltyDay < returnDate)
            {
                for (var currentDate = penaltyDay; currentDate <= returnDate; currentDate = currentDate.AddDays(1))
                {
                    var dayOfTheWeek = Converter[(int) currentDate.DayOfWeek];
                    if (!country.WeeklyHolidays.HasFlag(dayOfTheWeek) && !CheckIfHoliday(currentDate, country.Holidays))
                    {
                        penaltyAmount += country.PenaltyAmount;
                        calculatedDays++;
                    }
                }
            }

            return new PenaltyCalculationResultDTO
            {
                PenaltyAmount = penaltyAmount,
                PenaltyDayCount = calculatedDays
            };
        }
        
        private bool CheckIfHoliday(DateTime date, IEnumerable<Holiday> holidays)
        {
            var month = date.Month;
            var day = date.Day;
            foreach (var holiday in holidays)
            {
                if (month == holiday.DateTime.Month && day == holiday.DateTime.Day)
                {
                    return true;
                }
            }

            return false;
        }
    }
}