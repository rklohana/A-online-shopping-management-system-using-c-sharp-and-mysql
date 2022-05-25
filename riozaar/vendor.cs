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
   public class vendor
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
                Server = "localhost",
                Database = "riozaar",
                UserID = "root",
                //Password = "eVlfl8pexq",
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
            generateid();
            name = n;
            phone = pho;
            password = pass;
            bazID = bID;
            for (int i=0;i<7;i++)
            {
                days[i] = d[i];
               
            }
           
        }
        public async void generateid()
        {
            int n;
            string str = "v";
            databseconnection dc = new databseconnection();
            await dc.conn.OpenAsync();
            MySqlCommand command = dc.conn.CreateCommand();
            command.CommandText = "Select count(*) from VENDOR;";
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
        //VendorID VFName phone BAZAAR_BazaarID password
        public async void updatepass(string pass)
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
                command.CommandText = @"UPDATE VENDOR password= @pass;";
                command.Parameters.AddWithValue("@pass", pass);
                rowCount = await command.ExecuteNonQueryAsync();
                if (rowCount > 0)
                {
                    MessageBox.Show("Updated");
                }
            }
        }
        public async void updateNAME(string fname)
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
                command.CommandText = @"UPDATE VENDOR VFName= @name;";
                command.Parameters.AddWithValue("@name", fname);
                rowCount = await command.ExecuteNonQueryAsync();
                if (rowCount > 0)
                {
                    MessageBox.Show("Updated");
                }
            }
        }
        public async void updatephone(string pho)
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
                command.CommandText = @"UPDATE VENDOR phone= @phone;";
                command.Parameters.AddWithValue("@phone", pho);
                rowCount = await command.ExecuteNonQueryAsync();
                if (rowCount > 0)
                {
                    MessageBox.Show("Updated");
                }
            }
        }
    }
}
