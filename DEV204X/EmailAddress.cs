namespace DEV204X
{
    internal class EmailAddress : IEmailAddress
    {
        public string Local { get; private set; }
        public string Domain { get; private set; }

        public EmailAddress(string local, string domain)
        {
            this.Local = local;
            this.Domain = domain;
        }

        public EmailAddress(string email)
        {
            var addressParts = email.Split('@');
            this.Local = addressParts[0];
            this.Domain = addressParts[1];
        }

        public override string ToString()
        {
            return this.Local + "@" + this.Domain;
        }
    }
}
