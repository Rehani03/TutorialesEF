using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using TutorialesEF.DAL;
using TutorialesEF.Entidades;

namespace TutorialesEF
{
    class Program
    {
       
        static void Main(string[] args)
        {
            //GuardarDB(); //Ejemplo de guardar en DB
            //SimpleQueryDB(); //Ejemplo de hacer un query en DB

        }

        private static void GuardarDB()
        {
            //Ejemplo de guardar en DB
            SchoolContext context = new SchoolContext();
            var auxStudent = new Student()
            {
                StudentId = 0,
                FirstName = "Michael"
            };
            context.Students.Add(auxStudent);
            bool save = context.SaveChanges() > 0;
            context.Dispose();

            if(save)
                Console.WriteLine("The Student was sucessfully saved!!");
            else
                Console.WriteLine("We cant save the student..");
        }

        private static void SimpleQueryDB()
        {
            //Ejemplo del Querying
            const string  NAME = "Michael";
            SchoolContext context = new SchoolContext();
            var list = context.Students.Where(s => s.FirstName == NAME).ToList();
            context.Dispose();

            if (list != null)
            {
                foreach (var item in list)
                {
                    Console.WriteLine(item.FirstName);
                }
                Console.ReadKey();
            }
            else
                Console.WriteLine("We cant find the student!!");   
        }

        private static void DoubleQueryDB()
        {
            //Ejemplo del Querying
            const string NAME = "Michael";
            SchoolContext context = new SchoolContext();
            var list = context.Students.Where(s => s.FirstName == NAME).ToList();
            context.Dispose();

            if (list != null)
            {
                foreach (var item in list)
                {
                    Console.WriteLine(item.FirstName);
                }
                Console.ReadKey();
            }
            else
                Console.WriteLine("We cant find the student!!");
        }

    }
}
