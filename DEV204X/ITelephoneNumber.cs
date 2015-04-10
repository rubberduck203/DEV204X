namespace DEV204X
{
    /// <summary>
    /// Telephone number using the North American Numbering Plan
    /// http://en.wikipedia.org/wiki/North_American_Numbering_Plan
    /// </summary>
    internal interface ITelephoneNumber
    {
        int CountryCode { get; }
        int AreaCode { get; }
        int Exchange { get; }
        int SubscriberNumber { get; }
    }
}
