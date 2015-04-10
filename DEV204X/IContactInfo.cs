namespace DEV204X
{
    internal interface IContactInfo
    {
        IAddress Address { get; }
        IEmailAddress EmailAddress { get; }
        ITelephoneNumber TelephoneNumber { get; }
    }
}
