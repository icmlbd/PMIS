using CustomerOrderManagementApp.DataStorage;
using CustomerOrderManagementApp.Models.EntityModels;
using CustomerOrderManagementApp.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace CustomerOrderManagementApp.Repositories
{
    public class CustomerRepository : Repository<Customer>
    {
        private EcommerceDbContext _db;

        public CustomerRepository():base(new EcommerceDbContext())
        {
            _db = new EcommerceDbContext();
        }

        // CRUD operations -- add, update, remove, get operations, getall, getbyid

        public override ICollection<Customer> GetAll()
        {
             return _db.Customers.Include(c=>c.Category).ToList();
        }

        public Customer? Get(int id)
        {
            return base.GetFirstOrDefault(c=>c.Id == id);
        }

        public Customer? GetByCategoryId(int categoryId)
        {
            return base.GetFirstOrDefault(c => c.CategoryId == categoryId);
        }



    }
}
