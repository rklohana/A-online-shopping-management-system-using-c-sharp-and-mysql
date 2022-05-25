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
    public partial class customerform : UserControl
    {
        customer v;
        public customerform()
        {
            InitializeComponent();
        }

        private void prodpan_Paint(object sender, PaintEventArgs e)
        {

        }
        private async void customerform_Load(object sender, EventArgs e)
        {
            //databseconnection dc = new databseconnection();
            //await dc.conn.OpenAsync();

            //MySqlCommand com = dc.conn.CreateCommand();
            //com.CommandText = "Select count(*) from SOLD_BY where stock>0;";
            //try
            //{
            //    await com.ExecuteNonQueryAsync();
            //    try
            //    {
            //        MySqlDataReader reader = com.ExecuteReader();
            //        while (reader.Read())
            //        {
            //            n = reader.GetInt32(0);
            //        }

            //    }
            //    catch (Exception e1)
            //    {
            //        MessageBox.Show("error");
            //    }
            //}
            //catch (Exception e1)
            //{
            //    MessageBox.Show(e1.ToString());
            //}
            //MessageBox.Show(n.ToString());
            //await dc.conn.CloseAsync();
        }
        int n;
        async void populateprod()
        {
            databseconnection dc = new databseconnection();
            await dc.conn.OpenAsync();

            MySqlCommand com = dc.conn.CreateCommand();
            com.CommandText = "Select count(*) from SOLD_BY where stock>0;";
            
            try
            {
                await com.ExecuteNonQueryAsync();
                try
                {
                    MySqlDataReader reader = com.ExecuteReader();
                    while (reader.Read())
                    {
                        n = reader.GetInt32(0);
                    }

                }
                catch (Exception e)
                {
                    MessageBox.Show("error");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("1  \n" + e.ToString());
            }
            await dc.conn.CloseAsync();

            //MessageBox.Show(n.ToString());

            productbuy[] p = new productbuy[n];
            await dc.conn.OpenAsync();
            product[] p1 = new product[n];
            MySqlCommand com1 = dc.conn.CreateCommand();
            com1.CommandText = "select v.vfname,s.stock,p.productid,p.pname,p.image,p.description,s.price from VENDOR v,PRODUCT p,SOLD_BY s where s.PRODUCT_PRODUCTID=p.PRODUCTID and s.stock>0 and s.VENDOR_VENDORID=v.VENDORID;";
            //try
            {
                int i = 0;
                await com1.ExecuteNonQueryAsync();
                MySqlDataReader reader1 = com1.ExecuteReader();
                while (reader1.Read())
                {
                    p1[i] = new product();
                    p1[i].setdata(reader1.GetString(2), reader1.GetString(3), reader1.GetString(4), reader1.GetString(5), reader1.GetFloat(6), reader1.GetInt32(1));
                    p[i] = new productbuy();
                    p[i].PID = p1[i].getpid();
                    p[i].Price = p1[i].getprice().ToString();
                    p[i].Nametext = p1[i].getname();
                    p[i].Vendor = reader1.GetString(0);
                    p[i].Description = p1[i].getdescription();
                    p[i].Icon = p1[i].photoback(p1[i].getimage());
                    if (prodpan.Controls.Count < 0)
                    {
                        prodpan.Controls.Clear();
                    }
                    else
                    {
                        bunifuTransition1.ShowSync(p[i]);
                        prodpan.Controls.Add(p[i]);
                    }
                    i++;
                }
            }
            //  catch(Exception e)
            {
                //MessageBox.Show(e.ToString());
            }
        }
       
        private void bunifuGradientPanel1_Click(object sender, EventArgs e)
        {

        }

        private void prodbutt_Click_1(object sender, EventArgs e)
        {
            populateprod();
        }
    }
}
