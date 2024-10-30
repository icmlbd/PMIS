using PMIS.Database;
using PMIS.Models.EntityModels;
using PMIS.Repositories.Abstractions;
using PMIS.Repositories.Base;

namespace PMIS.Repositories
{

    public class CustomerCategoryRepository:Repository<CustomerCategory>,ICustomerCategoryRepository
    {
        private EcommerceDbContext _db;

        public CustomerCategoryRepository(EcommerceDbContext db): base(db) 
        {
                _db = db; 
        }
        public CustomerCategory? Get(int id)
        {
            return _db.CustomersCategories.FirstOrDefault(c => c.Id == id);
        }
    }
}
