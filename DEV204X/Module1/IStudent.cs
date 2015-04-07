using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEV204X.Module1
{
    internal enum DegreeType
    {
        Associate,
        Bachelor,
        Master,
        Doctorate
    };

    internal interface IStudent : IPerson
    {
        string ProgramOfStudy { get; }
        DegreeType PursuedDegree { get; }
    }
}
