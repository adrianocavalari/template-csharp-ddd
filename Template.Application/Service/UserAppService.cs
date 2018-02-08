using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Template.Application.Interface;
using Template.Application.ViewModels;
using Template.Data.Repositories;
using Template.Domain.Entities;
using Template.Domain.Interfaces.Repository;
using Template.Identity.Manager;
using Template.Identity.Model;

namespace Template.Application.Service
{
    public class UserAppService : AppService<UserViewModel, User>, IUserAppService
    {
        private readonly IUserRepository _userRepository;
        private readonly ApplicationSignInManager _signInManager;
        private readonly ApplicationUserManager _userManager;

        public UserAppService(
            IUnitOfWork unitOfWork,
            ApplicationUserManager userManager,
            ApplicationSignInManager signInManager)
            : base(unitOfWork.Repository<UserRepository>())
        {
            _userRepository = unitOfWork.Repository<UserRepository>();
            _signInManager = signInManager;
            _userManager = userManager;

            GetAll();
        }

        public async Task AddUserAppAsync(UserViewModel userViewModel)
        {
            Add(userViewModel);
            var user = new AppUser { UserName = userViewModel.Name, Email = userViewModel.Email, User = Mapper.Map<User>(userViewModel) };
            var result = await _userManager.CreateAsync(user, "Template@123");
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                // Send an email with this link
                // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");
            }
        }

        public async Task<IEnumerable<UserViewModel>> GetByNameAsync(string name)
        {
            
            return Mapper.Map<IEnumerable<UserViewModel>>(await _userRepository.GetByNameAsync(name));
        }
    }
}
