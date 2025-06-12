using System.ComponentModel.DataAnnotations;

namespace Bank_mangement_system.DTOs
{
    public class BranchDto
    {
        [MaxLength(100)]
        public string? Name { get; set; }
        public string? Location { get; set; }
    }

    public class BranchCustomerDto
    {
        [Required]
        [MaxLength(100)]
        public string? Name { get; set; }
        [Required]
        public string? Location { get; set; }
        public List<int>? CustomersId { get; set; }
    }
    public class GetBranchCustomerssDto
    {
        [Required]
        [MaxLength(100)]
        public string? Name { get; set; }
        [Required]
        public string? Location { get; set; }
        public List<Customto>? GetCustomerdtos { get; set; }
    }

}


