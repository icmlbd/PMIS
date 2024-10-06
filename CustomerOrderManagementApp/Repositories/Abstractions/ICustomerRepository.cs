using CustomerOrderManagementApp.Models.EntityModels;

namespace CustomerOrderManagementApp.Repositories.Abstractions
{
    public interface ICustomerRepository
    {
        public bool Add(Customer customer);
        public bool Update(Customer customer);
        public bool Delete(Customer customer);
        public ICollection<Customer> GetAll();
        public Customer Get(int customerId);

        public Customer? GetByCategoryId(int categoryId);
    }
}
