using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CurrencyApp.Models
{
    public class CurrencyModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public decimal BuyRate { get; set; }


        [Required]
        public decimal SellRate { get; set; }


        [Required]
        [MaxLength(3)]
        public string Currency { get; set; }

        public DateTime Date { get; set; }
    }
}
