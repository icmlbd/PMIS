using CustomerOrderManagementApp.DataStorage;
using CustomerOrderManagementApp.Models.EntityModels;

namespace CustomerOrderManagementApp.Repositories
{

    public class CustomerCategoryRepository
    {
        private EcommerceDbContext _db;

        public CustomerCategoryRepository()
        {
            _db = new EcommerceDbContext();
        }
        public bool Add(CustomerCategory entity)
        {
            _db.Add(entity);

            return _db.SaveChanges() > 0;
        }

        public bool Update(CustomerCategory entity)
        {
            _db.CustomersCategories.Update(entity);

            return _db.SaveChanges() > 0;
        }

        public bool Delete(CustomerCategory entity)
        {
            _db.CustomersCategories.Remove(entity);
            return _db.SaveChanges() > 0;
        }

        public ICollection<CustomerCategory> GetAll()
        {
            return _db.CustomersCategories.ToList();
        }

        public CustomerCategory? Get(int id)
        {
            return _db.CustomersCategories.FirstOrDefault(c => c.Id == id);
        }
    }
}
