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
    class customer
    {
        string name;
        string phone;
        string email;
        string address;
        string pass;
        
        public customer()
        {
            name = null;
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
        public void setdata(string n,string ad,string no,string e,string p)
        {
            name = n;
            phone = no;
            pass = p;
            email = e;
            address = ad;
        }
        public string getname()
        {
            return name;
        }
        public string getphone()
        {
            return phone;
        }
        public string getemail()
        {
            return email;
        }
        public string getaddress()
        {
            return address;
        }

        public string getpass()
        {
            return pass;
        }
        public async Task<bool> retrievedata(string em)
        {
            try
            {
                await conn.OpenAsync();
            }
            catch (Exception e)
            {
                MessageBox.Show("cant reach server \n please check your internet connection and try again");
                return false;
            }
            int row = 0; ;
            
            MySqlCommand command = conn.CreateCommand();

            command.CommandText = @"select * from CUSTOMER where email= @email;";
            command.Parameters.AddWithValue("@email", em);
            try
            {
                row = await command.ExecuteNonQueryAsync();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            using (MySqlDataReader Reader = command.ExecuteReader())
            {
                while (Reader.Read())
                {
                    email = Reader.GetString(0);
                    name = Reader.GetString(1);
                    phone = Reader.GetString(2);
                    address = Reader.GetString(3);
                    pass = Reader.GetString(5);
                    this.setdata(name, address, phone, email, pass);
                }
                
            }
           
            if (name!=null)
            {
                
                return true;
            }
            else
            {   
                
                MessageBox.Show("not retrieved");
                return false;            
            }
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

            command.CommandText = @"delete from CUSTOMER where email=@email;";
            command.Parameters.AddWithValue("@email", em);
            row = await command.ExecuteNonQueryAsync();
            MessageBox.Show("Data Deleted");
            await conn.CloseAsync();
            
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
                command.CommandText = @"INSERT INTO CUSTOMER (email,fName, Phone,Address,password) VALUES (@email, @name,@phone,@address,@pass);";
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@phone", phone);
                command.Parameters.AddWithValue("@pass", pass);
                command.Parameters.AddWithValue("@address", address);
                rowCount = await command.ExecuteNonQueryAsync();
                if (rowCount > 0)
                {
                    MessageBox.Show("Inserted");
                }
            }
            
        }

        public async void updatename(string ename)
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
                command.CommandText = @"UPDATE CUSTOMER fName= @name;";
                command.Parameters.AddWithValue("@name", ename);
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
                command.CommandText = @"UPDATE CUSTOMER Phone= @phone;";
                command.Parameters.AddWithValue("@phone", pho);
                rowCount = await command.ExecuteNonQueryAsync();
                if (rowCount > 0)
                {
                    MessageBox.Show("Updated");
                }
            }
        }
        public async void updateaddr(string addr)
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
                command.CommandText = @"UPDATE CUSTOMER Address= @addr;";
                command.Parameters.AddWithValue("@addr", addr);
                rowCount = await command.ExecuteNonQueryAsync();
                if (rowCount > 0)
                {
                    MessageBox.Show("Updated");
                }
            }
        }
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
                command.CommandText = @"UPDATE CUSTOMER password= @pass;";
                command.Parameters.AddWithValue("@pass", pass);
                rowCount = await command.ExecuteNonQueryAsync();
                if (rowCount > 0)
                {
                    MessageBox.Show("Updated");
                }
            }
        }
    }

}
