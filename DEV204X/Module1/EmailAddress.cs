using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEV204X.Module1
{
    internal class EmailAddress : IEmailAddress
    {
        public string Local { get; private set; }
        public string Domain { get; private set; }

        public EmailAddress(string local, string domain)
        {
            this.Local = local;
            this.Domain = domain;
        }

        public EmailAddress(string email)
        {
            var addressParts = email.Split(new[] {'@'});
            this.Local = addressParts[0];
            this.Domain = addressParts[1];
        }

        public override string ToString()
        {
            return this.Local + "@" + this.Domain;
        }
    }
}
