
using MySqlConnector;
//using Mysqlx.Crud;
using System.Security.Cryptography.X509Certificates;

namespace Hangman_In_Class {
    public class DBUsers2 : DBConnectMysql {
        // ----
        public List<Users> Select(string where) {
            List<Users> result = new List<Users>();
            //	userName	win	loss 	
            string q = "SELECT id,userName,win,loss FROM Hangman_User " + where;
            if (this.OpenConnection()) {
                MySqlCommand cmd = new MySqlCommand(q, connection);
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read()) {
                    int id = dr.GetInt32(0);
                    string userName = dr.GetString(1);
                    int win = dr.GetInt32(2);
                    int loss = dr.GetInt32(3);
                    result.Add(new Users(id, userName, win, loss));
                    System.Diagnostics.Debug.WriteLine("--- FG1 --- Got one");
                }
            }
            else {
                System.Diagnostics.Debug.WriteLine("-- FLx Connect did not open");
            }
            this.CloseConnection();
            return result;
            
        }
        public void Insert(Users u) {
            string q = string.Format("INSERT INTO Hangman_User (userName, win, loss) VALUES('{0}','{1}','{2}')",
                              u.userName, u.win, u.loss);
            System.Diagnostics.Debug.WriteLine("Insert QQQQQ=" + q);
            if (this.OpenConnection()) {
               MySqlCommand cmd = new MySqlCommand(q, connection);
                MySqlDataReader dr = cmd.ExecuteReader();
               
            }  else {
                Console.WriteLine("FL2: Connect did not open");
            }
            this.CloseConnection();
        }
       public int SlectSingleRowRetInt( string q ) {
            int ret = 0;
            if (this.OpenConnection()) {
                MySqlCommand cmd = new MySqlCommand(q, connection);
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read()) {
                    int ct= dr.GetInt32(0);
                    return ct;
                }
            }
            this.CloseConnection();
            return ret;

       }
        //public void Delete(int id) {
        //    string q = string.Format("DELETE FROM Hangman_game where id='{0}'", id);
        //    if (this.OpenConnection()) {
        //        MySqlCommand cmd = new MySqlCommand(q, connection);
        //        cmd.ExecuteNonQuery();
        //        this.connection.Close();
        //    }
        //    else {
        //        System.Diagnostics.Debug.WriteLine("Error in Delete open failed q=" +q);
        //        this.connection.Close();
        //    }

        //}
        public void update(string userName, int win, int loss , string where) {
            string q = string.Format("update Hangman_User set userName='{0}', " +
                "win='{1}', loss='{2}'  {3}", userName, win, loss, where);
            System.Diagnostics.Debug.WriteLine("FLX UPDATE  QQQQQ=" + q);
            //console.writeline("flx2:{0}", q);
            //console.readline();
            if (this.OpenConnection()) {
                MySqlCommand cmd = new MySqlCommand(q, connection);
                MySqlDataReader dr = cmd.ExecuteReader();
                this.CloseConnection();
            } else {
                System.Diagnostics.Debug.WriteLine("FL1 Open Failure QQQQQ=" + q);
            }
        }
        // --- 
    }
}
