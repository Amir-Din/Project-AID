using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AID.Models
{
    public class DContext : DbContext
    {
        public DbSet<charity> charity { get; set; }

        public DbSet<config> configs { get; set; }

        public DbSet<login> login { get; set; }

        public DbSet<patient> patients { get; set; }

        public DbSet<visit> visits { get; set; }

        public string path = @"C:\hosein\Patient\AID\AID\AppDB.db";

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite($"Data Source={path}");
    }
}
