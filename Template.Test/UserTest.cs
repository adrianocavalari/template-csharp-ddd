using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Template.Application.Interface;
using Template.Domain.Entities;

namespace Template.Test
{
    [TestClass]
    public class UserTest
    {
        private readonly IUserAppService _userAppService;

        public UserTest(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        [TestMethod]
        public void SaveUser()
        {
            _userAppService.Add(new User
            {
                Name = "test"
            });

            //_userAppService.fin
        }
    }
}
