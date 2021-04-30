using AutoMapper;
using PenaltyCalculator.Infrastructure.DTO;
using PenaltyCalculator.MVC.Models;

namespace PenaltyCalculator.Mappings
{
    public class CountryMappings : Profile
    {
        public CountryMappings()
        {
            CreateMap<CountryDTO, CountryViewModel>()
                .ForMember(model => model.CountryId, expression => expression.MapFrom(dto => dto.Id));
        }
    }
}