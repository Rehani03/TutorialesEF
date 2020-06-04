using System;
using System.Collections.Generic;
using System.Text;
using TutorialesEF.DAL;
using TutorialesEF.Entidades;

namespace TutorialesEF.BLL
{
    public class TutorialesEjemplosBLL
    {
        public TutorialesEjemplosBLL()
        {

        }

        public bool EscribirDB(Student student)
        {
            SchoolContext context = new SchoolContext();
            bool save;
            try
            {
                context.Students.Add(student);
                save = context.SaveChanges() > 0;
            }
            catch
            {
                throw;
            }
            finally
            {
                context.Dispose();
            }
            return save;
        }
    }
}
