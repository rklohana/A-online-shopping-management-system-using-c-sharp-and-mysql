using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;
using System.Data.SqlClient;
namespace riozaar
{
    class vendor
    {
        string id;
        string name;
        string phone;
        string password;
        string bazID;
        string[] days;
       
       
        
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
        public vendor()
        {
            days = new string[7];
            
            connect();
        }
        public void setdata(string did, string n, string pho,string pass, string bID,string[] d ,string [] st,string[] et, string loc)
        {
            id = did;
            name = n;
            phone = pho;
            password = pass;
            bazID = bID;
            for (int i=0;i<7;i++)
            {
                days[i] = d[i];
               
            }
           
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
        public string getpass()
        {
            return password;
        }
        public string[] getdays()
        {
            return days;
        }
       
       
        public string getbid()
        {
            return bazID;
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

            command.CommandText = @"select VendorID,VFName,phone,BAZAAR_BazaarID,password from VENDOR where VendorID=@VendorID;";
            command.Parameters.AddWithValue("@VendorID", pid);
            row = await command.ExecuteNonQueryAsync();
            using (MySqlDataReader Reader = command.ExecuteReader())
            {
                while (Reader.Read())
                {
                    id = Reader.GetString(0);
                    name = Reader.GetString(1);
                    phone = Reader.GetString(2);
                    bazID = Reader.GetString(3);
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
                command.Parameters.AddWithValue("@BAZAAR_BazaarID",bazID);
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
}
