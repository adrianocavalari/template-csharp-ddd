using System.Threading.Tasks;
using System.Web.Mvc;
using Template.Application.Interface;
using Template.Application.ViewModels;
using Template.Identity.Manager;
using Template.Identity.Model;

namespace Template.Mvc.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserAppService _userAppService;

        private readonly ApplicationSignInManager _signInManager;
        private readonly ApplicationUserManager _userManager;

        public UserController(IUserAppService userAppService, ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            _userAppService = userAppService;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<ActionResult> Index()
        {
            var user = new AppUser { UserName = "Test", Email = "teste@test.com" };
            var result = await _userManager.CreateAsync(user, "123456@a");
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

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
