using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Template.Domain.Entities;
using Template.Mvc.ViewModels;

namespace Template.Mvc.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void RegisterMapping()
        {
            //new MapperConfiguration(c =>
            //{
            //    c.CreateMap<User, UserViewModel>();
            //    c.CreateMap<UserViewModel, User>();
            //});
            Mapper.Initialize(cfg => {
                cfg.CreateMap<User, UserViewModel>();
                cfg.CreateMap<UserViewModel, User>();
            });
        }
    }
}