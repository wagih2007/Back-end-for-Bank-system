using System.ComponentModel.DataAnnotations;

namespace Bank_mangement_system.DTOs
{
    public class AccountDto
    {
        [Required]
        [MaxLength(20)]
        public string? AccountNumber { get; set; }
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "The number must be positive. ")]
        public decimal Balance { get; set; }
    }
    public class AccountuserDto
    {
        [Required]
        [MaxLength(20)]
        public string? AccountNumber { get; set; }
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "The number must be positive. ")]
        public decimal Balance { get; set; }
        public int CustomerId {  get; set; }
    }

}
