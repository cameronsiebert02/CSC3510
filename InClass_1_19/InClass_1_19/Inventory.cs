using System;
namespace InClass_1_19
{
	public class Inventory
	{
		public string item;
		public int count;
		public decimal price;
		public Inventory(string item, int count, decimal price)
		{
			this.item = item;
			this.count = count;
			this.price = price;
		}
		
	}
}

