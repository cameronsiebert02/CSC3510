using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Hangman_In_Class {
    public class DBConnectMysql {
        public MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        public DBConnectMysql() {
            Initialize();
        }

        private void Initialize() {
            server = "45.55.136.114";
            //database = "csc3610";
            //uid = "csc3610";
            //password = "csc3610";
            database = "S2023_CSiebert";
            uid = "S2023_CSiebert";
            password = "AHardDaysNight";
            //string conString = "SERVER=" + server + "; DATABASE=" +
            string conString = String.Format("SERVER={0}; DATABASE={1}; UID={2}; PASSWORD={3};",
                server, database, uid, password);
            connection = new MySqlConnection(conString);
            Console.WriteLine("It must have connected");
        }
        public bool OpenConnection() {
            bool result = false;
            try {
                connection.Open();
                result = true;
            }
            catch (MySqlException ex) {
                switch (ex.Number) {
                    case 0:
                        Console.WriteLine("Cannot connect to server");
                        break;
                    case 1045:
                        Console.WriteLine("Invalid user/passwd");
                        break;
                    default:
                        Console.WriteLine("It broke");
                        break;
                }
            }
            return result;
        }
        public void CloseConnection()
        {
            connection.Close();
        }
    }
}