using System;
using System.Collections.Generic;
using System.Text;

namespace TutorialesEF.Entidades
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Student()
        {
            StudentId = 0;
            FirstName = string.Empty;
            LastName = string.Empty;
        }
    }
}
