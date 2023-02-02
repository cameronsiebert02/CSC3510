using System;
namespace InClass_2_2_Salart
{
	public class SalaryCalculator
	{
		public int weeks { get; set; }
		public SalaryCalculator(int weeks)
		{
			if(weeks > 52)
			{
				throw new ArgumentException("Illegal Weeks");
			}
			this.weeks = weeks;
		}
		public decimal GetAnnualSalary(decimal rate)
		{
			if(rate < 0)
			{
				rate = 0;
			}
			if(weeks < 0)
			{
				weeks = 0;
			}
			decimal annual = rate * weeks;
			return annual;
		}
	}
}

