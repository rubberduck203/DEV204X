using System;
using System.Collections.Generic;

namespace DEV204X
{
    internal interface IPerson
    {
        string FirstName { get; }
        string LastName { get; }
        DateTime DateOfBirth { get; }
        IContactInfo ContactInfo { get; }
        IList<IClass> Classes { get; }
    }
}
