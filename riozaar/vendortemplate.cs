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
    public partial class vendortemplate : UserControl
    {
        bool st1;
        public vendortemplate(bool st)
        {
            st1 = st;
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

        private int stock;
        public int Stock
        {
            get
            {
                return stock;
            }
            set
            {
                
                if (!st1)
                {
                    stock = value;
                    guna2NumericUpDown1.Value = value;
            }
                else
                {
                    stock = 0;
                }
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










        private void vendortemplate_Load(object sender, EventArgs e)
        {

        }

        private async void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            if (st1)
            {
                if (pricebox.TextLength > 0)
                {
                    databseconnection dc = new databseconnection();
                    dc.openconnect();
                    MySqlCommand comm = dc.conn.CreateCommand();
                    comm.CommandText = "Insert into sold_by values(@vid,@pid,@s,@p);";
                    comm.Parameters.AddWithValue("@vid", vendor);
                    comm.Parameters.AddWithValue("@pid", pid);
                    comm.Parameters.AddWithValue("@s", guna2NumericUpDown1.Value);
                    comm.Parameters.AddWithValue("@p", float.Parse(pricebox.Text));
                    try
                    {
                        await comm.ExecuteNonQueryAsync();
                    }
                    catch (Exception e1)
                    {
                        MessageBox.Show(e1.ToString());
                    }
                    dc.closeconnect()
    ;
                }
                else
                {
                    MessageBox.Show("please insert price");


                }
            }
            else
            {
                if (pricebox.TextLength > 0)
                {
                    databseconnection dc = new databseconnection();
                   await dc.conn.OpenAsync();
                    MySqlCommand comm = dc.conn.CreateCommand();
                    comm.CommandText = "update sold_by set price=@p,stock=@s where VENDOR_VendorID=@vid and PRODUCT_productID=@pid ;";
                    comm.Parameters.AddWithValue("@vid", vendor);
                    comm.Parameters.AddWithValue("@pid", pid);
                    comm.Parameters.AddWithValue("@s", guna2NumericUpDown1.Value);
                    comm.Parameters.AddWithValue("@p", float.Parse(pricebox.Text));
                    try
                    {
                     int row=   await comm.ExecuteNonQueryAsync();
                        MessageBox.Show(vendor);
                        MessageBox.Show(pid);
                    }
                    catch (Exception e1)
                    {
                        MessageBox.Show(e1.ToString());
                    }
                 await   dc.conn.CloseAsync();
                }
                else
                {
                    MessageBox.Show("please insert price");


                }
            }
        }
    }
}
