using System.Web.Mvc;
using AutoMapper;
using Template.Domain.Entities;
using System.Collections.Generic;
using Template.Mvc.ViewModels;
using Template.Application.Interface;

namespace Template.Mvc.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserAppService _userAppService;

        public UserController(IUserAppService userAppService)
        //public UserController()
        {
            _userAppService = userAppService;
            //_userAppService = new UserAppService(new );
        }

        // GET: User
        public ActionResult Index()
        {
            var all = Mapper.Map<IEnumerable<User>, IEnumerable<UserViewModel>>(_userAppService.GetAll());
            return View(all);
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
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

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: User/Edit/5
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

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
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
