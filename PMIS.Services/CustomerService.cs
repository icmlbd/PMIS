using PMIS.Models.DTOs.Customers;
using PMIS.Models.EntityModels;
using PMIS.Repositories;
using PMIS.Repositories.Abstractions;
using PMIS.Repositories.Base;
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
        ICustomerRepository _customerRepository;  

        public CustomerService(ICustomerRepository repository) : base(repository)
        {
           _customerRepository = repository;
        }

        public Customer Get(int id)
        {
           
            return _customerRepository.Get(id);
        }

        public Customer GetByCategoryId(int categoryId)
        {
            var customers = _customerRepository.GetByCategoryId(categoryId);

            return customers; 
        }

        public ICollection<Customer> GetCustomers(CustomerRequestDTO model)
        {
            IQueryable<Customer> customers = GetQuerableCustomers(model);
            //coalesce 
            customers = ApplyPagination(model.CurrentPage??1,model.PageSize??20, customers);

            return customers.ToList();


        }

       
        private IQueryable<Customer> ApplyPagination(int currentPage,int pageSize, IQueryable<Customer> customers)
        {
            int skipCount = ((int)currentPage - 1) * (int)pageSize;
            customers = customers.Skip(skipCount).Take((int)pageSize);
            return customers;
        }

        private IQueryable<Customer> GetQuerableCustomers(CustomerRequestDTO model)
        {
            var customers = _customerRepository.GetManyQuerable();

            if (!string.IsNullOrEmpty(model.FilterText))
            {
                string filterTextLower = model.FilterText.ToLower();
                customers = customers.Where(c =>
                            c.Name.ToLower().Contains(filterTextLower)
                            || (c.Address != null && c.Address.ToLower().Contains(filterTextLower))
                            || c.Phone.Contains(filterTextLower)
                            //|| (c.Category != null && c.Category.Name.ToLower().Contains(filterTextLower))
                            );
            }

            if (!string.IsNullOrEmpty(model.Name))
            {
                customers = customers.Where(c => c.Name.ToLower().Contains(model.Name.ToLower()));
            }

            if (!string.IsNullOrEmpty(model.Address))
            {
                customers = customers.Where(c => c.Address.ToLower().Contains(model.Address.ToLower()));
            }

            return customers;
        }

        public ICollection<Customer> GetCustomers(int categoryId, CustomerRequestDTO model)
        {
            var customers = GetQuerableCustomers(model);

            customers = customers.Where(c => c.CategoryId == categoryId);

            customers = ApplyPagination(model.CurrentPage??1, model.PageSize??20, customers); 


            return customers.ToList();

        }
    }
}
