using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TutorialesEF.Entidades;

namespace TutorialesEF.DAL
{
    public class SchoolContext: DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = .\SqlExpress; Database = SchoolDB; Trusted_Connection = True; ");
        }
    }
}
