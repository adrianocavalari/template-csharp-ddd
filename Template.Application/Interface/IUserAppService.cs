using System.Collections.Generic;
using System.Threading.Tasks;
using Template.Application.ViewModels;

namespace Template.Application.Interface
{
    public interface IUserAppService : IAppService<UserViewModel>
    {
        Task<IEnumerable<UserViewModel>> GetByNameAsync(string name);

        Task AddUserAppAsync(UserViewModel user);
    }
}
