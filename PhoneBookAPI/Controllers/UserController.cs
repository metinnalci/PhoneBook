using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            return _phoneBookContext.Users.Where(q => q.Deleted == false).ToList();
        }


    }
}
