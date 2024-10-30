using Microsoft.AspNetCore.Mvc.Rendering;
using PMIS.Models.EntityModels;
using PMIS.WebApp.ValidationAttributes;
using System.ComponentModel.DataAnnotations;

namespace PMIS.WebApp.Models.ViewModels
{
    public class CustomerCreateViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Phone { get; set; }

        [MinLength(5)]
        [MaxLength(150)]
        public string? Address { get; set; }

        [Age(21, 90, ErrorMessage = "Age is not fulfilled as per requirement")]

        public int Age { get; set; }

        public string? AddressCity { get; set; }

        public string? Division { get; set; }


        public int? CategoryId { get; set; }


        public List<Customer>? Customers { get; set; }

        public IEnumerable<SelectListItem>? CustomerCategories { get; set; }
    }
}
