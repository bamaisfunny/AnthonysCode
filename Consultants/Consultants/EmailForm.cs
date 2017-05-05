using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Consultants
{
    public partial class EmailForm : Form
    {
        password p;
        Form1 x = new Form1();
        public string bodyText;
        string password;
        public EmailForm()
        {
            InitializeComponent();

           
            
            
        }
        
        public void setBody(Label results)
        {
            tbBody.Text = results.Text;
        }

        public delegate void setLabel(string text);
        private void button1_Click(object sender, EventArgs e)
        {
            p = new password();
            setLabel label = new setLabel(p.setLabel);
            label("Enter a password for " + tbFrom.Text);
            p.Show();
            p.passwordSubmitted += P_passwordSubmitted;
        }

        private void P_passwordSubmitted(object sender, EventArgs e)
        {
            password = p.passwordText;
            Email email = new Email();
            email.sendEmail(tbBody.Text, tbTo.Text, tbFrom.Text, password);
            MessageBox.Show("Email has been sent to " + tbTo.Text );
            this.Close();
        }
    }
}
