using Microsoft.EntityFrameworkCore;
using PenaltyCalculator.Core.Entities;
using PenaltyCalculator.Infrastructure.Repository.Abstract;

namespace PenaltyCalculator.Infrastructure.Repository
{
    public class HolidayRepository : BaseRepository<Holiday>
    {
        public HolidayRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}