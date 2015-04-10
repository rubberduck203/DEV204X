namespace DEV204X
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
