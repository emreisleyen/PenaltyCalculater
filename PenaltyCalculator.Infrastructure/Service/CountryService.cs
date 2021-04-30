using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PenaltyCalculator.Core.Entities;
using PenaltyCalculator.Infrastructure.DTO;
using PenaltyCalculator.Infrastructure.Repository;
using PenaltyCalculator.Infrastructure.Repository.Abstract;
using PenaltyCalculator.Infrastructure.Service.Abstract;

namespace PenaltyCalculator.Infrastructure.Service
{
    public class CountryService : ICountryService
    {
        private readonly IRepository<Country> _repository;
        private readonly IMapper _mapper;

        public CountryService(IRepository<Country> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<CountryDTO> GetCountries()
        {
            IEnumerable<CountryDTO> countryDtos = _mapper.Map<IEnumerable<CountryDTO>>(_repository.GetQueryable());
            return countryDtos;
        }

        public Country GetCountry(int id)
        {
            return _repository.GetQueryable()
                .Include(x => x.Currency)
                .FirstOrDefault(x => x.Id == id);
        }
    }
    
}