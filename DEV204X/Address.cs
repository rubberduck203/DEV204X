using System;

namespace DEV204X
{
    internal class Address : IAddress
    {
        public string Line1 { get; private set; }
        public string Line2 { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public int ZipCode { get; private set; }
        public string Country { get; private set; }

        public Address(string line1, string line2, string city, string state, int zip, string country)
        {
            //very crude range checking http://en.wikipedia.org/wiki/List_of_ZIP_code_prefixes
            //also ignores zip + 4
            const int minZip = 100;
            const int maxZip = 100000;

            if (zip < minZip || zip >= maxZip)
            {
                throw new ArgumentOutOfRangeException(string.Format("ZipCode must be greater than {0} and less than {1}.", minZip, maxZip));
            }

            this.Line1 = line1;
            this.Line2 = line2;
            this.City = city;
            this.State = state;
            this.ZipCode = zip;
            this.Country = country;
        }

        public Address(string line1, string city, string state, int zip, string country)
            : this(line1, string.Empty, city, state, zip, country)
        {
        }
    }
}
