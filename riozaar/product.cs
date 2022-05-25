using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;

namespace riozaar
{
    class product
    {
        string id;
        string name;
        string images;
        string description;
        string vendorid;
        float price;
        int qt;
        public product()
        {
            connect();
        }
        MySqlConnection conn;
        void connect()
        {
            var builder = new MySqlConnectionStringBuilder
            {
                Server = "localhost",
                Database = "riozaar",
                UserID = "root",
                //Password = "eVlfl8pexq",
                // SslMode = MySqlSslMode.Required,
            };

            conn = new MySqlConnection(builder.ConnectionString);

        }
        public void setdata(string n, string im, string des,string vid,float pr,int q)
        {
            // id = pid;
            generateid();
            name = n;
            images = im;
            description = des;
            vendorid = vid;
            price = pr;
            qt = q;
        }
        public async void generateid()
        {
            int n;
            string str = "p";
            databseconnection dc = new databseconnection();
            await dc.conn.OpenAsync();
            MySqlCommand command = dc.conn.CreateCommand();
            command.CommandText = "Select count(*) from PRODUCT;";
            try
            {
                await command.ExecuteNonQueryAsync();
            }
            catch (Exception e)
            {
                MessageBox.Show("wrong query");
                return;
            }
            MySqlDataReader reader;
            try
            {
                reader = command.ExecuteReader();
            }
            catch (Exception e)
            {
                MessageBox.Show("some error");
                return;
            }
            while (reader.Read())
            {
                n = reader.GetInt32(0);
                str += n.ToString();
            }

            await dc.conn.CloseAsync();
            // MessageBox.Show(str);
            id = str;


        }
        public string getname()
        {
            return name;
        }
        public string getpid()
        {
            return id;
        }
        public string getimage()
        {
            return images;
        }
        public string getdescription()
        {
            return description;
        }
        public string getvid()
        {
            return vendorid;
        }
        public float getprice()
        {
            return price;
        }
        public string photoconvert(Bitmap i)
        {
            string image1;
            MemoryStream m = new MemoryStream();
            i.Save(m, ImageFormat.Jpeg);
            byte[] a = m.GetBuffer();
            image1 = Convert.ToBase64String(a);
            return image1;
        }
        public Image photoback(string i)
        {
            byte[] b = Convert.FromBase64String(i);
            MemoryStream m = new MemoryStream();
            m.Write(b, 0, Convert.ToInt32(b.Length));
            Bitmap bm = new Bitmap(m, false);
            m.Dispose();
            return bm;
        }
        public async void retrievedata(string pid)
        {
            try
            {
                await conn.OpenAsync();
            }
            catch (Exception e)
            {
                MessageBox.Show("cant reach server \n please check your internet connection and try again");
                return;
            }
            int row;

            MySqlCommand command = conn.CreateCommand();

            command.CommandText = @"select productID,Pname,Image,Description,price from PRODUCT where productID=@productID;";
            command.Parameters.AddWithValue("@productID", pid);
            row = await command.ExecuteNonQueryAsync();
            using (MySqlDataReader Reader = command.ExecuteReader())
            {
                while (Reader.Read())
                {
                    id = Reader.GetString(0);
                    name = Reader.GetString(1);
                    images = Reader.GetString(2);
                    description = Reader.GetString(3);
                    price = Reader.GetFloat(4);
                }
                

            }
            MessageBox.Show("Data found!");
        }
        public async void delete(string em)
        {
            try
            {
                await conn.OpenAsync();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            int row;
            //conn.Open();
            MySqlCommand command = conn.CreateCommand();

            command.CommandText = @"delete from PRODUCT where productID=@productID;";
            command.Parameters.AddWithValue("@productID", em);
            row = await command.ExecuteNonQueryAsync();
            MessageBox.Show("Data Deleted");

        }
        public async void add()
        {
            try
            {
                await conn.OpenAsync();
               // conn.Open();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            int rowCount;
            var command = conn.CreateCommand();
            MySqlTransaction trans;
            //trans = conn.BeginTransaction();
            trans= await conn.BeginTransactionAsync();




            //command.CommandText = "SAVEPOINT before_add";
            //await command.ExecuteNonQueryAsync();
            command.Connection = conn;
            command.Transaction = trans;
                command.CommandText = @"INSERT INTO PRODUCT (productID,Pname,Image,Description) VALUES (@productID, @Pname,@Image,@Description);";
                command.Parameters.AddWithValue("@productID", id);
                command.Parameters.AddWithValue("@Pname", name);
                command.Parameters.AddWithValue("@Image", images);
                command.Parameters.AddWithValue("@Description", description);
           //rowCount= command.ExecuteNonQuery();
                rowCount = await command.ExecuteNonQueryAsync();
                if (rowCount > 0)
                {
                    MessageBox.Show("Inserted");
                }
            
            //using (var command = conn.CreateCommand())
            
                command.CommandText = @"INSERT INTO sold_by (PRODUCT_productID,stock,VENDOR_VendorID,price) VALUES (@p,@s,@v,@price);";
                command.Parameters.AddWithValue("@p", id);
                command.Parameters.AddWithValue("@s", qt);
                command.Parameters.AddWithValue("@v", vendorid);
                command.Parameters.AddWithValue("@price", price);
                try
                {
               // rowCount = command.ExecuteNonQuery();
                    rowCount = await command.ExecuteNonQueryAsync();
                    if (rowCount > 0)
                    { 
                        await trans.CommitAsync();
                        MessageBox.Show("Inserted");
                    }
                }
                catch(Exception e)
                {
                    MessageBox.Show(e.Message);
              //  trans.Rollback();
                 await trans.RollbackAsync();
                //command.CommandText = "ROLLBACK TO before_add";
                //await command.ExecuteNonQueryAsync();
                    MessageBox.Show("Rolled back to save points");
                    
                
                try
                {
                   // conn.Close();
                    await conn.CloseAsync();
                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.ToString());
                }
            }

        }

        public void update()
        {

        }

    }
}
