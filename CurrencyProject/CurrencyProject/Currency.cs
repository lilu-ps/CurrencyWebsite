using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CurrencyProject
{
    class Currency
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(3)]
        public decimal CurrencyValue { get; set; }

        public string fromCurrency { get; set; }
        [MaxLength(3)]
        public string toCurrency { get; set; }
        public DateTime Datetime { get; set; }
    }
}
