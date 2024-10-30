using Microsoft.EntityFrameworkCore;
using PMIS.Database;
using PMIS.Models.EntityModels;
using PMIS.Repositories.Abstractions;
using PMIS.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMIS.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        EcommerceDbContext _db; 
        public ProductRepository(EcommerceDbContext db) : base(db)
        {
            this._db = db;
        }
    }
}
