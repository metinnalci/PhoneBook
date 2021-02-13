using Microsoft.EntityFrameworkCore;
using ReportAPI.Models.ORM.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReportAPI.Models.ORM.Context
{
    public class ReportContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"Server=ec2-54-72-155-238.eu-west-1.compute.amazonaws.com
;Database=d5q2hc8cp7omln;UID=hmkirpnyynqjrp;PWD=c30c08fb8016cadaa1bc85e29ccfaef83229fa3b57b36a90bb2ae752ca43a961
;SSL Mode= Require;TrustServerCertificate=True");
        }
        public DbSet<Report> Reports { get; set; }
    }
}
