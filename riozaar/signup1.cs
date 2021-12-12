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
    public partial class signup1 : UserControl
    {
        public signup1()
        {
           
            InitializeComponent();
            mid.Text = null;
        }

        private async void signin_Click(object sender, EventArgs e)
        {
            DeliveryMan d = new DeliveryMan();
            DeliveryMan d1 = new DeliveryMan();
            
            if (passtext.Text == conpasstext.Text)
            {
                d.setdata(emailtext.Text,nametext.Text, mobiletext.Text,mid.Text, passtext.Text);
               
                    d.add();
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
