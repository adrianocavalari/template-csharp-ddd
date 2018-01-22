using Template.Domain.Entities;
using Template.Domain.Interfaces.Repository;
using Template.Domain.Interfaces.Services;

namespace Template.Domain.Services
{
    public class UserService : Service<User>, IUserService
    {
        public UserService(IUserRepository respository) 
            : base(respository)
        {
        }
    }
}
