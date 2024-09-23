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
<<<<<<< HEAD
            _db.Add(customer);

            return _db.SaveChanges() > 0;
        }

        public bool Update(Customer customer)
        {
            _db.Customers.Update(customer);

            return _db.SaveChanges() > 0;
        }

        public bool Delete(Customer customer)
        {
            _db.Remove(customer);
            return _db.SaveChanges() > 0; 
        }

        public ICollection<Customer> GetAll()
        {
            return _db.Customers.OrderBy(c => c.Name).ToList();
=======
             return _db.Customers.Include(c=>c.Category).ToList();
>>>>>>> 15f5dd2056c6d18f8bd2a043818b48790f50d2fa
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
