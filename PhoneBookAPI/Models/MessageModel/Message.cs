using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBookAPI.Models.MessageModel
{
    public class Message
    {
        public int ID { get; set; }
        public string Location { get; set; }
        public string Phone { get; set; }
        public int UserID { get; set; }
    }
}
