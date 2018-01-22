using Template.Domain.Entities;
using Template.Domain.Interfaces.Repository;

namespace Template.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository()
            : base()
        {
        }
    }
}
