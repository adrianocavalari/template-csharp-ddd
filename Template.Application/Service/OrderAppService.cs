using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Template.Application.Interface;
using Template.Application.ViewModels;
using Template.Domain.Entities;
using Template.Domain.Interfaces.Repository;
using System.Linq;
using Template.Data.Interfaces;

namespace Template.Application.Service
{
    public class OrderAppService : AppService<Order>, IOrderAppService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderAppService(IOrderRepository orderRepository) 
            : base(orderRepository)
        {
            _orderRepository = orderRepository;
        }
    }
}
