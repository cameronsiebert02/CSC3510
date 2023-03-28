using System;
namespace Hangman_In_Class
{
	public class Users
	{
		public int id { get; set; }
		public string userName { get; set; }
		public int win { get; set; }
		public int loss { get; set; }
		public int error { get; set; }
		public string Msg { get; set; }

        public Users(int id, string userName, int win, int loss)
        {
            this.id = id;
            this.userName = userName;
            this.win = win;
            this.loss = loss;
            this.error = 0;
            this.Msg = "";
        }
    }
}

