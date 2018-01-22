using Template.Application.Interface;
using Template.Domain.Entities;
using Template.Domain.Interfaces.Services;

namespace Template.Application
{
    public class UserAppService : AppService<User>, IUserAppService
    {
        public UserAppService(IUserAppService service) 
            : base(service)
        {
        }
    }
}
