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
    public class CustomerCategoryService : Service<CustomerCategory>, ICustomerCategoryService
    {
        ICustomerCategoryRepository _customerCategoryRepo;
        public CustomerCategoryService(ICustomerCategoryRepository repository) : base(repository)
        {
            _customerCategoryRepo = repository; 
        }
    }
}
