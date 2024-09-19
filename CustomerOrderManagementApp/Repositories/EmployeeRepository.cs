using CustomerOrderManagementApp.DataStorage;
using CustomerOrderManagementApp.Models.EntityModels;

namespace CustomerOrderManagementApp.Repositories
{
    public class EmployeeRepository
    {
        private EcommerceDbContext _db;
        public EmployeeRepository() {
            _db = new EcommerceDbContext();
        }

        public bool Add(Employee employee)
        {
            _db.Add(employee);

            return _db.SaveChanges() > 0;
        }

        public bool Update(Employee employee)
        {
            _db.Employees.Update(employee);

            return _db.SaveChanges() > 0;
        }

        public bool Delete(Employee employee)
        {
            _db.Employees.Remove(employee);
            return _db.SaveChanges() > 0;
        }

        public ICollection<Employee> GetAll()
        {
            return _db.Employees.ToList();
        }

        public Employee? Get(int id)
        {
            return _db.Employees.FirstOrDefault(c => c.Id == id);
        }
    }
}
