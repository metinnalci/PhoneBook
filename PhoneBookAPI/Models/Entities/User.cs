using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBookAPI.Models.Entities
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Company { get; set; }
        public List<ContactTypes> ContactTypes { get; set; }
        public bool Deleted { get; set; } = false;
    }
}
