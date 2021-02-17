using NUnit.Framework;
using PhoneBookAPI.Controllers;
using PhoneBookAPI.Models.ORM.Context;
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

        }
        
        
    }
}
