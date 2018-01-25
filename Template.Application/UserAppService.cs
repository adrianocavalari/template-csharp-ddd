using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Template.Application.Interface;
using Template.Application.ViewModels;
using Template.Domain.Entities;
using Template.Domain.Interfaces.Repository;
using System.Linq;

namespace Template.Application
{
    public class UserAppService : AppService<User>, IUserAppService
    {
        private readonly IUserRepository _userRepository;
        public UserAppService(IUnitOfWork uow, IUserRepository userRepository) 
            : base(uow, userRepository)
        {
            _userRepository = userRepository;
        }

        public void AddTwoAsync(List<UserViewModel> users)
        {
            var usersM =  Mapper.Map<IEnumerable<UserViewModel>, IEnumerable<User>>(users);
            BeginTransaction();
            foreach (var item in usersM)
            {
                _userRepository.AddTrans(item);
            }

            Commit();
        }

        public async Task<IEnumerable<UserViewModel>> GetByNameAsync(string name)
        {
            return Mapper.Map<IEnumerable<User>, IEnumerable<UserViewModel>>(await _userRepository.GetByNameAsync("adriano"));
        }
    }
}
