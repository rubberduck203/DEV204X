namespace DEV204X
{
    internal class ContactInfo : IContactInfo
    {
        public IAddress Address { get; private set; }
        public IEmailAddress EmailAddress { get; private set; }
        public ITelephoneNumber TelephoneNumber { get; private set; }

        public ContactInfo(IAddress address, IEmailAddress email, ITelephoneNumber phoneNumber)
        {
            this.Address = address;
            this.EmailAddress = email;
            this.TelephoneNumber = phoneNumber;
        }
    }
}
