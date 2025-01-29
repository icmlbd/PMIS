using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMIS.Models.DTOs.Customers
{
    public class CustomerResponseDTO
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Phone { get; set; }
        public string? Address { get; set; }

        public int Age { get; set; }
        public DateTime? DOB { get; set; }

        public string? Gender { get; set; }

        //public string EmailAddress { get; set; }

        public string? AddressCity { get; set; }

        public int? CategoryId { get; set; }

        public CategoryDTO Category { get; set; }
    }
}
