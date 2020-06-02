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

        [Required]
        [MaxLength(3)]
        public string fromCurrency { get; set; }

        [Required]
        [MaxLength(3)]
        public string toCurrency { get; set; }


        public DateTime CreateDatetime { get; set; }

        [Required]
        public decimal sell { get; set; }
        [Required]
        public decimal buy { get; set; }

        

    }
}
