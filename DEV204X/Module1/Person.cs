using System;
using System.Collections.Generic;

namespace DEV204X.Module1
{
    internal class Person : IPerson
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public IContactInfo ContactInfo { get; private set; }
        public IList<IClass> Classes { get; private set; }

        public Person(string first, string last, DateTime dateOfBirth, IContactInfo contactInfo, IList<IClass> classes)
        {
            this.FirstName = first;
            this.LastName = last;
            this.DateOfBirth = dateOfBirth;
            this.ContactInfo = contactInfo;
            this.Classes = classes;
        }

        public Person(string first, string last, DateTime dateOfBirth, IContactInfo contactInfo)
            : this(first, last, dateOfBirth, contactInfo, new List<IClass>())
        {
        }
    }
}
