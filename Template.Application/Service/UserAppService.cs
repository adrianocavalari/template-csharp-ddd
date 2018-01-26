﻿using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Template.Application.Interface;
using Template.Application.ViewModels;
using Template.Domain.Entities;
using Template.Domain.Interfaces.Repository;
using System.Linq;
using Template.Data.Interfaces;

namespace Template.Application.Service
{
    public class UserAppService : AppService<User, UserViewModel>, IUserAppService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;


        public UserAppService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _userRepository = _unitOfWork.Repository<User>() as IUserRepository;
        }

        public void AddTwoAsync(List<UserViewModel> users)
        {
            var test = 1;
            var usersM = Mapper.Map<IEnumerable<UserViewModel>, IEnumerable<User>>(users);
            _unitOfWork.BeginTransaction();
            _unitOfWork.Repository<User>().Add(usersM.First());

            if (test == 1)
                throw new System.Exception("test");

            _unitOfWork.Repository<Order>().Add(new Order
            {
                Total = 1,
                User = usersM.First()
            });

            _unitOfWork.Commit();
        }

        public async Task<IEnumerable<UserViewModel>> GetByNameAsync(string name)
        {
            return Mapper.Map<IEnumerable<User>, IEnumerable<UserViewModel>>(await _userRepository.GetByNameAsync("adriano"));
        }
    }
}
