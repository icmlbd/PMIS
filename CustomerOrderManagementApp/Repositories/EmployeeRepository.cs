using CustomerOrderManagementApp.DataStorage;
using CustomerOrderManagementApp.Models.EntityModels;
using CustomerOrderManagementApp.Repositories.Abstractions;
using CustomerOrderManagementApp.Repositories.Base;

namespace CustomerOrderManagementApp.Repositories
{
    public class EmployeeRepository:Repository<Employee>, IEmployeeRepository
    {
        private EcommerceDbContext _db;
        public EmployeeRepository(): base(new EcommerceDbContext()) {
            _db = new EcommerceDbContext();
        }
        public Employee? Get(int id)
        {
            return _db.Employees.FirstOrDefault(c => c.Id == id);
        }
    }
}
