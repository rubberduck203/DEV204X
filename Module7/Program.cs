using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module7
{
    class Program
    {
        static void Main(string[] args)
        {
            var teacher = new Teacher("\"Uncle\" Bob", "Martin", new DateTime(1948, 10, 8));

            var cleanCode = new Course("Clean Code 101", "McConnell", "42A", new[] { teacher });

            var joe = new Student("Joe", "Smith", new DateTime(1985, 4, 13));
            var john = new Student("John", "Doe", new DateTime(1984, 1, 31));
            var jane = new Student("Jane", "Doe", new DateTime(1988, 9, 22));

            cleanCode.Students.Add(joe);
            cleanCode.Students.Add(john);
            cleanCode.Students.Add(jane);

            foreach (Student student in cleanCode.Students)
            {
                AssignRandomGrades(student);
            }

            var compSci = new Degree("Computer Science", DegreeType.Bachelor);
            compSci.Courses.Add(cleanCode);

            var program = new UProgram("Information Technology", 30.5m);
            program.Degrees.Add(compSci);

            WriteProgramInfo(program);

            cleanCode.ListStudents();
        }

        private static void WriteProgramInfo(UProgram program)
        {
            var degree = program.Degrees.First();
            Console.WriteLine("The {0} program contains the {1} degree.\n", program.Name, degree);

            var course = degree.Courses.First();
            Console.WriteLine("The {0} degree contains the course {1}.\n", degree, course);

            Console.WriteLine("The {0} course has {1} student(s).\n", course, course.Students.Count);
        }

        // Much like our peer reviews here, we'll just give people random grades ;)
        private static void AssignRandomGrades(Student student)
        {
            var randomNumGenerator = new Random();

            for (var i = 0; i < 5; i++)
            {
                double grade = randomNumGenerator.NextDouble() * 100; //Next double returns a value between 0.0 and 1.0, multiply by 100 to get a percentage grade
                student.Grades.Push(grade);
            }
        }
    }

    #region models
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

        internal Stack Grades { get; private set; }

        internal Student(string first, string last, DateTime dateOfBirth)
            : base(first, last, dateOfBirth)
        {
            TotalCount = TotalCount + 1;
            this.Grades = new Stack();
        }

        internal string Learn()
        {
            return this.ToString() + " is learning.";
        }
    }

    internal class Teacher : Person
    {
        internal Teacher(string first, string last, DateTime dateOfBirth)
            : base(first, last, dateOfBirth)
        { }

        internal string Teach()
        {
            return this.ToString() + " is teaching.";
        }
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
        internal ArrayList Students { get; set; }

        internal Course(string name, string building, string room, Teacher[] teachers)
            : this(name, building, room, teachers, new Student[]{ })
        { }

        internal Course(string name, string building, string room, Teacher[] teachers, Student[] students)
        {
            this.Name = name;
            this.Building = building;
            this.Room = room;
            this.Teachers = teachers;
            this.Students = new ArrayList(students);
        }

        internal void ListStudents()
        {
            //I really don't like this. Course shouldn't be responsible for writing to the Console,
            // but the instructions said to do it this way. This method belongs to Program by all rights.

            Console.WriteLine("Students in {0}", this.Name);
            Console.WriteLine("-------------------------------------");

            foreach(Student student in this.Students)
            {
                Console.WriteLine(student.ToString());
            }

            Console.WriteLine(); 
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

#endregion 

}
