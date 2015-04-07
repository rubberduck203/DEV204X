using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEV204X.Module1
{
    /// <summary>
    /// Represents an email address.
    /// http://en.wikipedia.org/wiki/Email_address
    /// </summary>
    internal interface IEmailAddress
    {
        string Local { get; set; }
        string Domain { get; set; }
    }
}
