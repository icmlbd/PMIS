using System.ComponentModel.DataAnnotations;

namespace CustomerOrderManagementApp.Models.EntityModels
{
    public class Customer
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

        public string? AddressCity { get; set; }

        public int? CategoryId { get; set; }

        public virtual CustomerCategory? Category { get; set; }


    }
}
