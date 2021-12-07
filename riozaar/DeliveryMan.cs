using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                Server = "sql6.freesqldatabase.com",
                Database = "sql6456591",
                UserID = "sql6456591",
                Password = "eVlfl8pexq",
                // SslMode = MySqlSslMode.Required,
            };

            conn = new MySqlConnection(builder.ConnectionString);

        }
        public void setdata(string did, string n, string pho, string mid,string pass)
        {
            id = did;
            name = n;
            phone = pho;
            managerId = mid;
            password = pass;
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

            command.CommandText = @"select DeliveryManID,DMName,DELIVERYMAN_DeliveryManID,password,Phone from DELIVERYMAN where DeliveryManID=@DeliveryManID;";
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
                command.CommandText = @"INSERT INTO DELIVERYMAN (DeliveryManID,DMName,DELIVERYMAN_DeliveryManID,password,Phone) VALUES (@DeliveryManID,@DMName,@DELIVERYMAN_DeliveryManID,@password,@Phone);";
                command.Parameters.AddWithValue("@DeliveryManID", id);
                command.Parameters.AddWithValue("@DMName", name);
                command.Parameters.AddWithValue("@DELIVERYMAN_DeliveryManID", managerId);
                command.Parameters.AddWithValue("@password", password);
                command.Parameters.AddWithValue("@Phone", phone);
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
