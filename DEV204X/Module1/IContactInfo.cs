using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEV204X.Module1
{
    internal interface IContactInfo
    {
        IAddress Address { get; set; }
        IEmailAddress EmailAddress { get; set; }
        ITelephoneNumber TelephoneNumber { get; set; }
    }
}
