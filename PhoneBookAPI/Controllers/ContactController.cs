using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhoneBookAPI.Models.Entities;
using PhoneBookAPI.Models.ORM.Context;
using PhoneBookAPI.Models.PostmanModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBookAPI.Controllers
{
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly PhoneBookContext _phoneBookContext;

        public ContactController(PhoneBookContext phoneBookContext)
        {
            _phoneBookContext = phoneBookContext;
        }

        [Route("contact/add")]
        [HttpPost]
        public IActionResult AddContact([FromForm] ContactPM model)
        {

            var user = _phoneBookContext.Users.Include(q => q.ContactTypes).FirstOrDefault(p => p.ID == model.UserID);
            if (user != null)
            {
                if (user.ContactTypes == null)
                {
                    ContactTypes contactTypes = new ContactTypes();
                    contactTypes.Email = model.Email;
                    contactTypes.Phone = model.Phone;
                    contactTypes.Location = model.Location;
                    contactTypes.UserID = model.UserID;

                    _phoneBookContext.ContactTypes.Add(contactTypes);
                    _phoneBookContext.SaveChanges();

                    return Ok($"ID'si {model.UserID} olan kişiye iletişim bilgisi eklendi!");
                }
                else
                {
                    return BadRequest($"ID'si {model.UserID} olan kişinin zaten iletişim bilgisi var!(güncelleme istenmemiş)");
                }
            }
            else
            {
                return BadRequest($"ID'si {model.UserID} olan kişi bulunamadı!");
            }

        }
    }
}
