using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditCalculator.Models
{
    public class CalculatedAnniCredit:CalculatedCredit
    {
        public decimal Payment { get; set; }
        public List<CreditPayment> Payments { get; set; }        

        public CalculatedAnniCredit()
        {
            Payments = new List<CreditPayment>();
        }
    }
}
