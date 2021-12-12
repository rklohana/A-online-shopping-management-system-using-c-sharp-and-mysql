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
    public partial class signup : UserControl
    {
        public signup()
        {
            InitializeComponent();
        }

        private void bunifuCustomLabel5_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel6_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel3_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel4_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel1_Click(object sender, EventArgs e)
        {

        }

        private void conpasstext_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void passtext_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void signupbutt_Click(object sender, EventArgs e)
        {

        }

        private void emailtext_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void addresstext_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void mobiletext_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void nametext_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void signupbutt_Click_1(object sender, EventArgs e)
        {
            customer c = new customer();
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
