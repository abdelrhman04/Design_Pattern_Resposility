using CORE.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE
{
    public static class RelationMapping
    {
        public static void MappRelationships(this ModelBuilder builder)
        {
            
            builder.Entity<Teacher>().
                   HasOne(i => i.school)
                   .WithMany(i => i.Teachers)
                   .HasForeignKey(i => i.School_Id)
                   .IsRequired().OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Student>().
                    HasOne(i => i.school)
                    .WithMany(i => i.Students)
                    .HasForeignKey(i => i.School_Id)
                    .IsRequired().OnDelete(DeleteBehavior.Cascade);


            builder.Entity<Student>().
                    HasOne(i => i.teacher)
                    .WithMany(i => i.Students)
                    .HasForeignKey(i => i.teacher_Id)
                    .IsRequired().OnDelete(DeleteBehavior.NoAction);
        }
     }   
}
