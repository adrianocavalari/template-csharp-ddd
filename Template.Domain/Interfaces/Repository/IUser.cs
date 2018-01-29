using System.Collections.Generic;
using System.Security.Claims;

namespace Template.Domain.Interfaces.Repository
{
    public interface IUser
    {
        string Name { get; }
        bool IsAuthenticated();
        //IEnumerable<Claim> GetClaimsIdentity();
    }
}
