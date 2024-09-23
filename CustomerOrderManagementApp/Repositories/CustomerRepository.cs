using CustomerOrderManagementApp.DataStorage;
using CustomerOrderManagementApp.Models.EntityModels;

namespace CustomerOrderManagementApp.Repositories
{
    public class CustomerRepository
    {
        private EcommerceDbContext _db;

        public CustomerRepository()
        {
            _db = new EcommerceDbContext();
        }

        // CRUD operations -- add, update, remove, get operations, getall, getbyid

        public bool Add(Customer customer)
        {
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
        }

        public Customer? Get(int id)
        {
            return _db.Customers.FirstOrDefault(c => c.Id == id);
        }

    }
}
