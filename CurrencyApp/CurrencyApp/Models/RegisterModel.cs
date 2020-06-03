using System.ComponentModel.DataAnnotations;

namespace CurrencyApp.Models
{
    public class RegisterModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(3)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only")]
        public string CurrencyCode { get; set; }

        [Required]
        //[RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only")]
        public string CurrencyName { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only")]
        public string CurrencyNameLatin { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Use numbers only")]
        public int OrderNum { get; set; }
    }
}
