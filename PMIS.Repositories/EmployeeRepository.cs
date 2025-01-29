using Microsoft.EntityFrameworkCore;
using PMIS.Database;
using PMIS.Models.EntityModels;
using PMIS.Repositories.Abstractions;
using PMIS.Repositories.Base;

namespace PMIS.Repositories
{
    public class EmployeeRepository:Repository<Employee>, IEmployeeRepository
    {
        private EcommerceDbContext _db;
        public EmployeeRepository(EcommerceDbContext db): base(db) {
            _db = db;
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
