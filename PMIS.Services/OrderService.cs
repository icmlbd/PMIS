using PMIS.Models.EntityModels;
using PMIS.Repositories;
using PMIS.Repositories.Abstractions;
using PMIS.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMIS.Services
{
    public class OrderService : Service<Order>
    {
        IOrderRepository _orderRepository;
        ICustomerRepository _customerRepository; 
        public OrderService(IOrderRepository orderRepository, ICustomerRepository customerRepository) : base(orderRepository)
        {
            _orderRepository = orderRepository;
            _customerRepository = customerRepository;
        }

        public override bool Add(Order entity)
        {
            // order add logic 

            // check if order is already exists 
            //_orderRepository.IsOrderExists("aslkasdfj"); 

            //// check if customer already exists 
            //_customerRepository.

            // save the order in storage

            return base.Add(entity);
        }
    }
}
