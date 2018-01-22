using Ninject;
using System;
using System.Web.Mvc;
using System.Web.Routing;
using Template.Application;
using Template.Application.Interface;
using Template.Data.Repositories;
using Template.Domain.Interfaces.Repository;
using Template.Domain.Interfaces.Services;
using Template.Domain.Services;

namespace Template.Mvc.App_Start
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;
        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)ninjectKernel.Get(controllerType);
        }
        private void AddBindings()
        {
            ninjectKernel.Bind<IUserAppService>().To<UserAppService>();
            ninjectKernel.Bind<IUserService>().To<UserService>();
            ninjectKernel.Bind<IUserRepository>().To<UserRepository>();
            // add your bindings here as required    
        }
    }
}