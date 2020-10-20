using CreditCalculator.DTOs;
using CreditCalculator.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices.WindowsRuntime;

namespace CreditCalculator.Controllers
{
    public class CreditController : Controller
    {
        private ICreditCalculationService creditCalculationService;
        public CreditController(ICreditCalculationService creditCalculationService)
        {
            this.creditCalculationService = creditCalculationService;
        }
        public IActionResult Calculator() => View(new Credit());   
        
        [HttpPost]
        public IActionResult Calculator(Credit credit)
        {
            if (ModelState.IsValid)
            {
                if(credit.CreditType == CreditType.Anni)
                {
                    var calculatedAnni = creditCalculationService.CalculateAnniCredit(credit);
                    return View("CalculatedAnniCredit", calculatedAnni);
                }
                var calculatedDiff = creditCalculationService.CalculateDiffCredit(credit);
                return View("CalculatedDiffCredit", calculatedDiff);
            }
            else
            {
                return View(credit);
            }
        }
    }
}
