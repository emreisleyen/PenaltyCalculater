using Microsoft.EntityFrameworkCore;
using PenaltyCalculator.Core.Entities;
using PenaltyCalculator.Infrastructure.Repository.Abstract;

namespace PenaltyCalculator.Infrastructure.Repository
{
    public class CurrencyRepository : BaseRepository<Currency>
    {
        public CurrencyRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}