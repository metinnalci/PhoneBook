using PhoneBookAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBookAPI.Models.ORM.VM
{
    public class AddUserPM
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string SurName { get; set; }
        [Required]
        public string Company { get; set; }
    }
}
