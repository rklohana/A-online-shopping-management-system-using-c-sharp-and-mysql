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
    public partial class vendorform : Form
    {
        vendor v;
        public vendorform(vendor v1)
        {
            v = v1;
            InitializeComponent();
        }

        private async void vendorform_Load(object sender, EventArgs e)
        {
            //databseconnection dc = new databseconnection();
            //await dc.conn.OpenAsync();

            //MySqlCommand com = dc.conn.CreateCommand();
            //com.CommandText = "Select count(*) from SOLD_BY where VENDOR_VENDORID =@id";
            //com.Parameters.AddWithValue("@id", "456");
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
            populateprod();
            populateoutstock();
            populatenew();
        }
        int n1, n2, n3, n4;
        async void populatenew()
        {
            // select* from PRODUCT where productID not in(SELECT Product_productID from sold_by where VENDOR_VENDORID = vendorid);

            {
                databseconnection dc = new databseconnection();
                await dc.conn.OpenAsync();

                MySqlCommand com = dc.conn.CreateCommand();
                com.CommandText = "Select count(*) from SOLD_BY where VENDOR_VENDORID =@id;";
                com.Parameters.AddWithValue("@id", vid);
                try
                {
                    await com.ExecuteNonQueryAsync();
                    try
                    {
                        MySqlDataReader reader = com.ExecuteReader();
                        while (reader.Read())
                        {
                            n1 = reader.GetInt32(0);
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

                await dc.conn.OpenAsync();

                

                com.CommandText = "Select count(*) from product";
                com.Parameters.AddWithValue("@id1", vid);
                try
                {
                    await com.ExecuteNonQueryAsync();
                    try
                    {
                        MySqlDataReader reader = com.ExecuteReader();
                        while (reader.Read())
                        {
                            n2 = reader.GetInt32(0);
                         //   MessageBox.Show("n2: "+n1.ToString());
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

                vendortemplate[] p = new vendortemplate[n2-n1];
                await dc.conn.OpenAsync();
                product[] p1 = new product[n2-n1];
                MySqlCommand com1 = dc.conn.CreateCommand();
                com1.CommandText = "select * from PRODUCT where productID not in(SELECT Product_productID from sold_by where VENDOR_VENDORID = @vid);";
                com1.Parameters.AddWithValue("@vid", "456");
                //try
                {
                    int i = 0;
                    await com1.ExecuteNonQueryAsync();
                    MySqlDataReader reader1 = com1.ExecuteReader();
                    while (reader1.Read())
                    {
                       // MessageBox.Show("new pan: " + (n2 - n1).ToString());
                        //p1[i] = new product();
                        //p1[i].setdata(reader1.GetString(2), reader1.GetString(3), reader1.GetString(4), reader1.GetString(5), "456", reader1.GetFloat(6), reader1.GetInt32(1));
                        p[i] = new vendortemplate(true);
                        p[i].PID = reader1.GetString(0);
                       // p[i].Price = reader1.GetString()
                        p[i].Nametext = reader1.GetString(1);
                        p[i].Vendor = reader1.GetString(0);
                        p[i].Description = reader1.GetString(3);
                        p[i].Icon = p1[i].photoback(reader1.GetString(2));
                        if (newpan.Controls.Count < 0)
                        {
                            newpan.Controls.Clear();
                        }
                        else
                        {
                            bunifuTransition1.ShowSync(p[i]);
                            newpan.Controls.Add(p[i]);
                        }
                        i++;
                    }
                }
                //  catch(Exception e)
                {
                    //MessageBox.Show(e.ToString());
                }
            }












        }
        async void populateprod()
        {   
            databseconnection dc = new databseconnection();
           await dc.conn.OpenAsync();
            
            MySqlCommand com = dc.conn.CreateCommand();
            com.CommandText = "Select count(*) from SOLD_BY where VENDOR_VENDORID =@id;";
            com.Parameters.AddWithValue("@id", vendorid);
            try
            {
                await com.ExecuteNonQueryAsync();
                try
                {
                    MySqlDataReader reader = com.ExecuteReader();
                    while (reader.Read())
                    {
                        n3 = reader.GetInt32(0);
                    }

                }
                catch(Exception e)
                {
                    MessageBox.Show("error");
                }
            }
            catch(Exception e)
            {
                MessageBox.Show("1  \n"+e.ToString());
            }
              await  dc.conn.CloseAsync();
           
           // MessageBox.Show(n3.ToString());

            vendortemplate[] p = new vendortemplate[n3];
           await dc.conn.OpenAsync();
            product[] p1 = new product[n3];
            MySqlCommand com1 = dc.conn.CreateCommand();
            com1.CommandText = "select v.VendorID,s.stock,p.productid,p.pname,p.image,p.description,s.price from VENDOR v,PRODUCT p,SOLD_BY s where s.VENDOR_VENDORID=@id and s.PRODUCT_PRODUCTID=p.PRODUCTID and s.VENDOR_VENDORID=v.VENDORID and s.stock>0;";
            com1.Parameters.AddWithValue("@id","456");
            //try
            {
                int i=0;
             await   com1.ExecuteNonQueryAsync();
                MySqlDataReader reader1 = com1.ExecuteReader();
                while (reader1.Read())
                {
                    
                  //  MessageBox.Show("prod pan: " + (n3).ToString());
                    p1[i] = new product();
                    p1[i].setdata(reader1.GetString(2), reader1.GetString(3), reader1.GetString(4), reader1.GetString(5), "456", reader1.GetFloat(6), reader1.GetInt32(1));
                    p[i] = new vendortemplate(false);
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




        async void populateoutstock()
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
                        n4 = reader.GetInt32(0);
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

            vendortemplate[] p = new vendortemplate[n4];
            await dc.conn.OpenAsync();
           // MessageBox.Show("1: " + n4.ToString());
            product[] p1 = new product[n4];
            MySqlCommand com1 = dc.conn.CreateCommand();
            com1.CommandText = "select v.VendorID,s.stock,p.productid,p.pname,p.image,p.description,s.price from VENDOR v,PRODUCT p,SOLD_BY s where s.VENDOR_VENDORID=@id and s.PRODUCT_PRODUCTID=p.PRODUCTID and s.VENDOR_VENDORID=v.VENDORID and stock=0;";
            com1.Parameters.AddWithValue("@id", "456");
            //try
            {
                int i = 0;
                await com1.ExecuteNonQueryAsync();
                MySqlDataReader reader1 = com1.ExecuteReader();
                while (reader1.Read())
                {
                    
                    
                    p1[i] = new product();
                    p1[i].setdata(reader1.GetString(2), reader1.GetString(3), reader1.GetString(4), reader1.GetString(5), "456", reader1.GetFloat(6), reader1.GetInt32(1));
                    p[i] = new vendortemplate(false);
                    p[i].PID = p1[i].getpid();
                    p[i].Price = p1[i].getprice().ToString();
                    p[i].Nametext = p1[i].getname();
                    p[i].Vendor = reader1.GetString(0);
                    p[i].Description = p1[i].getdescription();
                    p[i].Icon = p1[i].photoback(p1[i].getimage());
                    if (outstock.Controls.Count < 0)
                    {
                        outstock.Controls.Clear();
                    }
                    else
                    {
                        bunifuTransition1.ShowSync(p[i]);
                        outstock.Controls.Add(p[i]);
                    }
                    i++;
                }
            }
            //  catch(Exception e)
            {
              await  dc.conn.CloseAsync();   //MessageBox.Show(e.ToString());
            }
        }




        private void prodbutt_Click(object sender, EventArgs e)
        {
            newpan.Hide();
            outstock.Hide();
            prodpan.Show();
            prodpan.BringToFront();
            
        }

        private void prodpan_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            prodpan.Hide();
            outstock.Hide();
            newpan.Show();
            newpan.BringToFront();
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            prodpan.Hide();
            newpan.Hide();
            outstock.Show();
            outstock.BringToFront();
        }

        private void bunifuGradientPanel1_Click(object sender, EventArgs e)
        {

        }
    }
}
