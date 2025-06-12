using System.ComponentModel.DataAnnotations;

namespace Bank_mangement_system.DTOs
{
    public class BankCardDto
    {
        [MaxLength(16)]
        public string ? CardNumber { get; set; }
        public DateTime ?ExpiryDate { get; set; }
    }
}
