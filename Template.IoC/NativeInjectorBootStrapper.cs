using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Ninject;
using System;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Template.Application.AutoMapper;
using Template.Application.Interface;
using Template.Application.Service;
using Template.Data;
using Template.Data.Context;
using Template.Data.Repositories;
using Template.Domain.Interfaces.Repository;
using Template.Identity;
using Template.Identity.Context;
using Template.Identity.Manager;
using Template.Identity.Model;

namespace Template.IoC
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        public IKernel ninjectKernel;

        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();

            //I don't know if it is the best way to do this, #NeedToFigureOut
            AutoMapperConfig.RegisterMapping();

            AddBindings();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)ninjectKernel.Get(controllerType);
        }

        private void AddBindings()
        {
            ninjectKernel.Bind<IMapper>().To<Mapper>();
            ninjectKernel.Bind<IUnitOfWork>().To<UnitOfWork>();
            ninjectKernel.Bind<DbContext>().To<SteamSkinContext>();

            ninjectKernel.Bind<IUserAppService>().To<UserAppService>();
            ninjectKernel.Bind<IUserRepository>().To<UserRepository>();

            ninjectKernel.Bind<IOrderAppService>().To<OrderAppService>();
            ninjectKernel.Bind<IOrderRepository>().To<OrderRepository>();

            ninjectKernel.Bind<ApplicationDbContext>().ToSelf();
            ninjectKernel.Bind(typeof(IUserStore<>)).To(typeof(UserStore<>));
            ninjectKernel.Bind<IAuthenticationManager>().ToMethod(c => HttpContext.Current.GetOwinContext().Authentication);
            ninjectKernel.Bind<ApplicationUserManager>().ToMethod(c =>
                HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>());
            // add your bindings here as required    
        }
    }
}
