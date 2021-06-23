using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WoM_Labb2.Models;

namespace WoM_Labb2.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Assignments>().HasKey(asgm => new { asgm.UserID, asgm.TaskID });
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<Assignments> Assignments { get; set; }
    }
}
