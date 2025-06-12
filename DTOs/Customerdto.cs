using Bank_mangement_system.Models;
using System.ComponentModel.DataAnnotations;

namespace Bank_mangement_system.DTOs
{
    public class Customerdto
    {
        [Required]
        [MaxLength(100)]
        public string? Name { get; set; }
        [Required]
        [EmailAddress]
        public string? EmailAddress { get; set; }
        public string? PhoneNumber { get; set; }
        public BankCardDto? bankCarddto { get; set; }

        public List<BranchDto>? BranchDtos { get; set; }
        public List<AccountDto>? AccountDtos { get; set; }
    }
    public class Customto
    {
        [Required]
        [MaxLength(100)]
        public string? Name { get; set; }
        [Required]
        [EmailAddress]
        public string? EmailAddress { get; set; }
        public string? PhoneNumber { get; set; }
        public List<AccountDto>? AccountDtos { get; set; }
    }

    public class CustomerBranchdto
    {
        [Required]
        [MaxLength(100)]
        public string? Name { get; set; }
        [Required]
        [EmailAddress]
        public string? EmailAddress { get; set; }
        public string? PhoneNumber { get; set; }
    }
    }
