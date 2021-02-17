using NUnit.Framework;
using PhoneBookAPI.Controllers;
using PhoneBookAPI.Models.ORM.Context;
using PhoneBookAPI.Models.PostmanModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests.PhoneBookAPI.ControllersTest
{
    class ContactControllerTest
    {
        [Test]
        public void AddContact()
        {
            PhoneBookContext _phoneBookContext = new PhoneBookContext();
            ContactController contactController = new ContactController(_phoneBookContext);
            
            ContactPM model = new ContactPM();
                        
            model.UserID = 1;
            var result = contactController.AddContact(model);

            Assert.IsNotNull(result);
        }

        [Test]
        public void DeleteContact()
        {
            PhoneBookContext _phoneBookContext = new PhoneBookContext();
            ContactController contactController = new ContactController(_phoneBookContext);

            ContactPM model = new ContactPM();
                        
            var result = contactController.DeleteContact(6);

            Assert.IsNotNull(result);
        }
    }
}
