using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhoneBookAPI.Models.Entities;
using PhoneBookAPI.Models.ORM.Context;
using PhoneBookAPI.Models.ORM.VM;
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
            var users = _phoneBookContext.Users.Include(q => q.ContactTypes).Where(p => p.Deleted == false).ToList();
            
            return users;
        }

        [Route("user/{id}")]
        [HttpGet]
        public IActionResult GetUserDetail(int id)
        {
            User user = _phoneBookContext.Users.Find(id);
            if (user != null)
            {
                var userdetail = _phoneBookContext.Users.Include(q => q.ContactTypes).Where(p => p.Deleted == false && p.ID == id);
                return Ok(userdetail);

            }
            else
            {
                return BadRequest($"ID'si {id} olan kişi bulunamadı!");
            }
        }

        [Route("user/add")]
        [HttpPost]
        public IActionResult AddUser([FromForm] AddUserPM model)
        {
            if (ModelState.IsValid)
            {
                User user = new User();

                user.Name = model.Name;
                user.SurName = model.SurName;
                user.Company = model.Company;

                _phoneBookContext.Add(user);
                _phoneBookContext.SaveChanges();

                model.ID = user.ID;

                return Ok(model);
            }
            else
            {
                return BadRequest(ModelState.Values);
            }
        }

        [Route("user/delete")]
        [HttpPost]
        public IActionResult DeleteUser([FromForm] int id)
        {
            User user = _phoneBookContext.Users.Find(id);

            if (user != null)
            {
                user.Deleted = true;
                _phoneBookContext.SaveChanges();

                return Ok($"ID'si {id} olan kişi başarıyla silindi!");

            }
            else
            {
                return BadRequest($"ID'si {id} olan kişi bulunamadı!");
            }

        }

    }
}
