using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TutorialesEF.Entidades;

namespace TutorialesEF.DAL
{
    public class SchoolContext: DbContext
    {
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = .\SqlExpress; Database = SchoolDB; Trusted_Connection = True; ");
        }

        //Example of modelBuilder
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //With this configurations I force to colocate the primary key manually "Just to Person's entity"
            modelBuilder.Entity<Person>().Property(p => p.pesonId).HasColumnName("Id").HasDefaultValue(0).IsRequired();

            //shadow property
            modelBuilder.Entity<Student>().Property<String>("Ocupacion");
            modelBuilder.Entity<Student>().Property<int>("Edad");
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Person> Persons { get; set; }
       
    }
}
