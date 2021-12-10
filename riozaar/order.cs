using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;
using System.Data.SqlClient;
namespace riozaar
{ /*
    struct det{
        string pid;
        string vid;
    }

    class order
    {
        string id;
        string orddate;
        float totalamount;
        string custId;
        string vid;
        List<det> d;
        string location;
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
        public order()
        {
            connect();
        }
        public void setdata(string did, string n, string pho, string cid,string v, List<string> p,string loc)
        {
            id = did;
            name = n;
            phone = pho;
            custId = cid;
            vid = v;
            location = loc;
            pid = new List<string>(p);
        }
        public string getname()
        {
            return name;
        }
        public string getdid()
        {
            return id;
        }
        public string getphone()
        {
            return phone;
        }
        public string getcustid()
        {
            return custId;
        }
        public string getvid()
        {
            return vid;
        }
        public List<string> getpid()
        {
            return pid;
        }
        public string getlocation()
        {
            return location;
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

            command.CommandText = @"select orderID,ODate,totalAmount,CUSTOMER_email from ORDERS where orderID=@orderID;";
            command.Parameters.AddWithValue("@orderID", id);
            row = await command.ExecuteNonQueryAsync();
            using (MySqlDataReader Reader = command.ExecuteReader())
            {
                while (Reader.Read())
                {
                    id = Reader.GetString(0);
                    name = Reader.GetString(1);
                    phone = Reader.GetString(2);
                     //= Reader.GetString(3);
                    password = Reader.GetString(4);

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

            command.CommandText = @"delete from VENDOR where VendorID=@VendorID;";
            command.Parameters.AddWithValue("@VendorID", em);
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
                command.CommandText = @"INSERT INTO VENDOR (VendorID,VFName,phone,BAZAAR_BazaarID,password) VALUES (@VendorID,@VFName,@phone,@BAZAAR_BazaarID,@password);";
                command.Parameters.AddWithValue("@VendorID", id);
                command.Parameters.AddWithValue("@VFName", name);
                command.Parameters.AddWithValue("@phone", phone);
                command.Parameters.AddWithValue("@BAZAAR_BazaarID", bazID);
                command.Parameters.AddWithValue("@password", password);
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
    */
}
