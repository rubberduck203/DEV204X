using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mod_9_Homework
{
    internal class Student
    {
        internal string FistName { get; set; }
        internal string LastName { get; set; }
        internal string City { get; set; }

        internal Student(string first, string last, string city)
        {
            this.FistName = first;
            this.LastName = last;
            this.City = city;
        }
    }
}
