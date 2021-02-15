using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBookAPI.Models.Entities
{
    public class ContactTypes
    {
        public int ID { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
        [ForeignKey("UserID")]
        public int UserID { get; set; }
                
    }
}
