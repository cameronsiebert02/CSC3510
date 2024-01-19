using System;
namespace InClassCoverageExamples
{
	public class MyClass
	{
		public string checkSumOddEven(int a, int b)
		{
			string ret = "Odd";
			int sum = a + b;
			if(sum %2 == 0)
			{
				ret = "Even";
			}
			return ret;
		}
		public bool isBig(int a)
		{
			const int BIG = 4;
			if(a > BIG)
			{
				a = a * 3;
				return true;
			}
			return false;
		}
		public bool isValid(int n1, int n2)
		{
			const int BIG = 5;
			if(n1 > 0 && n1+n2 > BIG)
			{
				return true;
			}
			return false;
		}
        public bool isValidMoreComplex(int n1, int n2)
        {
            const int BIG = 5;
            if ((n1 > 0 || n2 < BIG) && n1+n2 > BIG)
            {
                return true;
            }
            return false;
        }
    }
}