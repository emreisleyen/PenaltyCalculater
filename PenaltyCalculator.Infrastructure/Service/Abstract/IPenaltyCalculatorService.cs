using System;
using PenaltyCalculator.Infrastructure.DTO;

namespace PenaltyCalculator.Infrastructure.Service.Abstract
{
    public interface IPenaltyCalculatorService
    {
        PenaltyCalculationResultDTO Calculate(DateTime checkoutDate, DateTime returnDate, int countryId);
    }
}