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
            QueryDB(); //Ejemplo de hacer un query en DB

        }

        private static void GuardarDB()
        {
            //Ejemplo de guardar en DB
            SchoolContext context = new SchoolContext();
            var auxStudent = new Student()
            {
                StudentId = 0,
                Name = "Michael"
            };
            context.Students.Add(auxStudent);
            bool save = context.SaveChanges() > 0;
            context.Dispose();

            if(save)
                Console.WriteLine("The Student was sucessfully saved!!");
            else
                Console.WriteLine("We cant save the student..");
        }

        private static void QueryDB()
        {
            //Ejemplo del Querying
            const string  NAME = "Bill";
            SchoolContext context = new SchoolContext();
            var list = context.Students.Where(s => s.Name == NAME).ToList();
            context.Dispose();

            if (list != null)
            {
                foreach (var item in list)
                {
                    Console.WriteLine(item.Name);
                }
                Console.ReadKey();
            }
            else
                Console.WriteLine("We cant find the student!!");
            
        }
       
    }
}
