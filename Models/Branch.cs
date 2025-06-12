using System.ComponentModel.DataAnnotations;

namespace Bank_mangement_system.Models
{
    public class Branch
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]    
        public string ?Name { get; set; }
        [Required]
        public string ?Location { get; set; }

        public List<Customer> ?Customers { get; set; }
    }
}
