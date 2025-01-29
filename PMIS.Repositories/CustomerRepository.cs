using Microsoft.EntityFrameworkCore;
using PMIS.Database;
using PMIS.Models.EntityModels;
using PMIS.Repositories.Abstractions;
using PMIS.Repositories.Base;

namespace PMIS.Repositories
{
    public class CustomerRepository :Repository<Customer>, ICustomerRepository
    {
        private EcommerceDbContext _db;

        public CustomerRepository(EcommerceDbContext db) : base(db)
        {
            _db = db;

            
           
        }

        // CRUD operations -- add, update, remove, get operations, getall, getbyid

        public override ICollection<Customer> GetAll()
        {
            return _db.Customers.Include(c => c.Category).ToList();
        }

        public Customer? Get(int id)
        {

            return _db.Customers.Include(c => c.Category).FirstOrDefault(c=>c.Id == id);
        }

        public Customer? GetByCategoryId(int categoryId)
        {
            return base.GetFirstOrDefault(c => c.CategoryId == categoryId);
        }

        public override ICollection<Customer> GetMany(Func<Customer, bool> predicate)
        {
            return _db.Customers.Include(c => c.Category).Where(predicate).ToList(); 
        }

        public override IQueryable<Customer> GetManyQuerable(Func<Customer, bool> predicate)
        {
            return _db.Customers.Include(c=>c.Category).Where(predicate).AsQueryable();
        }

        public override IQueryable<Customer> GetManyQuerable()
        {
            return _db.Customers.Include(c => c.Category).AsQueryable();
        }


    }
}