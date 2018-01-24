using Ninject;
using System;
using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Routing;
using Template.Application;
using Template.Application.Interface;
using Template.Data.Context;
using Template.Data.Repositories;
using Template.Domain.Interfaces.Repository;

namespace Template.IoC
{
    public class NinjectInjectorBootStrapper
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
                ninjectKernel.Bind<IUserRepository>().To<UserRepository>();

                ninjectKernel.Bind<DbContext>().To<TemplateContext>();
                // add your bindings here as required    
            }
        }
    }
}
