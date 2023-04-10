using System;
using MySqlConnector;
namespace Hangman_In_Class
{
	public class DBGames : DBConnectMysql
	{
        public List<Hangman_game> Select(string where)
        {
            List<Hangman_game> result = new List<Hangman_game>();
            string q = "SELECT id, userid, miss, secret_word, show_word, game_state,";
            q += " guess_letters FROM Hangman_game " + where;
            if (this.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(q, connection);
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    int id = dr.GetInt32(0);
                    int userId = dr.GetInt32(1);
                    int miss = dr.GetInt32(2);
                    //int loss = dr.GetInt32(3);
                    string secret_word = dr.GetString(3);
                    string show_word = dr.GetString(4);
                    string game_state = dr.GetString(5);
                    string guess_letters = dr.GetString(6);
                    //result.Add(new HangmanGame( userId ));
                    Hangman_game hg = new Hangman_game(id, userId, miss, secret_word, show_word, game_state, guess_letters);
                    result.Add(hg);
                }
                this.connection.Close();
            }
            else
            {
                Console.WriteLine("Connect did not open");
            }
            return result;

        }
        public void InsertGame(Hangman_game hg)
        {
            string q = string.Format("INSERT INTO Hangman_game ( userId, miss, secret_word, show_word, game_state, guess_letters )   VALUES('{0}', '{1}', '{2}','{3}','{4}','{5}')",
                              hg.userId, hg.miss, hg.secret_word, hg.show_word, hg.game_state, hg.guess_letters);
            System.Diagnostics.Debug.WriteLine("Insert QQQQQ=" + q);
            if (this.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(q, connection);
                MySqlDataReader dr = cmd.ExecuteReader();

            }
            else
            {
                Console.WriteLine("FL2: Connect did not open");
            }
            this.CloseConnection();
        }
        public int SlectSingleRowRetInt(string q)
        {
            int ret = 0;
            if (this.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(q, connection);
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    int ct = dr.GetInt32(0);
                    return ct;
                }
            }
            this.CloseConnection();
            return ret;

        }
        public String SlectSingleString(string q)
        {
            string ret = "";
            if (this.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(q, connection);
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ret = dr.GetString(0);
                    this.CloseConnection();
                    return ret;
                }
            }
            this.CloseConnection();
            return ret;

        }
        public Hangman_game SelectHangManGame(string wh)
        {
            string q = "Select userId,miss,secret_word,show_word,game_state, guess_letters";
            q += String.Format(" from Hangman_game  {0}", wh);
            System.Diagnostics.Debug.WriteLine("Guess QQQQQ=" + q);
            string ret = "";
            Hangman_game hg = new Hangman_game();
            if (this.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(q, connection);
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    hg.userId = dr.GetInt32(0);
                    hg.miss = dr.GetInt32(1);
                    hg.secret_word = dr.GetString(2);
                    hg.show_word = dr.GetString(3);
                    hg.game_state = dr.GetString(4);
                    hg.guess_letters = dr.GetString(5);
                    this.CloseConnection();
                    return hg;
                }
            }
            this.CloseConnection();
            return hg;

        }
        public String getRandomWord()
        {
            string ret = "";
            if (this.OpenConnection())
            {
                string q = "select word from Hangman_words order by RAND() limit 1";
                MySqlCommand cmd = new MySqlCommand(q, connection);
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ret = dr.GetString(0);
                    this.CloseConnection();
                    return ret;
                }
            }
            else
            {
                Console.Write("\n Cannot open!");
            }
            this.CloseConnection();
            return ret;
        }
        //public void Delete(int id) {
        //    string q = string.Format("DELETE FROM Movies where id='{0}'", id);
        //    if (this.OpenConnection()) {
        //        MySqlCommand cmd = new MySqlCommand(q, connection);
        //        cmd.ExecuteNonQuery();
        //        this.connection.Close();
        //    }
        //    else {
        //        Console.WriteLine("Error in Delete open failed");
        //    }

        //}
        public void Update(Hangman_game hg, string where)
        {
            string q = string.Format("update Hangman_game set ");
            q += String.Format("miss='{0}'", hg.miss);
            q += String.Format(", show_word='{0}'", hg.show_word);
            q += String.Format(", game_state='{0}'", hg.game_state);
            q += String.Format(", gusess_letters='{0}'", hg.guess_letters);
            q += String.Format(" where {0}", where);
            System.Diagnostics.Debug.WriteLine("Update QQQQQ=" + q);
            if (this.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = q;
                cmd.Connection = this.connection;
                cmd.ExecuteNonQuery();
                this.connection.Close();
            }
            else
            {
                Console.WriteLine("Error in Update Open failed");
            }

        }
    }
}