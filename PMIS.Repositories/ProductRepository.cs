using CustomerOrderManagementApp.DataStorage;
using CustomerOrderManagementApp.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using PMIS.Models.EntityModels;
using PMIS.Repositories.Abstractions;
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
