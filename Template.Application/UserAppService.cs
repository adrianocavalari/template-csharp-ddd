using System.Collections.Generic;
using System.Threading.Tasks;
using Template.Application.Interface;
using Template.Domain.Entities;
using Template.Domain.Interfaces.Repository;

namespace Template.Application
{
    public class UserAppService : AppService<User>, IUserAppService
    {
        IUserRepository _userRepository;
        public UserAppService(IUserRepository userRepository) 
            : base(userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetByNameAsync(string name)
        {
            return await _userRepository.GetByNameAsync(name);
        }
    }
}
