using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using Template.Domain.Entities;
using Template.Domain.Interfaces.Repository;

namespace Template.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DbContext context) 
            : base(context)
        {
        }

        public async Task<IEnumerable<User>> GetByName(string name)
        {

            return await GetByAsync(g => g.Name.Equals(name, System.StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
