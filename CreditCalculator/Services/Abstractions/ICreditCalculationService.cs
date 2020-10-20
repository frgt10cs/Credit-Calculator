using CreditCalculator.DTOs;
using CreditCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditCalculator.Services.Abstractions
{
    public interface ICreditCalculationService
    {
        CalculatedDiffCredit CalculateDiffCredit(Credit credit);
        CalculatedAnniCredit CalculateAnniCredit(Credit credit);
    }
}
