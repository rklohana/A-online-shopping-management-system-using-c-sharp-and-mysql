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
    class DeliveryMan
    {
        string id;
        string name;
        string phone;
        string managerId;
        string password;
        public DeliveryMan()
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
        public void setdata(string n, string pho, string mid,string pass)
        {
            generateid();
            name = n;
            phone = pho;
            managerId = mid;
            password = pass;
        }
        public async void generateid()
        {
            int n;
            string str = "dm";
            databseconnection dc = new databseconnection();
            await dc.conn.OpenAsync();
            MySqlCommand command = dc.conn.CreateCommand();
            command.CommandText = "Select count(*) from DELIVERYMAN;";
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
        public string getmanagerid()
        {
            return managerId;
        }
        public string getpass()
        {
            return password;
        }

        public async Task<bool> retrievedata(string pid)
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
            int row;

            MySqlCommand command = conn.CreateCommand();

            command.CommandText = @"select DeliveryManID,DMName,DELIVERYMAN_DeliveryManID,password,Phone from DELIVERYMAN where DeliveryManID=@DeliveryMan;";
            command.Parameters.AddWithValue("@DeliveryMan", id);
            row = await command.ExecuteNonQueryAsync();
            using (MySqlDataReader Reader = command.ExecuteReader())
            {
                while (Reader.Read())
                {
                    id = Reader.GetString(0);
                    name = Reader.GetString(1);
                    managerId = Reader.GetString(2);
                    password = Reader.GetString(3);
                    phone = Reader.GetString(4);
                }


            }
            if (id == null)
            {
                return false;
            }
            else
            {
                return true;
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

            command.CommandText = @"delete from DELIVERYMAN where DeliveryManID=@DeliveryManID;";
            command.Parameters.AddWithValue("@DeliveryManID", em);
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
                try
                {
                    command.CommandText = @"INSERT INTO DELIVERYMAN  VALUES (@DeliveryManID,@DMName,@Phone,@DELIVERYMAN_DeliveryManID,@password,@loc);";
                    command.Parameters.AddWithValue("@DeliveryManID", id);
                    command.Parameters.AddWithValue("@DMName", name);
                    command.Parameters.AddWithValue("@DELIVERYMAN_DeliveryManID", managerId);
                    command.Parameters.AddWithValue("@password", password);
                    command.Parameters.AddWithValue("@Phone", phone);
                    command.Parameters.AddWithValue("@loc", 1);
                    rowCount = await command.ExecuteNonQueryAsync();
                    if (rowCount > 0)
                    {
                        MessageBox.Show("Inserted");
                    }
                }
                catch(Exception e)
                {
                    MessageBox.Show(e.ToString());
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
                command.CommandText = @"UPDATE DELIVERYMAN DMName= @name;";
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
                command.CommandText = @"UPDATE DELIVERYMAN Phone= @phone;";
                command.Parameters.AddWithValue("@phone", pho);
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
                command.CommandText = @"UPDATE DELIVERYMAN password= @pass;";
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
