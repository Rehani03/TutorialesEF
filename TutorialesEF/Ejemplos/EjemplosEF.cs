﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TutorialesEF.DAL;
using TutorialesEF.Entidades;

namespace TutorialesEF.Ejemplos
{
    public class EjemplosEF
    {
        public static void GuardarStudentDB()
        {
            //Ejemplo de guardar en DB
            SchoolContext context = new SchoolContext();
            try
            {
                var auxStudent = new Student()
                {
                    StudentId = 0,
                    FirstName = "Michael",
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

        public static void GuardarCourseDB()
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


        public static void SimpleQueryDB()
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

        public static void DoubleQueryDB()
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

        public static void QuerryUsingSql()
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

        public static void UpdatingData()
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
                    Console.WriteLine("We cant modify the student..");

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

        public static void DeletingData()
        {
            //En este ejemplo modificamos el nombre del primer estudiante
            SchoolContext context = new SchoolContext();

            try
            {
                var std = context.Students.First<Student>();
                context.Students.Remove(std);
                bool deleted = context.SaveChanges() > 0;

                if (deleted)
                    Console.WriteLine("Student deleted..");
                else
                    Console.WriteLine("We cant delete the student..");

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

        public static void UpdatingOnDisconnectedScenario()
        {
            SchoolContext context = new SchoolContext();
            try
            {
                var modifiedStudent1 = new Student()
                {
                    StudentId = 1,
                    FirstName = "Bill",
                    LastName = "Madison"
                };

                var modifiedStudent2 = new Student()
                {
                    StudentId = 2,
                    FirstName = "Steve",
                    LastName = "Perez"
                };

                List<Student> modifiedStudents = new List<Student>()
                {
                    modifiedStudent1,
                    modifiedStudent2,
                };

                context.UpdateRange(modifiedStudents);
                bool modified = context.SaveChanges() > 0;
                if (modified)
                    Console.WriteLine("Modified");

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

        public static void DeletingOnDisconnectedScenario()
        {
            SchoolContext context = new SchoolContext();

            try
            {
                List<Student> StudentList = new List<Student>()
                {
                   new Student()
                   {
                       StudentId = 1
                   },
                   new Student()
                   {
                       StudentId = 2
                   }
                };

                context.RemoveRange(StudentList);
                bool removed = context.SaveChanges() > 0;

                if (removed)
                    Console.WriteLine("List Removed..");
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