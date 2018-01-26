using AutoMapper;
using Template.Application.ViewModels;
using Template.Domain.Entities;

namespace Template.Application.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void RegisterMapping()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<User, UserViewModel>();
                cfg.CreateMap<UserViewModel, User>();
            });
        }
    }
}