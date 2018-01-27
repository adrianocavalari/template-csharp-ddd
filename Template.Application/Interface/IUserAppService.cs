﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Template.Application.ViewModels;
using Template.Domain.Entities;

namespace Template.Application.Interface
{
    public interface IUserAppService : IAppService<UserViewModel>
    {
        Task<IEnumerable<UserViewModel>> GetByNameAsync(string name);

        void AddTwoAsync(List<UserViewModel> users);

        void AddTwoAsync(UserViewModel user);
    }
}
