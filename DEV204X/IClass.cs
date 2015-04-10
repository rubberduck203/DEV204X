using System;

namespace DEV204X
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
