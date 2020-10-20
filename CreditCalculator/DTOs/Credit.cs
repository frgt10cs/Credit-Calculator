using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CreditCalculator.DTOs
{
    public enum CreditType { Diff, Anni }
    public enum RateMode { Month, Day }
    public class Credit
    {
        [Required]
        public CreditType CreditType { get; set; } = CreditType.Anni;

        [Required(ErrorMessage = "Сумма обязательна")]
        [Range(0, double.PositiveInfinity, ErrorMessage = "Неверное значение")]
        [DataType(DataType.Currency, ErrorMessage = "Не соответствует числу")]
        public decimal Sum { get; set; }

        [Required(ErrorMessage = "Срок обязателен")]
        [Range(0, uint.MaxValue, ErrorMessage = "Неверное значение")]
        public uint Term { get; set; }

        [Required(ErrorMessage = "Ставка обязательна")]
        [Range(0, 100, ErrorMessage = "Неверное значение")]
        [DataType(DataType.Currency, ErrorMessage = "Не соответствует числу")]
        public double Rate { get; set; }

        [Required(ErrorMessage = "Шаг обязателен")]
        public uint Step { get; set; } = 1;

        [Required]
        public RateMode RateMode { get; set; } = RateMode.Month;
    }
}
