using Microsoft.EntityFrameworkCore;
using PhoneBookAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBookAPI.Models.ORM.Context
{
    public class PhoneBookContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"Server=ec2-54-72-155-238.eu-west-1.compute.amazonaws.com
;Database=d5q2hc8cp7omln;UID=hmkirpnyynqjrp;PWD=c30c08fb8016cadaa1bc85e29ccfaef83229fa3b57b36a90bb2ae752ca43a961
;SSL Mode= Require;TrustServerCertificate=True");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<ContactTypes> ContactTypes { get; set; }
    }
}
