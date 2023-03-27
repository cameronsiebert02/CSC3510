using System;
namespace InClassMovieAPI_3_23
{
	public class Movies
	{
		public int id { get; set; }
		public string name { get; set; }
		public int sales { get; set; }
		public int year { get; set; }

        public Movies(int id, string name, int sales, int year)
        {
            this.id = id;
            this.name = name;
            this.sales = sales;
            this.year = year;
        }
    }
}

