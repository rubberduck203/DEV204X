using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEV204X.Module1
{
    internal interface IClass
    {
        string Name { get; }
        decimal CreditHours { get; }
        string Building { get; }
        string Room { get; }
        DateTime ScheduledTime { get; }
    }
}
