using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhoneBookAPI.Models.Entities;
using PhoneBookAPI.Models.ORM.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBookAPI.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly PhoneBookContext _phoneBookContext;

        public UserController(PhoneBookContext phoneBookContext)
        {
            _phoneBookContext = phoneBookContext;
        }

        [Route("users")]
        [HttpGet]
        public List<User> GetUserList()
        {
            var users = _phoneBookContext.Users.Include(q => q.ContactTypes).Select(t => new User
            {
                ID = t.ID,
                Name = t.Name,
                SurName = t.SurName,
                Company = t.Company,
                Deleted = t.Deleted,
                ContactTypes = (List<ContactTypes>)t.ContactTypes.Select(p => new ContactTypes
                {
                    ID = p.ID,
                    UserID = p.UserID,
                    Phone = p.Phone,
                    Email = p.Email,
                    Location = p.Location
                })
            }).Where(q => q.Deleted == false).ToList();

            return users;
        }

        [Route("user/{id}")]
        [HttpGet]
        public IActionResult GetUserDetail(int id)
        {
            User user = _phoneBookContext.Users.Find(id);
            if (user != null)
            {
                User userdetail = _phoneBookContext.Users.Include(q => q.ContactTypes).Select(t => new User
                {
                    ID = t.ID,
                    Name = t.Name,
                    SurName = t.SurName,
                    Company = t.Company,
                    Deleted = t.Deleted,
                    ContactTypes = (List<ContactTypes>)t.ContactTypes.Select(p => new ContactTypes
                    {
                        ID = p.ID,
                        UserID = p.UserID,
                        Phone = p.Phone,
                        Email = p.Email,
                        Location = p.Location
                    })
                }).Where(q => q.Deleted == false).FirstOrDefault(ı => ı.ID == id);

                return Ok(userdetail);

            }
            else
            {
                return BadRequest($"ID numarası {id} olan kişi bulunamadı!");
            }
        }


    }
}
