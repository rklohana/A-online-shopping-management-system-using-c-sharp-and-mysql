using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;
namespace riozaar
{
    public partial class productbuy : UserControl
    {
        public productbuy()
        {
            InitializeComponent();
        }

        #region properties
        private string nametext;
        [Category("Customs props")]
        public string Nametext
        {
            get
            {
                return nametext;
            }
            set
            {
                nametext = value;
                name.Text = value;
            }
        }
        


        private string vendor;
        [Category("Customs props")]
        public string Vendor
        {
            get { return vendor; }
            set
            {
                vendor = value;
                sellertext.Text = value;
            }
        }

        private string pid;
        [Category("Customs props")]
        public string PID
        {
            get { return pid; }
            set
            {
                pid = value;
                
            }
        }


        private string description;
        [Category("Customs props")]
        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                desc.Text = value;
            }
        }

        private string price;
        [Category("Customs props")]
        public string Price
        {
            get { return price; }
            set
            {
                price = value;
                pricetext.Text = value;
            }
        }
      



        private string stock1;
        [Category("Customs props")]
        public string Stock1
        {
            get { return stock1; }
            set
            {
                stock1 = value;
                Stocktext.Text = value;
            }
        }


        private Image icon;
        [Category("Customs props")]
        public Image Icon
        {
            get { return icon; }
            set
            {
                icon = value;
                pictureBox1.Image = value;
            }
        }


        #endregion


       








        private void qnt_ValueChanged(object sender, EventArgs e)
        {

        }

        private void productbuy_Load(object sender, EventArgs e)
        {
            qnt.Maximum = Int32.Parse(Stock1);
        }

        private void qnt_KeyDown(object sender, KeyEventArgs e)
        {
            if (qnt.Value > 1)
            {
                qnt.Value--;
            }
            }

        private void qnt_KeyUp(object sender, KeyEventArgs e)
        {
            
                qnt.Value++;
            
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
