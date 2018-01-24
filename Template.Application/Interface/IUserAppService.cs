using System.Collections.Generic;
using System.Threading.Tasks;
using Template.Domain.Entities;

namespace Template.Application.Interface
{
    public interface IUserAppService : IAppService<User>
    {
        Task<IEnumerable<User>> GetByNameAsync(string name);
    }
}
