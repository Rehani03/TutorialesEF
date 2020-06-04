using System;
using TutorialesEF.BLL;
using TutorialesEF.Entidades;

namespace TutorialesEF
{
    class Program
    {
       
        static void Main(string[] args)
        {
            //Ejemplo de guardar en DB
            GuardarDB();
        }

        private static void GuardarDB()
        {
            //Ejemplo de guardar en DB
            TutorialesEjemplosBLL tutoriales = new TutorialesEjemplosBLL();
            var auxStudent = new Student()
            {
                StudentId = 0,
                Name = "Bill"
            };

            if (tutoriales.EscribirDB(auxStudent))
                Console.WriteLine("The Student was sucessfully saved!!");
            else
                Console.WriteLine("We cant save the student..");
        }
       
    }
}
