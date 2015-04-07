using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DEV204X.Module1
{
    //Professor could technically be a Person, but it's nice to have the typing for reflection
    internal class Professor : Person
    {
        public Professor(string first, string last, DateTime dateOfBirth, IContactInfo contactInfo, IList<IClass> classes)
            : base(first, last, dateOfBirth, contactInfo, classes)
        {
        }

        public Professor(string first, string last, DateTime dateOfBirth, IContactInfo contactInfo)
            :this(first, last, dateOfBirth, contactInfo, new List<IClass>())
        {     
        }
    }
}
