using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bank_mangement_system.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string ?AccountNumber { get; set; }
        [Required]
        [Range(0.01, double.MaxValue,ErrorMessage ="The number must be positive. ")]
        public decimal Balance { get; set; }
        public int CustomerId { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public Customer ?Customer { get; set; }


    }
}
