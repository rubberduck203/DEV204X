using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DEV204X.Module1
{
    internal class TelephoneNumber : ITelephoneNumber
    {
        public int CountryCode { get; set; }
        public int AreaCode { get; set; }
        public int Exchange { get; set; }
        public int SubscriberNumber { get; set; }

        public TelephoneNumber(int phone)
        {
            //todo: rethink arg checking. Right now, this just needs to work for well formatted input.
            var digits = phone.ToString();
            if (digits.Length == 10)
            {
                this.CountryCode = digits[0];
                this.AreaCode = Convert.ToInt32(digits.Substring(2, 3));
                this.Exchange = Convert.ToInt32(digits.Substring(5, 3));
                this.SubscriberNumber = Convert.ToInt32(digits.Substring(8));
            }
            else
            {
                this.CountryCode = 1; //assume US
                this.AreaCode = Convert.ToInt32(digits.Substring(1, 3));
                this.Exchange = Convert.ToInt32(digits.Substring(4, 3));
                this.SubscriberNumber = Convert.ToInt32(digits.Substring(7));
            }
        }

        public override string ToString()
        {
            return string.Format("{0}+({1}){2}-{3}", 
                this.CountryCode, this.AreaCode, this.Exchange, this.SubscriberNumber);
        }
    }
}
