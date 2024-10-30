using PMIS.Models.EntityModels;
using PMIS.Repositories.Abstractions;
using PMIS.Services.Abstractions;
using PMIS.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMIS.Services
{
    public class CustomerService : Service<Customer>, ICustomerService
    {
        ICustomerRepository _repository;
        public CustomerService(ICustomerRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public Customer Get(int id)
        {
            return _repository.Get(id);
        }
    }
}
