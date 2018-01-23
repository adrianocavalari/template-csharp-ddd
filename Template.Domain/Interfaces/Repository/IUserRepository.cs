using System.Collections.Generic;
using System.Threading.Tasks;
using Template.Domain.Entities;

namespace Template.Domain.Interfaces.Repository
{
    public interface IUserRepository: IRepository<User>
    {
        Task<IEnumerable<User>> GetByName(string name);
    }
}
