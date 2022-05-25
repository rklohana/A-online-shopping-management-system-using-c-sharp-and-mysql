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
    public partial class adminlogin : UserControl
    {
        public adminlogin()
        {
            InitializeComponent();
        }

        private async void signin_Click(object sender, EventArgs e)
        {
            admin d = new admin();
            await d.retrievedata(emailid.Text);
            if (d.getpass() == passwordtext.Text)
            {
                //new form open
            }
            else
            {
                MessageBox.Show("Password is incorrect.");
            }
        }
    }
}
