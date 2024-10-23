using CustomerOrderManagementApp.Models.EntityModels;

namespace CustomerOrderManagementApp.Repositories.Abstractions
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        public Customer Get(int customerId);

        public Customer? GetByCategoryId(int categoryId);
    }
}
