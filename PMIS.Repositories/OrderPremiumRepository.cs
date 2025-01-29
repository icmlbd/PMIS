using PMIS.Models.EntityModels;
using PMIS.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMIS.Repositories
{
    public class OrderPremiumRepository : IOrderRepository
    {
        public bool Add(Order entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Order entity)
        {
            throw new NotImplementedException();
        }

        public ICollection<Order> GetAll()
        {
            throw new NotImplementedException();
        }

        public Order GetFirstOrDefault(Func<Order, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public ICollection<Order> GetMany(Func<Order, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Order> GetManyQuerable(Func<Order, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Order> GetManyQuerable()
        {
            throw new NotImplementedException();
        }

        public bool IsOrderExists(string orderNo)
        {
            throw new NotImplementedException();
        }

        public bool Update(Order entity)
        {
            throw new NotImplementedException();
        }
    }
}
