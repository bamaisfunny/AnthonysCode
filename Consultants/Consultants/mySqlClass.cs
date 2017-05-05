using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
namespace Consultants
{
    class mySqlClass
    {
        public string order;
        public string last;
        public string first;
        public string reg;
        public string date;
        public string projCoord;

        public string addOrder(string orderNumb, string lastName, string firstName, string region, string dated, string projCoor)
        {
            string x;
            x = ("Insert into consultants values('" + orderNumb + "','" + lastName + "','" + firstName + "','" + region + "','" + date + "','" + projCoor + "');");
            return x;
        }

        public void startMySQLConnection()
        {
            string connString = ("Server=localhost;user=root;database=anthony");
            MySqlConnection connection = new MySqlConnection(connString);
            connection.Open();
            string dbStatus = Convert.ToString(connection.State);
            if (dbStatus != "Open")
         
            {
                MessageBox.Show("The database instance is not available");
            }
            string SQLstring = addOrder(order, last, first, reg, date, projCoord);
            MySqlCommand userCommand = new MySqlCommand(SQLstring, connection);

            MySqlDataReader userRecords = userCommand.ExecuteReader();

              connection.Close();

        }

      public string ExecuteQuery(string labelText, string query)
        {
            labelText = ("Results are: \r\n");
            string connString = ("Server=localhost;user=root;database=anthony");
            MySqlConnection connection = new MySqlConnection(connString);
            connection.Open();
            string dbStatus = Convert.ToString(connection.State);
            if (dbStatus != "Open")

            {
                MessageBox.Show("The database instance is not available");
            }
            else
            {
                MySqlCommand userCommand = new MySqlCommand(query, connection);

                MySqlDataReader userRecords = userCommand.ExecuteReader();
                while (userRecords.Read())
                {
                    int count = userRecords.FieldCount;
                    for (var i = 0; i < count; i++)
                    {
                        labelText += (userRecords[i] + "   ").ToString();
                    }
                    labelText += "\r\n";
                }
            
            }
            return labelText;
        }
    }

        

    }

