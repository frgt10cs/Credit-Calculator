using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditCalculator.Models
{
    public class CreditPayment
    {
        public uint Number { get; set; }
        public DateTime Date { get; set; }
        public decimal DebtBalance { get; set; }
    }
}
