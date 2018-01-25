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
    public class UserAppService : AppService<User>, IUserAppService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IUserRepository _userRepository;
        private readonly IOrderRepository _orderRepository;

        public UserAppService(IUnitOfWork unitOfWork, IUserRepository userRepository, IOrderRepository orderRepository)
            : base(userRepository)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _orderRepository = orderRepository;
        }

        public void AddTwoAsync(List<UserViewModel> users)
        {
            var usersM = Mapper.Map<IEnumerable<UserViewModel>, IEnumerable<User>>(users);
            _unitOfWork.BeginTransaction();
            _unitOfWork.Repository<User>().AddTrans(usersM.First());
            _unitOfWork.Repository<Order>().AddTrans(new Order
            {
                Total = 1,
                UserId = 1
            });

            _unitOfWork.Commit();
        }

        public async Task<IEnumerable<UserViewModel>> GetByNameAsync(string name)
        {
            return Mapper.Map<IEnumerable<User>, IEnumerable<UserViewModel>>(await _userRepository.GetByNameAsync("adriano"));
        }
    }
}
