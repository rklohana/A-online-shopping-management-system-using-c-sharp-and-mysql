using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;
namespace riozaar
{
    public partial class vendorhomepage : UserControl
    {
        int n;
        int totalitems;
        int zeroitems;
        vendor v1;
        public vendorhomepage()
        {
            //v1 = v;
            InitializeComponent();
            makeattributes();
        }
       async void makeattributes()
        {
           await gettotalproducts();
           await getzeroproducts();

            await setmore();
            await setship();
            await setpending();
            //MessageBox.Show(totalitems.ToString());
            // Thread.Sleep(100);
            // Console.WriteLine(n);
          //  MessageBox.Show(zeroitems.ToString());
           bunifuCircleProgress1.Maximum = totalitems;
          //  bunifuRadialGauge1.Minimum = 0;
          //  //Console.WriteLine(n);
          //  // MessageBox.Show(totalitems.ToString());
            bunifuRadialGauge1.Maximum = n;

            bunifuCircleProgress1.Value = totalitems - zeroitems;
            MessageBox.Show(zeroitems.ToString());
            bunifuRadialGauge1.Value = zeroitems;
            
            totaltext.Text = totalitems.ToString();

        }

        private void vendorhomepage_Load(object sender, EventArgs e)
        {

            //  bunifuRadialGauge1.Value = n;


            

        }
        async Task getzeroproducts()
        {
            databseconnection dc = new databseconnection();
            await dc.conn.OpenAsync();
         
            MySqlCommand com = dc.conn.CreateCommand();
            com.CommandText = "Select count(*) from SOLD_BY where VENDOR_VENDORID =@id and stock=0;";
            com.Parameters.AddWithValue("@id", "456");
            try
            {
                await com.ExecuteNonQueryAsync();
                try
                {
                    MySqlDataReader reader = com.ExecuteReader();
                    while (reader.Read())
                    {
                        bunifuRadialGauge1.Value = reader.GetInt32(0);
                        zeroitems = reader.GetInt32(0);

                        bunifuCircleProgress1.Value = Int32.Parse(totaltext.Text) - zeroitems;                      // MessageBox.Show(zeroitems.ToString());
                    }

                }
                catch (Exception e1)
                {
                    zeroitems = 0;
                    MessageBox.Show(e1.ToString());
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show("1  \n" + e1.ToString());
            }
            await dc.conn.CloseAsync();
            bunifuRadialGauge1.Value = zeroitems;
            bunifuCircleProgress1.Value = totalitems - zeroitems;
        }
       async Task gettotalproducts()
        {
            
            databseconnection dc = new databseconnection();
           await dc.conn.OpenAsync();
            MySqlCommand com = dc.conn.CreateCommand();
            com.CommandText = "Select count(*) from SOLD_BY where VENDOR_VENDORID =@id;";
            com.Parameters.AddWithValue("@id", "456");
            try
            {
                await com.ExecuteNonQueryAsync();
                try
                {
                    MySqlDataReader reader = com.ExecuteReader();
                    reader.Read();
                        n= reader.GetInt32(0);
                    // MessageBox.Show(reader.GetInt32(0).ToString());
                    totaltext.Text = reader.GetInt32(0).ToString();
                    totalitems = n;


                }
                catch (Exception e1)
                {
                    totalitems = 0;
                    MessageBox.Show(e1.ToString());
                }

                
            }
            catch (Exception e1)
            {
                MessageBox.Show("1  \n" + e1.ToString());
            }
            totaltext.Text = totalitems.ToString();
           // MessageBox.Show(totalitems.ToString());
        }
        float totalsale;
        async Task setmore()
        {
            databseconnection dc = new databseconnection();
          await  dc.conn.OpenAsync();
            MySqlCommand com = dc.conn.CreateCommand();
            com.CommandText = "SELECT SUM(s.price * a.quantity) FROM sold_by s,adds a where a.status=1 and a.vid=@id and a.vid=s.VENDOR_VendorID and a.PRODUCT_productID=s.PRODUCT_productID;";
            com.Parameters.AddWithValue("@id", "456");
            try
            {
                await com.ExecuteNonQueryAsync();
                try
                {
                    MySqlDataReader reader = com.ExecuteReader();
                    while (reader.Read())
                    {
                       // saletext.Text = reader.GetFloat(0).ToString();
                        totalsale = reader.GetFloat(0);
                    }

                }
                catch (Exception e1)
                {
                    totalsale = 0;
                   // MessageBox.Show("error");
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show("1  \n" + e1.ToString());
            }
            //  MessageBox.Show(totalsale.ToString());
           saletext.Text = totalsale.ToString();
        }
        int pendorder;
        async Task setpending()
        {
            databseconnection dc = new databseconnection();
            await dc.conn.OpenAsync();
            MySqlCommand com = dc.conn.CreateCommand();
            com.CommandText = "SELECT count(*) FROM sold_by s,adds a where a.status=0 and a.vid=@id";
            com.Parameters.AddWithValue("@id", "456");
            try
            {
                await com.ExecuteNonQueryAsync();
                try
                {
                    MySqlDataReader reader = com.ExecuteReader();
                    while (reader.Read())
                    {
                       /// pendtext.Text = reader.GetInt32(0).ToString();
                        pendorder = reader.GetInt32(0);
                    }

                }
                catch (Exception e1)
                {
                    pendorder = 0;
                    //MessageBox.Show("error");
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show("1  \n" + e1.ToString());
            }
            // MessageBox.Show(pendorder.ToString());
            //  MessageBox.Show(totalsale.ToString());
            pendtext.Text = pendorder.ToString();
            
        }
        int shiporder;
        async Task setship()
        {
            databseconnection dc = new databseconnection();
            await dc.conn.OpenAsync();
            MySqlCommand com = dc.conn.CreateCommand();
            com.CommandText = "SELECT count(*) FROM sold_by s,adds a where a.status=1 and a.vid=@id";
            com.Parameters.AddWithValue("@id", "456");
            try
            {
                await com.ExecuteNonQueryAsync();
                try
                {
                    MySqlDataReader reader = com.ExecuteReader();
                    while (reader.Read())
                    {
                       // shiptext.Text = reader.GetInt32(0).ToString();
                        shiporder = reader.GetInt32(0);
                    }

                }
                catch (Exception e1)
                {
                    shiporder = 0;
                    //MessageBox.Show("error");
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show("1  \n" + e1.ToString());
            }
            // MessageBox.Show(pendorder.ToString());
            //  MessageBox.Show(totalsale.ToString());
            shiptext.Text = shiporder.ToString();

        }
    }
    }

