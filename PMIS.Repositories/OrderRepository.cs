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
    public class OrderRepository : Repository<Order>,IOrderRepository
    {
        EcommerceDbContext _context; 

        //confusion
        public OrderRepository(EcommerceDbContext context):base(context)
        {
            _context = context;
        }


        public override bool Add(Order entity)
        {
            _context.Orders.Add(entity);

            return _context.SaveChanges() > 0; 

        }

        public bool IsOrderExists(string orderNo)
        {
            return false; 
        }
    }
}
