using System;
using System.Collections.Generic;
using System.Linq;

namespace DEV204X
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var student = GetJoeSmith();
            var professor = GetServiusSnape();

            WriteStudentInfo(student);
            WriteRecordSeparator();
            
            WritePersonInfo(professor);
            WriteRecordSeparator();

            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }

        static void WriteRecordSeparator()
        {
            Console.WriteLine();
            Console.WriteLine("-----------------------------");
            Console.WriteLine();
        }

        static void WriteStudentInfo(IStudent student)
        {
            WritePersonInfo(student);
            Console.WriteLine();
            Console.WriteLine("Program of Study: {0}", student.ProgramOfStudy);
            Console.WriteLine("Degree Pursued: {0}", student.PursuedDegree);
        }

        static void WritePersonInfo(IPerson person)
        {
            Console.WriteLine(person.GetType().Name);

            Console.WriteLine();
            Console.WriteLine("First: {0} Last: {1}   DoB: {2}", person.FirstName, person.LastName, person.DateOfBirth.ToString("d"));
            WriteContactInfo(person.ContactInfo);
        }

        static void WriteContactInfo(IContactInfo contact)
        {
            Console.WriteLine("Email: {0}   Tel: {1}", contact.EmailAddress, contact.TelephoneNumber);
            WriteAddress(contact.Address);
        }

        static void WriteAddress(IAddress address)
        {
            Console.WriteLine(address.Line1);
            
            if (!String.IsNullOrWhiteSpace(address.Line2))
            {
                Console.WriteLine(address.Line2);
            }

            Console.WriteLine("{0}, {1} {2} {3}", address.City, address.State, address.ZipCode, address.Country);
        }

        static Student GetJoeSmith()
        {
            var address = new Address("6578 Foobar Lane", "New York", "NY", 85624, "USA");
            var classes = GetClassList();

            return
                new Student("Joe", "Smith",
                    new DateTime(1985, 6, 3),
                    new ContactInfo(
                            address, 
                            new EmailAddress("Joe.Smith@gmail.com"),
                            new TelephoneNumber(5555557648)
),
                    classes,
                    "Computer Science",
                    DegreeType.Bachelor
                    );

        }

        static Professor GetServiusSnape()
        {
            var address = new Address("2121 Mockingbird Dr.", "Apt. 13", "Hogwarts", "MA", 45645, "USA");
            var networkSecurity = GetClassList().Last();

            return new Professor(
                    "Servius", "Snape", new DateTime(1962),
                    new ContactInfo(
                            address, 
                            new EmailAddress("BiteItDarkLord@yahoo.com"), 
                            new TelephoneNumber(9358675309)
                            ),
                    new List<IClass> { networkSecurity }
                );
        }

        static IList<IClass> GetClassList()
        {
            return new List<IClass>
            {
                new Class("Algorithms 101", 1.5m, "Hawking", "202A", new DateTime(1,1,1,8,0,0)),
                new Class("Network Security", 2.0m, "Fowler", "301B", new DateTime(1,1,1,10,0,0))
            };
        }
    }
}
