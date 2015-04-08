namespace DEV204X.Module1
{
    internal interface IContactInfo
    {
        IAddress Address { get; }
        IEmailAddress EmailAddress { get; }
        ITelephoneNumber TelephoneNumber { get; }
    }
}
