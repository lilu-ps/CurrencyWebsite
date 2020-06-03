using System;
using System.ComponentModel.DataAnnotations;

namespace CurrencyApp.Models
{
    public class CurrencyModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        //[RegularExpression(@"^[1-9]\d*(\.\d+)?$", ErrorMessage = "Decimal only")]
        public decimal BuyRate { get; set; }


        [Required]
        //[RegularExpression(@"^[1-9]\d*(\.\d+)?$", ErrorMessage = "Decimal only")]
        public decimal SellRate { get; set; }


        [Required]
        [DataType(DataType.Text)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only")]
        public string Currency { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}
