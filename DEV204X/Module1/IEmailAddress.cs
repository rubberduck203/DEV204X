namespace DEV204X.Module1
{
    /// <summary>
    /// Represents an email address.
    /// http://en.wikipedia.org/wiki/Email_address
    /// </summary>
    internal interface IEmailAddress
    {
        string Local { get; }
        string Domain { get; }
    }
}
