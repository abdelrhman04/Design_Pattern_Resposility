using CORE.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE
{
    public class MyContext:DbContext
    {
        public MyContext(DbContextOptions options) : base(options) { }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<School> Schools { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new SchoolConfiguration().Configure(modelBuilder.Entity<School>());
            new TeacherConfiguration().Configure(modelBuilder.Entity<Teacher>());
            new StudentConfiguration().Configure(modelBuilder.Entity<Student>());
            modelBuilder.MappRelationships();
        }

     }
}
