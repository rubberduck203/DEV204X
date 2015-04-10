namespace DEV204X
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
