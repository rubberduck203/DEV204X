using System;
using System.Collections.Generic;

namespace DEV204X.Module1
{
    internal class Student : Person, IStudent
    {
        public string ProgramOfStudy { get; set; }
        public DegreeType PursuedDegree { get; set; }

        public Student
            (
                string first, string last, DateTime dateOfBirth, IContactInfo contactInfo, IList<IClass> classes,
                string programOfStudy, DegreeType degree            
            )
            :base(first, last, dateOfBirth, contactInfo, classes)
        {
            this.ProgramOfStudy = programOfStudy;
            this.PursuedDegree = degree;
        }
    }
}
