using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEV204X.Module1
{
    internal interface IAddress
    {
        string Line1 { get; }
        string Line2 { get; }
        string City { get; }
        string State { get; }
        int ZipCode { get; }
        string Country { get; }
    }
}
