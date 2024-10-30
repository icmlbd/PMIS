using PMIS.Models.EntityModels;
using PMIS.Repositories.Abstractions;

namespace PMIS.Repositories
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

        public Customer GetFirstOrDefault(Func<Customer, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public ICollection<Customer> GetMany(Func<Customer, bool> predicate)
        {
            throw new NotImplementedException();
        }

        //ICollection<Customer> ICustomerRepository.GetAll()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
