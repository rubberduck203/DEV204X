using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEV204X.Module1
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
