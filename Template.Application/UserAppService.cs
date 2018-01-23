using Template.Application.Interface;
using Template.Domain.Entities;
using Template.Domain.Interfaces.Services;

namespace Template.Application
{
    public class UserAppService : AppService<User>, IUserAppService
    {
        IUserService _service;
        public UserAppService(IUserService service) 
            : base(service)
        {
            _service = service;
        }

        public void GetByName(string name)
        {
            _service.GetByName(name);
        }
    }
}
