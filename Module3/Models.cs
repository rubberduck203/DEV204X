using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module3
{
    internal struct Student
    {
        internal string FirstName;
        internal string LastName;
        internal DateTime DateOfBirth;
        internal ProgramOfStudy ProgramOfStudy;
        internal Course[] Courses;
    }

    internal struct ProgramOfStudy
    {
        internal string Name;
        internal decimal RequiredCreditHours;

        internal ProgramOfStudy(string name, decimal creditHours)
        {
            this.Name = name;
            this.RequiredCreditHours = creditHours;
        }

        //over-riding ToString for the generic GetSelection method; 
        //should really have an interface for this
        public override string ToString()
        {
            return this.Name;
        }
    }

    internal struct Course
    {
        internal string Name;
        internal string Building;
        internal string Room;
        internal Teacher Teacher;
        internal ProgramOfStudy ProgramOfStudy;

        internal Course(string name, string building, string room, ProgramOfStudy program, Teacher teacher)
        {
            this.Name = name;
            this.Building = building;
            this.Room = room;
            this.ProgramOfStudy = program;
            this.Teacher = teacher;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }

    internal struct Teacher
    {
        internal string FirstName;
        internal string LastName;

        internal Teacher(string first, string last)
        {
            this.FirstName = first;
            this.LastName = last;
        }

        //over-riding ToString for the generic GetSelection method
        public override string ToString()
        {
            return String.Format("{0} {1}", FirstName, LastName);
        }
    }
}
