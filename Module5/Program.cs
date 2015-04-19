using System;
using System.Linq;

namespace Module5
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Student Count: {0}.\n",Student.TotalCount);
            
            var student1 = new Student("Joe", "Smith", new DateTime(1985, 4, 13));
            //Console.WriteLine("Student Count: {0}.\n", Student.TotalCount);

            var student2 = new Student("John", "Doe", new DateTime(1984, 1, 31));
            //Console.WriteLine("Student Count: {0}.\n", Student.TotalCount);

            var student3 = new Student("Jane", "Doe", new DateTime(1988, 9, 22));
            //Console.WriteLine("Student Count: {0}.\n", Student.TotalCount);

            // new Student[] {...} could be just new []{...}
            // but I figured it's good to be explicit for the purpose of the course
            var students = new Student[] {student1, student2, student3}; 

            var teacher = new Teacher("\"Uncle\" Bob", "Martin", new DateTime(1948, 10, 8));

            var cleanCode = new Course("Clean Code 101", "McConnell", "42A", new[] {teacher}, students);

            var compSci = new Degree("Computer Science", DegreeType.Bachelor);
            compSci.Courses.Add(cleanCode);

            var program = new UProgram("Information Technology", 30.5m);
            program.Degrees.Add(compSci);

            WriteProgramInfo(program);
        }

        private static void WriteProgramInfo(UProgram program)
        {
            var degree = program.Degrees.First();
            Console.WriteLine("The {0} program contains the {1} degree.\n", program.Name, degree);

            var course = degree.Courses.First();
            Console.WriteLine("The {0} degree contains the course {1}.\n", degree, course);

            Console.WriteLine("The {0} course has {1} student(s).\n", course, course.Students.Length);
        }
    }
}
