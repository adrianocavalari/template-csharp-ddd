using AutoMapper;
using Ninject;
using System;
using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Routing;
using Template.Application.AutoMapper;
using Template.Application.Interface;
using Template.Application.Service;
using Template.Data;
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
                ninjectKernel.Bind<DbContext>().To<TemplateContext>();

                ninjectKernel.Bind<IUserAppService>().To<UserAppService>();
                ninjectKernel.Bind<IUserRepository>().To<UserRepository>();

                ninjectKernel.Bind<IOrderAppService>().To<OrderAppService>();
                ninjectKernel.Bind<IOrderRepository>().To<OrderRepository>();

                // add your bindings here as required    
            }
        }
    }
}
