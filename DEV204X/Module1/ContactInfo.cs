using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEV204X.Module1
{
    internal class ContactInfo : IContactInfo
    {
        public IAddress Address { get; private set; }
        public IEmailAddress EmailAddress { get; private set; }
        public ITelephoneNumber TelephoneNumber { get; private set; }

        public ContactInfo(IAddress address, IEmailAddress email, ITelephoneNumber phoneNumber)
        {
            this.Address = address;
            this.EmailAddress = email;
            this.TelephoneNumber = phoneNumber;
        }
    }
}
