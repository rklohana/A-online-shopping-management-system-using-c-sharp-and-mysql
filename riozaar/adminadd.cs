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
    public partial class adminadd : UserControl
    {
        public adminadd()
        {
            InitializeComponent();
        }

        private void signupbutt_Click(object sender, EventArgs e)
        {
            admin c = new admin();
            if (passtext.Text == conpasstext.Text)
            {
                c.setdata(nametext.Text, addresstext.Text, mobiletext.Text, emailtext.Text, passtext.Text);
                c.add();
                this.Hide();
                //MessageBox.Show("Account created");
            }
            else
            {
                MessageBox.Show("Passwords donot match");

            }
        }
    }
}
