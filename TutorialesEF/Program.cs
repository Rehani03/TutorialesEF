using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TutorialesEF.DAL;
using TutorialesEF.Entidades;

namespace TutorialesEF
{
    class Program
    {
       
        static void Main(string[] args)
        {
            //GuardarStudentDB(); //Ejemplo de guardar en DB
            //GuardarCourseDB(); //Ejemplo de guardar course en DB
            //SimpleQueryDB(); //Ejemplo de hacer un query en DB
            //DoubleQueryDB(); //Ejemplo de query con Include
            //QuerryUsingSql(); //Ejemplo de query usando expresion SqlRaw
            UpdatingData();
        }

        private static void GuardarStudentDB()
        {
            //Ejemplo de guardar en DB
            SchoolContext context = new SchoolContext();
            try
            {
                var auxStudent = new Student()
                {
                    StudentId = 0,
                    FirstName = "Bill",
                    LastName = "Madison"

                };
                context.Students.Add(auxStudent);
                bool save = context.SaveChanges() > 0;
            
                if (save)
                    Console.WriteLine("The Student was sucessfully saved!!");
                else
                    Console.WriteLine("We cant save the student..");
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                context.Dispose();
            }
          
        }

        private static void GuardarCourseDB()
        {
            //Ejemplo de guardar en DB
            SchoolContext context = new SchoolContext();
            try
            {
                var auxCourse = new Course()
                {
                    CourseId = 0,
                    studentId = 1,
                    CourseName = "Math"

                };
                context.Courses.Add(auxCourse);
                bool save = context.SaveChanges() > 0;

                if (save)
                    Console.WriteLine("The Course was sucessfully saved!!");
                else
                    Console.WriteLine("We cant save the course..");
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                context.Dispose();
            }
           
            
            
        }
        private static void SimpleQueryDB()
        {
            //Ejemplo del Querying
            const string NAME = "Bill";
            SchoolContext context = new SchoolContext();
            try
            {
                var list = context.Students.Where(s => s.FirstName == NAME).ToList();
                if (list != null)
                    Console.WriteLine(list.Find(s => s.FirstName == NAME).FirstName);
                else
                    Console.WriteLine("We cant find the student!!");
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                context.Dispose();
            }
        }

        private static void DoubleQueryDB()
        {
            //Ejemplo del Querying con Inclue
            const string NAME = "Bill";
            SchoolContext context = new SchoolContext();
            try
            {
                var resultado = context.Courses.Where(c => c.CourseName == "Math")
                .Include(c => c.Student.FirstName == NAME).FirstOrDefault();

                if (resultado != null)
                    Console.WriteLine(resultado.CourseName.ToString());
                else
                    Console.WriteLine("We cant find the student!!");
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                context.Dispose();
            }
            
        }

        private static void QuerryUsingSql()
        {
            //Ejemplo de querying usando FromSqlRaw
            SchoolContext context = new SchoolContext();
            List<Student> studentList = new List<Student>();
            try
            {

                studentList = context.Students.FromSqlRaw("Select *from dbo.Students").ToList();
                if (studentList != null)
                    Console.WriteLine(studentList.Find(s => s.FirstName == "Bill").FirstName);
                else
                    Console.WriteLine("We cant find the student!!");
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                context.Dispose();
            }
            
        }

        private static void UpdatingData()
        {
            //En este ejemplo modificamos el nombre del primer estudiante
            SchoolContext context = new SchoolContext();

            try
            {
                var std = context.Students.First<Student>();
                std.FirstName = "Steve";
                bool modified = context.SaveChanges() > 0;

                if (modified)
                    Console.WriteLine("Student modified..");
                else
                    Console.WriteLine("We cant modified the student..");

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                context.Dispose();
            }
        }
    }
}
