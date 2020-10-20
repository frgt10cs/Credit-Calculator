using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditCalculator.Models
{
    public class CalculatedCredit
    {
        public decimal CreditSum { get; set; }
        public decimal Debt { get; set; }           
        public decimal OverPayment { get; set; }       
    }
}
