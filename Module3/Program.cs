using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Module3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Program Information\n");
            var programs = GetPrograms();

            Console.WriteLine("Enter Teacher Information\n");
            var teacher = GetTeacherInfo();
            Console.WriteLine();

            Console.WriteLine("Enter Course Information\n");
            var courses = GetCourses(new List<Teacher>() {teacher}, programs);
            Console.WriteLine();

            Console.WriteLine("Enter Student Information\n");
            var student = GetStudentInfo(programs, courses);
            Console.WriteLine();

            WriteStudentDetails(student);

            Console.WriteLine(IsValidStudentDateOfBirth(student.DateOfBirth));
        }

        private static bool IsValidStudentDateOfBirth(DateTime dateOfBirth)
        {
            throw new NotImplementedException();
        }

        private static List<ProgramOfStudy> GetPrograms()
        {
            var programs = new List<ProgramOfStudy>();
            bool done = false;

            do
            {
                programs.Add(GetProgramInfo());
                done = PromptUserForAnother<ProgramOfStudy>();
            } while (!done);

            return programs;
        }

        private static ProgramOfStudy GetProgramInfo()
        {
            var program = new ProgramOfStudy();

            Console.Write("Name: ");
            program.Name = Console.ReadLine();
            Console.Write("Credit Hours: ");
            program.RequiredCreditHours = PromptForCreditHours();
            
            return program;
        }

        private static decimal PromptForCreditHours()
        {
            decimal creditHours;
            if (decimal.TryParse(Console.ReadLine(), out creditHours))
            {
                return creditHours;
            }
            else
            {
                Console.WriteLine("Invalid Number of Credit Hours. Please Try Again.\n");
                return PromptForCreditHours();
            }
        }

        private static List<Course> GetCourses(IEnumerable<Teacher> possibleTeachers, IEnumerable<ProgramOfStudy> possiblePrograms)
        {
            var courses = new List<Course>();
            bool done = false;

            do
            {
                courses.Add(GetCourseInfo(possibleTeachers, possiblePrograms));
                done = PromptUserForAnother<Course>();
            } while (!done);
            return courses;
        }

        private static Course GetCourseInfo(IEnumerable<Teacher> possibleTeachers, IEnumerable<ProgramOfStudy> possiblePrograms )
        {
            var course = new Course();
            
            Console.WriteLine();
            Console.Write("Couse Name: ");
            course.Name = Console.ReadLine();

            Console.Write("Building: ");
            course.Building = Console.ReadLine();

            Console.Write("Room: ");
            course.Room = Console.ReadLine();

            course.ProgramOfStudy = GetSelection(possiblePrograms);

            course.Teacher = GetSelection(possibleTeachers);

            return course;
        }

        private static Student GetStudentInfo(IEnumerable<ProgramOfStudy> possiblePrograms, IEnumerable<Course> possibleCourses )
        {
            var student = new Student();
            student.FirstName = GetFirstName();
            student.LastName = GetLastName();
            student.DateOfBirth = GetDateOfBirth();
            student.ProgramOfStudy = GetSelection(possiblePrograms);
            //todo: allow selection of many courses
            student.Courses = new[] {GetSelection(possibleCourses)};

            return student;
        }

        private static Teacher GetTeacherInfo()
        {
            return new Teacher
            {
                FirstName = GetFirstName(), 
                LastName = GetLastName()
            };
        }

        private static string GetFirstName()
        {
            Console.Write("First Name: ");
            return Console.ReadLine();
        }

        private static string GetLastName()
        {
            Console.Write("Last Name: ");
            return Console.ReadLine();
        }

        private static DateTime GetDateOfBirth()
        {
            Console.Write("Date of Birth (mm/dd/yyyy): ");

            DateTime dob;
            if (DateTime.TryParse(Console.ReadLine(), out dob))
            {
                return dob;
            }
            else
            {
                Console.WriteLine("Invalid Date. Please Try Again.\n");
                return GetDateOfBirth();
            }

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

        private static void WriteTeacherDetails(Teacher teacher)
        {
            Console.WriteLine("Teacher Name: {0} {1}", teacher.FirstName, teacher.LastName);
        }

        private static void WriteStudentDetails(Student student)
        {
            Console.WriteLine("Student Name: {0} {1}", student.FirstName, student.LastName);
            Console.WriteLine("DoB: {0}", student.DateOfBirth.ToShortDateString());
            Console.WriteLine("Program of Study: {0}", student.ProgramOfStudy.Name);
            WriteCourses(student.Courses);
        }

        private static T GetSelection<T>(IEnumerable<T> collection)
        {
            Console.WriteLine("Select {0}", typeof(T).Name);

            var i = 1;
            foreach (var item in collection)
            {
                Console.WriteLine("[{0}] {1}", i, item.ToString());
                i += 1;
            }
            Console.WriteLine();

            int index;
            if (int.TryParse(Console.ReadLine(), out index))
            {
                if (index <= collection.Count())
                {
                    return collection.ElementAt(index - 1);
                }
            }

            Console.WriteLine("Invalid Selection. Please Try Again.\n");
            return GetSelection<T>(collection);
        }

        private static bool PromptUserForAnother<T>()
        {
            Console.WriteLine("Add another {0}? [y\\n]", typeof(T).Name);
            var input = Console.ReadLine().ToLower();
            if (input == "n")
            {
                return true;
            }
            else if (input != "y")
            {
                Console.WriteLine("Invalid Input.");
                return PromptUserForAnother<T>();
            }

            return false;
        }
    }
}
