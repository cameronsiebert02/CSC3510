using MySqlConnector;
using System;
namespace InClass_1_31
{
	public class DBConnectMySql
	{
		public MySqlConnection connection;
		private string server;
		private string database;
		private string username;
		private string password;
		public DBConnectMySql()
		{
			Initialize();
		}

        private void Initialize()
        {
			server = "45.55.136.114";
			database = "csc3610";
			username = "csc3610";
			password = "csc3610";
			//string conString = "SERVER=" + server + "; DATABASE=" + ;
			string conString = String.Format("SERVER={0}; DATABASE={1}; UID={2}; PASSWORD={3};", server, database, username, password);
			connection = new MySqlConnection(conString);
        }
		public bool OpenConnection()
		{
			Boolean yuh = false;
			try
			{
				connection.Open();
				yuh = true;
			}catch(MySqlException ex)
			{
				switch (ex.Number)
				{
					case 0:
						Console.WriteLine("Cannot connect to server");
						break;
					case 1045:
						Console.WriteLine("Invalid username/password");
						break;
					default:
						Console.WriteLine("It broke");
						break;
				}
				
			}
			return yuh;
		}
		public List<Candy> Select()
		{
			List<Candy> result = new List<Candy>();
			string q = "SELECT id,item,count,cost FROM candy";
			if (this.OpenConnection())
			{
				MySqlCommand cmd = new MySqlCommand(q, connection);
				MySqlDataReader dr = cmd.ExecuteReader();
				while (dr.Read())
				{
					int id = dr.GetInt32(0);
					string item = dr.GetString(1);
					int count = dr.GetInt32(2);
					decimal cost = dr.GetDecimal(3);
					result.Add(new Candy(id, item, count, cost));
				}
				this.connection.Close();
			}
			else
			{
				Console.WriteLine("Connection did not open");
			}
			return result;
		}
		public void Insert(string item, int count, decimal cost)
		{
			string q = string.Format("INSERT INTO candy (item,count,cost) VALUES('{0}','{1}','{2}')", item, count, cost);
			if (this.OpenConnection())
			{
                MySqlCommand cmd = new MySqlCommand(q, connection);
                MySqlDataReader dr = cmd.ExecuteReader();
				this.connection.Close();
			}
			else
			{
				Console.WriteLine("Insert: Connection did not open");
			}
        }
    }
}