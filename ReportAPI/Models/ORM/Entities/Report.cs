using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReportAPI.Models.ORM.Entities
{
    public class Report
    {
        public int ID { get; set; }
        public int TotalUser { get; set; }
        public int TotalPhone { get; set; }
        public string Location { get; set; }
        public DateTime RequestTime { get; set; } = DateTime.Now;
        public bool ReportStatus { get; set; } = false;
        public bool Deleted { get; set; } = false;
    }
}
