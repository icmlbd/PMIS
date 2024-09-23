using CustomerOrderManagementApp.DataStorage;
using CustomerOrderManagementApp.Models.EntityModels;
using CustomerOrderManagementApp.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace CustomerOrderManagementApp.Repositories
{
    public class EmployeeRepository : Repository<Employee>
    {
        private EcommerceDbContext _db;
        public EmployeeRepository() : base(new EcommerceDbContext())
        {
            _db = new EcommerceDbContext();
        }



        public override ICollection<Employee> GetAll()
        {
            return _db.Employees.Include(c=>c.PersonalInformation).ToList();
        }

        public Employee? Get(int id)
        {
            return _db.Employees.Include(c => c.PersonalInformation).FirstOrDefault(c => c.Id == id);
        }
    }
}
