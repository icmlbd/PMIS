using CustomerOrderManagementApp.DataStorage;
using CustomerOrderManagementApp.Models.EntityModels;
using CustomerOrderManagementApp.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace CustomerOrderManagementApp.Repositories
{
    public class PersonalInformationRepository : Repository<PersonalInformation>
    {
        EcommerceDbContext _db;
        public PersonalInformationRepository() : base(new EcommerceDbContext())
        {
            _db = new EcommerceDbContext();
        }
    }
}
