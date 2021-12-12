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
    public partial class vendorlogin : UserControl
    {
        public vendorlogin()
        {
            InitializeComponent();
        }

        private void signin_Click(object sender, EventArgs e)
        {
            vendor v = new vendor();
            v.retrievedata(emailid.Text);
            if (v.getpass() == passwordtext.Text)
            {
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
