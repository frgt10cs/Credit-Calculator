using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditCalculator.Models
{
    public class CalculatedDiffCredit:CalculatedCredit
    {
        public List<CreditDiffPayment> Payments { get; set; }

        public CalculatedDiffCredit()
        {
            Payments = new List<CreditDiffPayment>();
        }
    }
}
