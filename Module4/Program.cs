using System;

namespace Module4
{
    class Program
    {
        static void Main(string[] args)
        {
            var teacher = new Teacher("Bob", "Martin");
            var program = new ProgramOfStudy("Comp. Sci.", 20);
            var course = new Course("Clean Code 101", "McConnell", "203A", program, teacher);

            var students = new Student[5];

            var joe = students[0];
            joe.FirstName = "Joe";
            joe.LastName = "Smith";
            joe.DateOfBirth = new DateTime(1985, 4, 29);
            joe.ProgramOfStudy = program;
            joe.Courses = new[] { course };

            Console.WriteLine("Student Name: {0} {1}", joe.FirstName, joe.LastName);
            Console.WriteLine("DoB: {0}", joe.DateOfBirth.ToShortDateString());
            Console.WriteLine("Program of Study: {0}", joe.ProgramOfStudy.Name);
            WriteCourses(joe.Courses);
        }

        private static void WriteCourses(Course[] courses)
        {
            Console.WriteLine("Courses:");
            foreach (var course in courses)
            {
                Console.WriteLine("\t {0}; {1} {2}; {3} Building {4}", 
                    course.Name, course.Teacher.FirstName, course.Teacher.LastName, course.Building, course.Room);
            }
        }

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
        }
    }
}
