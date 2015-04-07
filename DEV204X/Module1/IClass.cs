using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEV204X.Module1
{
    internal interface IClass
    {
        string Name { get; set; }
        decimal CreditHours { get; set; }
        string Building { get; set; }
        string Room { get; set; }
        DateTime ScheduledTime { get; set; }
    }
}
