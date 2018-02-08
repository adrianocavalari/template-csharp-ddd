using Template.Application.Interface;
using Template.Application.ViewModels;
using Template.Data.Repositories;
using Template.Domain.Entities;
using Template.Domain.Interfaces.Repository;

namespace Template.Application.Service
{
    public class OrderAppService : AppService<OrderViewModel, Order>, IOrderAppService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderAppService(IUnitOfWork unitOfWork)
            : base(unitOfWork.Repository<OrderRepository>())
        {
            _orderRepository = unitOfWork.Repository<IOrderRepository>();
        }
    }
}
