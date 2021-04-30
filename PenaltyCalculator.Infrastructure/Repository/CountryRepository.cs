using Microsoft.EntityFrameworkCore;
using PenaltyCalculator.Core.Entities;
using PenaltyCalculator.Infrastructure.Repository.Abstract;

namespace PenaltyCalculator.Infrastructure.Repository
{
    public class CountryRepository : BaseRepository<Country>
    {
        public CountryRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}