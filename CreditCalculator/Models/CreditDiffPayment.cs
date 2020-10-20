using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditCalculator.Models
{
    public class CreditDiffPayment:CreditPayment
    {
        public decimal BodyPayment { get; set; }
        public decimal PercentPayment { get; set; }
        public decimal ResultPayment { get => BodyPayment + PercentPayment; }
    }
}
