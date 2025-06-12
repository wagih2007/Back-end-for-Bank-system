using Bank_mangement_system.Models;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bank_mangement_system.Models
{
    public class BankCard
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(16)]
        public string ?CardNumber { get; set; }
        [Required]
        public DateTime ?ExpiryDate { get; set; }
        public int CustomerId { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public Customer ?Customer { get; set; }
    }
}
