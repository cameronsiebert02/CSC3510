using System;
namespace PhoneNumberChecker
{
	public class PhoneNumber
	{
		private string phoneNumber;

        public PhoneNumber(string phoneNumber)
		{
			this.phoneNumber = phoneNumber;
		}
		public bool isValidPhone()
		{
			if(phoneNumber.Length == 12)
			{
				if (isValid12Length())
				{
					if (!justDigits())
					{
						return false;
					}
				}
				if (!validAreaCode())
				{
					return false;
				}
			}
			if (isValidLength())
			{
				return true;
			}
			return false;
		}

        public bool validAreaCode()
        {
			char digit1 = phoneNumber[0];
			if(digit1 == '0' || digit1 == '1')
			{
				return false;
			}
			return true;
        }

        public bool justDigits()
        {
			string pNum = phoneNumber.Replace("-", "");
			if(pNum.Length != 10)
			{
				return false;
			}
			foreach(char c in pNum)
			{
				if (!char.IsDigit(c))
				{
					return false;
				}
			}
			return true;
        }

        public bool isValid12Length()
        {
			int count = 0;
			foreach(char c in phoneNumber)
			{
				if(count == 3 || count == 7)
				{
					if( c != '-')
					{
						return true;
					}
				}
				count++;
			}
			return false;
        }

        private bool isValidLength()
        {
            string pNum = phoneNumber.Replace("-", "");
            if (pNum.Length == 7 || pNum.Length == 10)
			{
				return true;
			}
			return false;
        }
    }
}