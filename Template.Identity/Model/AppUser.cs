using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;
using Template.Domain.Entities;

namespace Template.Identity.Model
{
    public class AppUser : IdentityUser
    {
        [Required]
        public User User { get; set; }

        //add your custom properties which have not included in IdentityUser before
        //public string MyExtraProperty { get; set; }

        public Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<AppUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
                 
            // Add custom user claims here
            return manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
        }
    }
}