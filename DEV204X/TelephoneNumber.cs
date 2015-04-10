using System;

namespace DEV204X
{
    internal class TelephoneNumber : ITelephoneNumber
    {
        public int CountryCode { get; set; }
        public int AreaCode { get; set; }
        public int Exchange { get; set; }
        public int SubscriberNumber { get; set; }

        public TelephoneNumber(long phone)
        {
            //todo: rethink arg checking. Right now, this just needs to work for well formatted input.
            var digits = phone.ToString();
            if (digits.Length == 11)
            {
                this.CountryCode = Convert.ToInt32(digits.Substring(1,1));
                this.AreaCode = Convert.ToInt32(digits.Substring(2, 3));
                this.Exchange = Convert.ToInt32(digits.Substring(4, 3));
                this.SubscriberNumber = Convert.ToInt32(digits.Substring(7));
            }
            else
            {
                this.CountryCode = 1; //assume US
                this.AreaCode = Convert.ToInt32(digits.Substring(0, 3));
                this.Exchange = Convert.ToInt32(digits.Substring(3, 3));
                this.SubscriberNumber = Convert.ToInt32(digits.Substring(6));
            }
        }

        public override string ToString()
        {
            return string.Format("{0}+({1}){2}-{3}", 
                this.CountryCode, this.AreaCode, this.Exchange, this.SubscriberNumber);
        }
    }
}
