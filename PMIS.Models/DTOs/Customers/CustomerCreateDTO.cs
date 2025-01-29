using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PMIS.Models.DTOs.Customers
{
    [XmlRoot]
    public class CustomerCreateDTO
    {
        [Required]
        [XmlElement]
        public string Name { get; set; }
        [Required]
        [XmlElement]
        public string Phone { get; set; }
        public string? Address { get; set; }
        [XmlElement]
        public int Age { get; set; }
        public DateTime? DOB { get; set; }

        public string? Gender { get; set; }

        public string? AddressCity { get; set; }

        public int? CategoryId { get; set; }
    }
}
