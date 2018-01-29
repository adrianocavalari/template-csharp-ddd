using System.Web.Mvc;
using Template.Application.Interface;
using System.Threading.Tasks;
using Template.Application.ViewModels;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Template.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace Template.Mvc.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserAppService _userAppService;

        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public UserController(IUserAppService userAppService, ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            _userAppService = userAppService;
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel login)
        {
            if (ModelState.IsValid)
            {
                var context = HttpContext.GetOwinContext();
                var userManager = HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
                var authManager = HttpContext.GetOwinContext().Authentication;

                Identity.AppUser user = userManager.Find(login.UserName, login.Password);
                if (user != null)
                {
                    var ident = userManager.CreateIdentity(user,
                        DefaultAuthenticationTypes.ApplicationCookie);
                    authManager.SignIn(
                        new AuthenticationProperties { IsPersistent = false }, ident);
                    return Redirect(login.ReturnUrl ?? Url.Action("Index", "Home"));
                }
            }
            ModelState.AddModelError("", "Invalid username or password");
            return View(login);
        }

        //public ActionResult CreateRole2(string roleName)
        //{
        //    var roleManager = HttpContext.GetOwinContext().GetUserManager<RoleManager<AppRole>>();

        //    if (!roleManager.RoleExists(roleName))
        //        roleManager.Create(new AppRole(roleName));
        //    // rest of code
        //}

        public async Task<ActionResult> Index()
        {
            var user = new AppUser { UserName = "Test", Email = "teste@test.com" };
            var result = await UserManager.CreateAsync(user, "123456@a");
            if (result.Succeeded)
            {
                await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                // Send an email with this link
                // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");
            }

            var all = await _userAppService.GetAllAsync();

            return View(all);
        }

        public ActionResult CreateTest()
        {
            _userAppService.AddTwoAsync(
                new UserViewModel
                {
                    Name = "Ricardo2"
                });

            return Json(new { Success = true }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
