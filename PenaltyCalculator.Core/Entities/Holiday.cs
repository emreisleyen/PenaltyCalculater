using System;
using PenaltyCalculator.Core.Entities.Abstract;
namespace PenaltyCalculator.Core.Entities
{
    public class Holiday:BaseEntity
    {
        public string Name { get; set; }
        public DateTime DateTime { get; set; }
        public int CountryId { get; set; }
    }
}