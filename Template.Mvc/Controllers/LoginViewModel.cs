namespace Template.Mvc.Controllers
{
    public class LoginViewModel
    {
        public string UserName { get; internal set; }
        public string Password { get; internal set; }
        public string ReturnUrl { get; internal set; }
    }
}