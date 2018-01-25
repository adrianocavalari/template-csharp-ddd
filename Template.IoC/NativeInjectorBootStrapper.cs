using AutoMapper;
using Ninject;
using System;
using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Routing;
using Template.Application;
using Template.Application.AutoMapper;
using Template.Application.Interface;
using Template.Data;
using Template.Data.Context;
using Template.Data.Interfaces;
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
                //I don't know if it is the best way to do that, #NeedToFigureOut
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

                ninjectKernel.Bind<IUserAppService>().To<UserAppService>();
                ninjectKernel.Bind<IUserRepository>().To<UserRepository>();

                ninjectKernel.Bind<IUnitOfWork>().To<UnitOfWork>();

                ninjectKernel.Bind<DbContext>().To<TemplateContext>();
                // add your bindings here as required    
            }
        }
    }
}
