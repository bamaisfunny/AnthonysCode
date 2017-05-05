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
    public partial class password : Form
    {
        public string passwordText;
        public password()
        {
            InitializeComponent();
            
        }
        public void setLabel(string label)
        {
            lblPassword.Text = label;
        }

        public event EventHandler passwordSubmitted;

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            passwordText = tbPassword.Text;
            if (passwordSubmitted != null)
            {
                passwordSubmitted(this, e);
            }
            this.Close();
        }
    }
}
