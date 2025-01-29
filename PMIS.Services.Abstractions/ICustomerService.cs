using PMIS.Models.DTOs.Customers;
using PMIS.Models.EntityModels;
using PMIS.Services.Abstractions.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMIS.Services.Abstractions
{
    public interface ICustomerService : IService<Customer>
    {
        Customer Get(int id);
        ICollection<Customer> GetCustomers(CustomerRequestDTO model);
        ICollection<Customer> GetCustomers(int customerId, CustomerRequestDTO model);
    }
}
