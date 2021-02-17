using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReportAPI.Models.MessageModel
{
    public class Message
    {
        public string Location { get; set; }
        public string Phone { get; set; }
        public int UserID { get; set; }
    }
}
