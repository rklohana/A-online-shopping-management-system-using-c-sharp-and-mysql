﻿using System;
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
        public product()
        {
            connect();
        }
        MySqlConnection conn;
        void connect()
        {
            var builder = new MySqlConnectionStringBuilder
            {
                Server = "sql6.freesqldatabase.com",
                Database = "sql6456591",
                UserID = "sql6456591",
                Password = "eVlfl8pexq",
                // SslMode = MySqlSslMode.Required,
            };

            conn = new MySqlConnection(builder.ConnectionString);

        }
        public void setdata(string pid,string n, string im, string des,string vid,float pr)
        {
            id = pid;
            name = n;
            images = im;
            description = des;
            vendorid = vid;
            price = pr;
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
            MemoryStream m = new System.IO.MemoryStream();
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
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            int rowCount;
            using (var command = conn.CreateCommand())
            {
                command.CommandText = @"INSERT INTO PRODUCT (productID,Pname,Image,Description,price) VALUES (@proudctID, @Pname,@Image,@Description,@price);";
                command.Parameters.AddWithValue("@productID", id);
                command.Parameters.AddWithValue("@Pname", name);
                command.Parameters.AddWithValue("@Image", images);
                command.Parameters.AddWithValue("@Description", description);
                command.Parameters.AddWithValue("@price", price);
                rowCount = await command.ExecuteNonQueryAsync();
                if (rowCount > 0)
                {
                    MessageBox.Show("Inserted");
                }
            }

        }

        public void update()
        {

        }

    }
}
