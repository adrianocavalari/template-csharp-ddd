using System.Data.Entity;
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
    }
}
