using System;
namespace CheckerHW
{
	public class Checker
	{
		string inPassword;
		public Checker(string inPassword)
		{
			this.inPassword = inPassword;
		}
		public string checkPassword()
		{
			string retString = "0";
			if (inPassword.Length < 8)
			{
				retString = "1";
			}
			if (checkForUpper() == false)
			{
				if(retString.Equals("0"))
				{
					retString = "2";
				}
				else
				{
					retString += ",2";
				}
			}
			if (checkForLower() ==  false)
			{
				if(retString.Equals("0"))
				{
					retString = "3";
				}
				else
				{
					retString += ",3";
				}
			}
			if (checkForChars() == false)
			{
				if(retString.Equals("0"))
				{
					retString = "4";
				}
				else
				{
					retString += ",4";
				}
			}
			if (checkForDigits() == false)
			{
				if(retString.Equals("0"))
				{
					retString = "5";
				}
				else
				{
					retString += ",5";
				}
			}
			if (checkForWords() == false)
			{
				if(retString.Equals("0"))
				{
					retString = "6";
				}
				else
				{
					retString += ",6";
				}
			}
			return retString;
		}

        private bool checkForWords()
        {
			if (!(inPassword.Contains("max") || inPassword.Contains("bank") || inPassword.Contains("money") || inPassword.Contains("cash")))
			{
				return true;
			}
			return false;
        }

        private bool checkForDigits()
        {
			int total = 0;
            foreach (char character in inPassword)
			{
				if (Char.IsDigit(character))
				{
					total++;
				}
			}
			if(total >= 2)
			{
				return true;
			}
			return false;
        }

        private bool checkForChars()
        {
            foreach (char character in inPassword)
			{
				if (character.Equals('*') || character.Equals('&') || character.Equals('^') || character.Equals('!') || character.Equals('$'))
				{
					if (!inPassword.Last().Equals(character))
					{
						return true;
					}
				}
			}
			return false;
        }

        private bool checkForLower()
        {
			foreach (char letter in inPassword)
			{
				if (Char.IsLower(letter))
				{
					return true;
				}
			}
			return false;
        }

        private bool checkForUpper()
        {
			foreach(char letter in inPassword)
			{
				if (Char.IsUpper(letter))
				{
					return true;
				}
			}
			return false;
        }
    }
}