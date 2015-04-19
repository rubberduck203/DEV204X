using System;
using System.Collections.Generic;

namespace Module6
{
    internal abstract class Person
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime DateOfBirth { get; private set; }

        protected Person(string first, string last, DateTime dateOfBirth)
        {
            this.FirstName = first;
            this.LastName = last;
            this.DateOfBirth = dateOfBirth;
        }

        public override string ToString()
        {
            return String.Format("{0} {1}", FirstName, LastName);
        }
    }

    internal class Student : Person
    {
        internal static int TotalCount;

        internal Student(string first, string last, DateTime dateOfBirth)
            : base(first, last, dateOfBirth)
        {
            TotalCount = TotalCount + 1;
        }
    }

    internal class Teacher : Person
    {
        internal Teacher(string first, string last, DateTime dateOfBirth)
            : base(first, last, dateOfBirth)
        { }
    }

    internal class UProgram
    {
        internal string Name { get; set; }
        internal decimal RequiredCreditHours { get; set; }
        internal List<Degree> Degrees { get; set; }

        internal UProgram(string name, decimal creditHours, List<Degree> degrees)
        {
            this.Name = name;
            this.RequiredCreditHours = creditHours;
            this.Degrees = degrees;
        }

        internal UProgram(string name, decimal creditHours)
            : this(name, creditHours, new List<Degree>())
        { }

        public override string ToString()
        {
            return this.Name;
        }
    }

    internal class Course
    {
        internal string Name { get; set; }
        internal string Building { get; set; }
        internal string Room { get; set; }
        internal Teacher[] Teachers { get; set; }//A list would be better, but requirements call for an array.
        internal Student[] Students { get; set; }

        internal Course(string name, string building, string room, Teacher[] teachers, Student[] students)
        {
            this.Name = name;
            this.Building = building;
            this.Room = room;
            this.Teachers = teachers;
            this.Students = students;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }

    internal enum DegreeType
    {
        Associate,
        Bachelor,
        Master,
        Doctorate
    }

    internal class Degree
    {
        internal string Name { get; private set; }
        internal DegreeType DegreeType { get; private set; }
        internal List<Course> Courses { get; private set; }

        internal Degree(string name, DegreeType type, List<Course> courses)
        {
            this.Name = name;
            this.DegreeType = type;
            this.Courses = courses;
        }

        internal Degree(string name, DegreeType type)
            : this(name, type, new List<Course>())
        { }

        public override string ToString()
        {
            return String.Format("{0} of {1}", this.DegreeType, this.Name);
        }
    }
}
