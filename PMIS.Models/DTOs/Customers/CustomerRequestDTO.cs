using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMIS.Models.DTOs.Customers
{
    public class CustomerRequestDTO
    {
        public CustomerRequestDTO()
        {
            PageSize = 10;
            CurrentPage = 1; 
        }
        public string? FilterText { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }

        public int? PageSize { get; set; }
        public int? CurrentPage { get; set; }



    }
}
