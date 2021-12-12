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
    public partial class DMLOGIN : UserControl
    {
        public DMLOGIN()
        {
            InitializeComponent();
        }

        private void signin_Click(object sender, EventArgs e)
        {
            DeliveryMan d = new DeliveryMan();
            d.retrievedata(emailid.Text);
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
