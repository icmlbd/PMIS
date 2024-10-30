using PMIS.Models.EntityModels;

namespace PMIS.Repositories.Abstractions
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Employee? Get(int id);
    }
}
