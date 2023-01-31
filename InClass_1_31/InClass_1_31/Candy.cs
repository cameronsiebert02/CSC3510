using System;
namespace InClass_1_31
{
	public class Candy
	{
		public int id;
		public string item;
		public int count;
		public decimal cost;

        public Candy(int id, string item, int count, decimal cost)
        {
            this.id = id;
            this.item = item;
            this.count = count;
            this.cost = cost;
        }
    }
}

