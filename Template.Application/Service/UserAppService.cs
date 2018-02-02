using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Template.Application.Interface;
using Template.Application.ViewModels;
using Template.Domain.Entities;
using Template.Domain.Interfaces.Repository;

namespace Template.Application.Service
{
    public class UserAppService : AppService<UserViewModel, User>, IUserAppService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;

        public UserAppService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _userRepository = _unitOfWork.Repository<User>() as IUserRepository;
        }

        public async Task<IEnumerable<UserViewModel>> GetByNameAsync(string name)
        {
            return Mapper.Map<IEnumerable<UserViewModel>>(await _userRepository.GetByNameAsync("adriano"));
        }
    }
}
