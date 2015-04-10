using System;

namespace DEV204X
{
    internal class Class : IClass
    {
        public string Name { get; private set; }
        public decimal CreditHours { get; private set; }
        public string Building { get; private set; }
        public string Room { get; private set; }
        public DateTime ScheduledTime { get; private set; }

        public Class(string name, decimal creditHours, string building, string room, DateTime time)
        {
            this.Name = name;
            this.CreditHours = creditHours;
            this.Building = building;
            this.Room = room;
            this.ScheduledTime = time;
        }
    }
}
