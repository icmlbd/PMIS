using CustomerOrderManagementApp.Models.EntityModels;

namespace CustomerOrderManagementApp.Repositories.Abstractions
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Employee? Get(int id);
    }
}
