using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using Template.Domain.Entities;
using Template.Domain.Interfaces.Repository;

namespace Template.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository, IRepository<User>
    {
        public UserRepository(DbContext context) 
            : base(context)
        {
        }

        public Task<IEnumerable<User>> GetByNameAsync(string name)
        {

            return GetByAsync(g => g.Name.Equals(name, System.StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
