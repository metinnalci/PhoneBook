using NUnit.Framework;
using PhoneBookAPI.Controllers;
using PhoneBookAPI.Models.ORM.Context;
using PhoneBookAPI.Models.ORM.VM;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests.PhoneBookAPI.ControllersTest
{
    
    class UserControllerTests
    {
        [Test]
        public void GetUserList()
        {
            PhoneBookContext _phoneBookContext = new PhoneBookContext();
            UserController userController = new UserController(_phoneBookContext);
            var result = userController.GetUserList();

            Assert.IsTrue(result.Count > 0);
            Assert.IsNotNull(result);
        }

        [Test]
        public void GetUserDetail()
        {
            PhoneBookContext _phoneBookContext = new PhoneBookContext();
            UserController userController = new UserController(_phoneBookContext);

            var result = userController.GetUserDetail(3);

            Assert.IsNotNull(result);
        }

        [Test]
        public void AddUser()
        {
            PhoneBookContext _phoneBookContext = new PhoneBookContext();
            UserController userController = new UserController(_phoneBookContext);

            AddUserPM model = new AddUserPM();

            var result = userController.AddUser(model);

            Assert.IsNotNull(result);
            Assert.IsNotNull(model.ID, model.Name, model.SurName, model.Company);
        }

        [Test]
        public void DeleteUser()
        {
            PhoneBookContext _phoneBookContext = new PhoneBookContext();
            UserController userController = new UserController(_phoneBookContext);

            var result = userController.DeleteUser(5);

            Assert.IsNotNull(result);
        }
    }
}
