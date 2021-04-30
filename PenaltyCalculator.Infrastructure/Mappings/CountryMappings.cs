using AutoMapper;
using PenaltyCalculator.Core.Entities;
using PenaltyCalculator.Infrastructure.DTO;

namespace PenaltyCalculator.Infrastructure.Mappings
{
    public class CountryMappings : Profile
    {
        public CountryMappings()
        {
            CreateMap<Country, CountryDTO>();
            CreateMap<Currency, CurrencyDTO>();
            CreateMap<Holiday, HolidayDTO>();
        }
    }
}