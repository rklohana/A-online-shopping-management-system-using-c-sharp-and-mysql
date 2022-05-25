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
    public partial class vendorsu : UserControl
    {
        public vendorsu()
        {   

          //  bunifuDropdown1.Items.Add();
            InitializeComponent();
           
        }

        private void bunifuDropdown1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void signin_Click(object sender, EventArgs e)
        {
            /*
            vendor v = new vendor();
            if (passtext.Text == conpasstext.Text)
            {
              //  v.setdata(nametext.Text, mobiletext.Text, passtext.Text);
                v.add();
                this.Hide();
                //MessageBox.Show("Account created");
            }
            else
            {
                MessageBox.Show("Passwords donot match");

            }*/
            MessageBox.Show(bunifuDropdown1.SelectedIndex.ToString());
        }

        private void vendorsu_Load(object sender, EventArgs e)
        {
            //fillToolStrip.Hide();
            //fillToolStripButton_Click(sender, e);

            try
            {
                this.bazaarTableAdapter.Fill(this.riozaarDataSet2.bazaar);
               // this.locationTableAdapter1.Fill(this.riozaarDataSet1.location);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }
        private void getbaazars()
        {

        }

        private void fillToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.locationTableAdapter1.Fill(this.riozaarDataSet1.location);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }
    }
}
