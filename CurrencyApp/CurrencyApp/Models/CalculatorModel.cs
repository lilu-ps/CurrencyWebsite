using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CurrencyApp.Models
{
    public class CalculatorModel
    {
        [Key]
        public int Id { get; set; }
        public decimal Rate { get; set; }

        public string fromCurrency { get; set; }
        [MaxLength(3)]
        public string toCurrency { get; set; }
        public DateTime CreateDatetime { get; set; }

        public int sell { get; set; }
        public int buy { get; set; }

       

    }
}
