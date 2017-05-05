using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Net;
using System.Net.Mail;

namespace Consultants
{
    public partial class Form1 : Form
    {
        
        mySqlClass mySQL = new mySqlClass();
        string ordNum;
        bool flag = true;
        string query = "Select * from consultants where ";
         
       

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mySQL.order = tbOrderNumber.Text;
            mySQL.last = tbLastName.Text;
            mySQL.first = tbFirstName.Text;
            mySQL.reg = tbRegion.Text;
            mySQL.projCoord = tbProjCoord.Text;
            mySQL.date = tbDate.Text;
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
                string SQLstring = "Select * from consultants ";
                MySqlCommand userCommand = new MySqlCommand(SQLstring, connection);

                MySqlDataReader userRecords = userCommand.ExecuteReader();
                while (userRecords.Read())
                {
                    int count = userRecords.FieldCount;
                    
                   for(var i = 0; i<count; i++)
                    {
                        ordNum = userRecords.GetString("Order_Number");
                        if(ordNum == tbOrderNumber.Text)
                        {
                            MessageBox.Show("this order number already exists, record not added");
                            flag = false;
                            break;
                        }
                       
                    } 
                   
                }

            }
            connection.Close();
            if (flag == true)
            {
                mySQL.startMySQLConnection();
                MessageBox.Show("Record has been added");
            }

            ClearAllText(this);
        }

        private void ClearAllText(Control con)
        {
            foreach (Control c in con.Controls)
            {
                if (c is TextBox)
                    ((TextBox)c).Clear();
                else
                    ClearAllText(c);
            }
        }
        private void queryContructor()
        {
            int counter = 0;
            if(tbDate.Text != "")
            {
                if (tbEndDate.Text != "")
                {
                    query += (" date between " + tbDate.Text + " and " + tbEndDate.Text);
                }
                else
                {
                    query += ("date = '" + tbDate.Text + "'");
                    counter++;
                }
            }
            if(tbFirstName.Text != "")
            {
                if(counter > 0)
                {
                    query += ( " and First_Name = '" + tbFirstName.Text+"'");
                }
                else
                {
                    query += ("First_Name = '" + tbFirstName.Text+"'");
                    counter++;
                }
            }
            if (tbLastName.Text != "")
            {
                if (counter > 0)
                {
                    query += (" and Last_Name = '" + tbLastName.Text+"'");
                }
                else
                {
                    query += ("Last_Name = '" + tbLastName.Text+"'");
                    counter++;
                }
            }
            if (tbOrderNumber.Text != "")
            {
                if (counter > 0)
                {
                    query += (" and Order_Number = '" + tbOrderNumber.Text+"'");
                }
                else
                {
                    query += ("Order_Number = '" + tbOrderNumber.Text+"'");
                    counter++;
                }
            }
            if (tbProjCoord.Text != "")
            {
                if (counter > 0)
                {
                    query += (" and Project_Coordinator = '" + tbProjCoord.Text + "'");
                }
                else
                {
                    query += ("Project_Coordinator = '" + tbProjCoord.Text + "'");
                    counter++;
                }
            }
            if (tbRegion.Text != "")
            {
                if (counter > 0)
                {
                    query += (" and Region = '" + tbRegion.Text + "'");
                }
                else
                {
                    query += ("Region = '" + tbRegion.Text + "'");
                    counter++;
                }
            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            queryContructor();
           lblResults.Text= mySQL.ExecuteQuery(lblResults.Text, query);
            ClearAllText(this);
            clearQuery();

        }
        public void clearQuery()
        {
            query = "Select * from consultants where ";
        }
        
        public delegate void sendResults(Label results);
        public void btnEmail_Click(object sender, EventArgs e)
        {
            //string receiver = tbEmailAddress.Text;
            //Email email = new Email();
            //email.sendEmail(lblResults.Text, receiver );
            //MessageBox.Show("Email has been sent to " + receiver);
            EmailForm x = new EmailForm();
            sendResults send = new sendResults(x.setBody);
            send(this.lblResults);
            x.Show();
            


        }
    }
}
