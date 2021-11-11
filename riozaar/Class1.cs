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
        password pass;
        
        public customer()
        {
            connect();
        }
        MySqlConnection conn;
        async void connect()
        {   
            pass = new password();
            var builder = new MySqlConnectionStringBuilder
            {
                Server = "riozaar.mysql.database.azure.com",
                Database = "riozaar_data",
                UserID = "ruhal@riozaar",
                Password = "Iamrklohana123",
                SslMode = MySqlSslMode.Required,
            };

            conn = new MySqlConnection(builder.ConnectionString);
            
        }
        public void setdata(string n,string ad,string no,string e,string p)
        {
            name = n;
            phone = no;
            pass.currpass = p;
            email = e;
            address = ad;
        }
        public async void retrievedata(string em)
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

            command.CommandText = @"select email,fname,phone,address from customer where email=@email;";
            command.Parameters.AddWithValue("@email", em);
            row = await command.ExecuteNonQueryAsync();
            using (MySqlDataReader Reader = command.ExecuteReader())
            {
                while (Reader.Read())
                {
                    email = Reader.GetString(0);
                    name = Reader.GetString(1);
                    phone = Reader.GetString(2);
                    address = Reader.GetString(3);
                }
                
            }
            MessageBox.Show(email +" "+ name+" " + phone+" " + address);
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

            command.CommandText = @"delete from customer where email=@email;";
            command.Parameters.AddWithValue("@email", em);
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
                command.CommandText = @"INSERT INTO customer (email,fName, Phone,Address) VALUES (@email, @name,@phone,@address);";
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@phone", phone);

                command.Parameters.AddWithValue("@address", address);
                rowCount = await command.ExecuteNonQueryAsync();
            }
            using (var command1 = conn.CreateCommand())
            {
                command1.CommandText = @"INSERT INTO password (pass,oldpassword, LastChanged,Customer_email) VALUES (@pass, @last,@l_d,@email);";
                command1.Parameters.AddWithValue("@pass", pass.currpass);
                command1.Parameters.AddWithValue("@last", pass.oldpass);
                command1.Parameters.AddWithValue("@l_d", pass.last);
                command1.Parameters.AddWithValue("@email", email);
                int rowCount1 = await command1.ExecuteNonQueryAsync();

                if (rowCount > 0 && rowCount1 > 0)
                {
                    MessageBox.Show("Inserted");
                }
            }
        }

        public async void update()
        {

        }
    }
    class password
    {
       
       public string oldpass;
       public string currpass;
       public DateTime last;

       
    }


}
