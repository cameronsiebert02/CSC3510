﻿using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace InClassMovieAPI_3_23 {
    internal class DBConnectMysql {
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
            database = "csc3610";
            uid = "csc3610";
            password = "csc3610";
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
        public List<Movies> Select(string where) {
            List<Movies> result = new List<Movies>();
            string q = "SELECT id,name,sales,year FROM Movies " + where;
            if (this.OpenConnection()) {
                MySqlCommand cmd = new MySqlCommand(q, connection);
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read()) {
                    int id = dr.GetInt32(0);
                    string name = dr.GetString(1);
                    int sales = dr.GetInt32(2);
                    int year = dr.GetInt32(3);
                    result.Add(new Movies(id, name, sales, year));
                }
                this.connection.Close();
            }
            else {
                Console.WriteLine("Connect did not open");
            }
            return result;

        }
        public void Insert(Movies m) {
            string q = string.Format("INSERT INTO Movies (name, sales, year) VALUES('{0}','{1}','{2}')",
                                m.name, m.sales, m.year);
            if (this.OpenConnection()) {
                MySqlCommand cmd = new MySqlCommand(q, connection);
                MySqlDataReader dr = cmd.ExecuteReader();
                this.connection.Close();
            }
            else {
                Console.WriteLine("FL2: Connect did not open");
            }
        }
        public void Delete(int id ) {
            string q = string.Format("DELETE FROM Movies where id='{0}'",id);
            if (this.OpenConnection()) {
                MySqlCommand cmd = new MySqlCommand( q, connection);
                cmd.ExecuteNonQuery();
                this.connection.Close();
            } else {
                Console.WriteLine("Error in Delete open failed");
            }

        }
        public void Update( string item, int count, decimal cost, string where) {
            string q = string.Format("Update Movies set item='{0}', " +
                "count='{1}', cost='{2}' where {3}", item, count, cost, where );
            //Console.WriteLine("FLX2:{0}", q);
            //Console.ReadLine();
            if (this.OpenConnection()) {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = q;
                cmd.Connection = this.connection;
                cmd.ExecuteNonQuery();
                this.connection.Close();
            }
            else {
                Console.WriteLine("Error in Update Open failed");
            }

        }
    }
}
