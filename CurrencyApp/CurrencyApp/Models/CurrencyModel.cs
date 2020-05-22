using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace CurrencyApp.Models
{
    public class CurrencyModel
    {
        [Key]
        public int Id { get; set; }
        //[MaxLength(3)]
        public decimal Rate { get; set; }

        public string fromCurrency { get; set; }
        [MaxLength(3)]
        public string toCurrency { get; set; }
        public DateTime CreateDatetime { get; set; }
        public DateTime UpdateDatetime { get; set; }
        public int Removed { get; set; } = 0;
    }
}
