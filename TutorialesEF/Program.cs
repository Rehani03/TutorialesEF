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
            QuerryUsingSql(); //Ejemplo de query usando expresion SqlRaw

        }

        private static void GuardarStudentDB()
        {
            //Ejemplo de guardar en DB
            SchoolContext context = new SchoolContext();
            var auxStudent = new Student()
            {
                StudentId = 0,
                FirstName = "Bill",
                LastName = "Madison"

            };
            context.Students.Add(auxStudent);
            bool save = context.SaveChanges() > 0;
            context.Dispose();

            if(save)
                Console.WriteLine("The Student was sucessfully saved!!");
            else
                Console.WriteLine("We cant save the student..");
        }

        private static void GuardarCourseDB()
        {
            //Ejemplo de guardar en DB
            SchoolContext context = new SchoolContext();
            var auxCourse = new Course()
            {
                CourseId = 0,
                studentId = 1,
                CourseName = "Math"

            };
            context.Courses.Add(auxCourse);
            bool save = context.SaveChanges() > 0;
            context.Dispose();

            if (save)
                Console.WriteLine("The Course was sucessfully saved!!");
            else
                Console.WriteLine("We cant save the course..");
        }
        private static void SimpleQueryDB()
        {
            //Ejemplo del Querying
            const string  NAME = "Bill";
            SchoolContext context = new SchoolContext();
            var list = context.Students.Where(s => s.FirstName == NAME).ToList();
            context.Dispose();

            if (list != null)
                Console.WriteLine(list.Find(s => s.FirstName == NAME).FirstName);
           else
                Console.WriteLine("We cant find the student!!");   
        }

        private static void DoubleQueryDB()
        {
            //Ejemplo del Querying con Inclue
            const string NAME = "Bill";
            SchoolContext context = new SchoolContext();
            var resultado = context.Courses.Where(c => c.CourseName == "Math")
                .Include(c =>c.Student.FirstName == NAME).FirstOrDefault();
            context.Dispose();

            if (resultado != null)
                Console.WriteLine(resultado.CourseName.ToString());
            else
                Console.WriteLine("We cant find the student!!");
        }

        private static void QuerryUsingSql()
        {
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
    }
}
