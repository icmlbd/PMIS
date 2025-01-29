using Microsoft.EntityFrameworkCore;
using PMIS.Database;
using PMIS.Models.EntityModels;
using PMIS.Repositories.Base;

namespace PMIS.Repositories
{
    public class PersonalInformationRepository : Repository<PersonalInformation>
    {
        EcommerceDbContext _db;
        public PersonalInformationRepository(EcommerceDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
