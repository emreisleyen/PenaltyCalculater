using System.Collections.Generic;
using PenaltyCalculator.Core.Entities;
using PenaltyCalculator.Infrastructure.DTO;

namespace PenaltyCalculator.Infrastructure.Service.Abstract
{
    public interface ICountryService
    {
        IEnumerable<CountryDTO> GetCountries();
        Country GetCountry(int id);
    }
}