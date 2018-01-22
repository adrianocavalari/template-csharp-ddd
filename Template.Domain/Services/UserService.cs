using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.Entities;
using Template.Domain.Interfaces.Repository;
using Template.Domain.Interfaces.Services;

namespace Template.Domain.Services
{
    public class UserService : Service<User>, IUserService
    {
        public UserService(IRepository<User> respository) 
            : base(respository)
        {
        }
    }
}
