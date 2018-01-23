using System.Collections.Generic;
using System.Threading.Tasks;
using Template.Domain.Entities;

namespace Template.Domain.Interfaces.Services
{
    public interface IUserService : IService<User>
    {
        Task<IEnumerable<User>> GetByNameAsync(string name);
    }
}
