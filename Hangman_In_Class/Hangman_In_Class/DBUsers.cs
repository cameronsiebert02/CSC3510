using System;
using MySqlConnector;

namespace Hangman_In_Class
{
	public class DBUsers : DBConnectMysql
	{
        //----
        public List<Users> Select(string where)
        {
            List<Users> result = new List<Users>();
            string q = "SELECT id,userName,win,loss FROM Hangman_User " + where;
            if (this.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(q, connection);
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    int id = dr.GetInt32(0);
                    string name = dr.GetString(1);
                    int win = dr.GetInt32(2);
                    int loss = dr.GetInt32(3);
                    result.Add(new Users(id, name, win, loss));
                }
                this.connection.Close();
            }
            else
            {
                Console.WriteLine("Connect did not open");
            }
            return result;

        }
        public void Insert(Users u)
        {
            string q = string.Format("INSERT INTO Hangman_User (userName, win, loss) VALUES('{0}','{1}','{2}')",
                                u.userName, u.win, u.loss);
            if (this.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(q, connection);
                MySqlDataReader dr = cmd.ExecuteReader();
                this.connection.Close();
            }
            else
            {
                Console.WriteLine("FL2: Connect did not open");
            }
        }
        public int SelectSingleRow(string q)
        {
            int ret = 0;
            if (this.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(q, connection);
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    int id = dr.GetInt32(0);
                    return id;
                }
                
            }
            return ret;
        }
        //public void Delete(int id)
        //{
        //    string q = string.Format("DELETE FROM Hangman_User where id='{0}'", id);
        //    if (this.OpenConnection())
        //    {
        //        MySqlCommand cmd = new MySqlCommand(q, connection);
        //        cmd.ExecuteNonQuery();
        //        this.connection.Close();
        //    }
        //    else
        //    {
        //        Console.WriteLine("Error in Delete open failed");
        //    }

        //}
        //public void Update(string item, int count, decimal cost, string where)
        //{
        //    string q = string.Format("Update Users set item='{0}', " +
        //        "count='{1}', cost='{2}' where {3}", item, count, cost, where);
        //    //Console.WriteLine("FLX2:{0}", q);
        //    //Console.ReadLine();
        //    if (this.OpenConnection())
        //    {
        //        MySqlCommand cmd = new MySqlCommand();
        //        cmd.CommandText = q;
        //        cmd.Connection = this.connection;
        //        cmd.ExecuteNonQuery();
        //        this.connection.Close();
        //    }
        //    else
        //    {
        //        Console.WriteLine("Error in Update Open failed");
        //    }

        //}
        //----
    }
}

