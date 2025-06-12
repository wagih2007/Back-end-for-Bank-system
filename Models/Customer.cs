using System.ComponentModel.DataAnnotations;

namespace Bank_mangement_system.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string ?EmailAddress { get; set; }
        public string ? PhoneNumber { get; set; }
        public BankCard? bankCard { get; set; }  

        public List<Branch> ?branches { get; set; } 
        public List<Account> ?Accounts { get; set; } 
    }
}

