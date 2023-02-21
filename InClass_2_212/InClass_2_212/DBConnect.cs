using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DependInjection;

namespace DependInjectionl{
    public class DBConnect{
        public MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        //Constructor
        public DBConnect()
        {
            Initialize();
        }

        //Initialize values
        private void Initialize()
        {
            server = "45.55.136.114";
            database = "csc3610";
            uid = "csc3610";
            password = "csc3610";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
                               database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
            Console.WriteLine("Gotconnnection");

        }

        public bool OpenConnection()
        {
            Console.WriteLine("Trying ....");
            try
            {
                Console.WriteLine("openning");
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        Console.WriteLine("Invalid username/password, please try again");
                        break;
                }

                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }


        public List<HiPerMonth> SelectWeatherRecords()
        {
            string query = "SELECT Year,Jan,Feb,Mar,Apr,May, Jun, Jul, Aug, Sep, Oct, Nov, `Dec` FROM ChicagoHiPerMonth";

            //Create a list to store the result
            List<HiPerMonth> list = new List<HiPerMonth>();

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();
                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    int yr = dataReader.GetInt32(0);
                    int jan = dataReader.GetInt32(1);
                    int feb = dataReader.GetInt32(2);
                    int mar = dataReader.GetInt32(3);
                    int apr = dataReader.GetInt32(4);
                    int may = dataReader.GetInt32(5);
                    int jun = dataReader.GetInt32(6);
                    int jul = dataReader.GetInt32(7);
                    int aug = dataReader.GetInt32(8);
                    int sep = dataReader.GetInt32(9);
                    int oct = dataReader.GetInt32(10);
                    int nov = dataReader.GetInt32(11);
                    int dec = dataReader.GetInt32(12);

                    HiPerMonth hpm = new HiPerMonth(yr, jan, feb, mar, apr, may, jun, jul, aug,
                        sep, oct, nov, dec);
                    list.Add(hpm);

                }


                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return list;
            }
            else
            {
                return list;
            }
        }
    }
}