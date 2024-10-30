using PMIS.Models.EntityModels;

namespace PMIS.Repositories.Abstractions
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        public Customer Get(int customerId);

        public Customer? GetByCategoryId(int categoryId);
    }
}
