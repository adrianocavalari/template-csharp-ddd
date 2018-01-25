using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Template.Application.Interface;
using Template.Application.ViewModels;
using Template.Domain.Entities;
using Template.Domain.Interfaces.Repository;
using System.Linq;
using Template.Data.Interfaces;

namespace Template.Application
{
    public class UserAppService : AppService<User>, IUserAppService
    {
        static List<IUserRepository> contexts = new List<IUserRepository>();

        private readonly IUserRepository _userRepository;
        public UserAppService(IUserRepository userRepository) 
            : base(userRepository)
        {
            _userRepository = userRepository;
            contexts.Add(_userRepository);
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
