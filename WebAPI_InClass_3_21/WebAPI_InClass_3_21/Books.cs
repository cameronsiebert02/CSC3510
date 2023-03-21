using System;
namespace WebAPI_InClass_3_21
{
	public class Rootobject
	{
		public string library { get; set; }
		public string description { get; set; }
		public Book[] books { get; set; }
	}
	public class Book
	{
		public int id { get; set; }
		public string title { get; set; }
		public string author { get; set; }
		public int year_written { get; set; }
		public string edition { get; set; }
		public float price { get; set; }
	}
}

