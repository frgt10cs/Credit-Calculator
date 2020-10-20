using CreditCalculator.DTOs;
using CreditCalculator.Models;
using CreditCalculator.Services.Abstractions;
using System;
using System.Linq;

namespace CreditCalculator.Services.Implementations
{
    public class CreditCalculationService : ICreditCalculationService
    {              
        public CalculatedDiffCredit CalculateDiffCredit(Credit credit)
        {            
            var step = (credit.RateMode == RateMode.Day ? credit.Step : 1);
            credit.Rate = credit.RateMode == RateMode.Month ? 
                credit.Rate / 100 : credit.Rate * 3.65;
                     
            var bodyPayment = decimal.Round(credit.Sum * step / credit.Term, 2);
            decimal debt = credit.Sum;

            var calculatedCredit = new CalculatedDiffCredit()
            {
                CreditSum = credit.Sum
            };

            var paymentDate = DateTime.Now;
            for (uint i = 0; i < credit.Term / step; i++)
            {
                paymentDate = credit.RateMode == RateMode.Month ?
                    paymentDate.AddMonths(1) : paymentDate.AddDays(step);

                var percentPayment = decimal.Round(debt * (decimal)credit.Rate * 
                    (credit.RateMode == RateMode.Month ? (uint)DateTime.DaysInMonth(paymentDate.Year, paymentDate.Month) : step)
                    / 365, 2);

                var payment = new CreditDiffPayment()
                {
                    Number = i + 1,
                    Date = paymentDate,
                    BodyPayment = bodyPayment,
                    PercentPayment = percentPayment,
                    DebtBalance = debt -= bodyPayment
                };                
                calculatedCredit.Payments.Add(payment);                
            }
            calculatedCredit.OverPayment = calculatedCredit.Payments.Sum(p => p.PercentPayment);
            calculatedCredit.Debt = calculatedCredit.CreditSum + calculatedCredit.OverPayment;

            return calculatedCredit;
        }

        public CalculatedAnniCredit CalculateAnniCredit(Credit credit)
        {
            var step = (credit.RateMode == RateMode.Day ? credit.Step : 1);            
            credit.Rate /= credit.RateMode == RateMode.Month? 1200 : 100;

            decimal coeff = (decimal)CalculateAnniCoeff(credit.Rate*step, credit.Term/step);
            decimal payment = Math.Round(coeff * credit.Sum, 2);
            decimal debt = payment * credit.Term / step;

            var calculatedCredit = new CalculatedAnniCredit
            {
                CreditSum = credit.Sum,                
                Payment = payment,
                Debt = debt,
                OverPayment = debt - credit.Sum
            };

            var paymentDate = DateTime.Now;
            for (uint i = 0; i < credit.Term / step; i++)
            {
                paymentDate = credit.RateMode == RateMode.Month ? 
                    paymentDate.AddMonths(1) : paymentDate.AddDays(step);                
                calculatedCredit.Payments.Add(new CreditPayment()
                {
                    Number = i + 1,
                    Date = paymentDate,
                    DebtBalance = debt -= calculatedCredit.Payment,
                });
            }

            return calculatedCredit;
        }

        private double CalculateAnniCoeff(double rate, uint term)
        {
            var numerator = rate * Math.Pow(1 + rate, term);
            var denominator = Math.Pow(1 + rate, term) - 1;
            return numerator / denominator;
        }
    }
}
