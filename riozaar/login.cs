using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace riozaar
{
    public partial class login : UserControl
    {
        public login()
        {
            InitializeComponent();
        }

        private async void signin_Click(object sender, EventArgs e)
        {
            customer c = new customer();
            bool f = false;
           f=await c.retrievedata(emailid.Text);
            while (f == false) { } 
          //  MessageBox.Show(c.getpass());
            if (c.getpass()==passwordtext.Text)
            {
                MessageBox.Show("login successful");
                //new form open
            }
            else
            {
                MessageBox.Show("Password is incorrect.");
            }
        }

        private void bunifuCustomLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
