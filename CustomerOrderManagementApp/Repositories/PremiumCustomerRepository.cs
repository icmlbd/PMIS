﻿using CustomerOrderManagementApp.Models.EntityModels;
using CustomerOrderManagementApp.Repositories.Abstractions;

namespace CustomerOrderManagementApp.Repositories
{
    public class PremiumCustomerRepository : ICustomerRepository
    {
        public bool Add(Customer customer)
        {
            // AWS API Enpoint 
            // Add logic 
            // send data to aws 

            return true;
        }

        public bool Delete(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Customer Get(int customerId)
        {
            throw new NotImplementedException();
        }

        public Customer? GetByCategoryId(int categoryId)
        {
            throw new NotImplementedException();
        }

        public bool Update(Customer customer)
        {
            throw new NotImplementedException();
        }

        public ICollection<Customer> GetAll()
        {
            throw new NotImplementedException();
        }

        //ICollection<Customer> ICustomerRepository.GetAll()
        //{
        //    throw new NotImplementedException();
        //}
    }
}