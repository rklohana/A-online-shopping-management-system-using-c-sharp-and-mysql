using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;
namespace riozaar
{
    class locations
    {
        int id;
        string address;

        public locations()
        {
            id = -1;
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
        public void setdata(int n,string a)
        {
            id = n;
            address = a;
        }

        public int getid()
        {
            return id;
        }
        public string getadd()
        {
            return address;
        }
        
        public async void add(string loc)
        {
            address = loc;

            try
            {
                await conn.OpenAsync();
            }
            catch (Exception e)
            {
                MessageBox.Show("Cant connect to database");
            }
            int rowCount;
            using (var command = conn.CreateCommand())
            {
                command.CommandText = @"INSERT INTO LOCATION (Address) VALUES (@a);";
                command.Parameters.AddWithValue("@a", address);
                
                rowCount = await command.ExecuteNonQueryAsync();
                if (rowCount > 0)
                {
                    MessageBox.Show("Inserted");
                }
            }
            await conn.CloseAsync();

        }
        public async Task<bool> retrieveid(string n)
        {

            try
            {
                await conn.OpenAsync();
            }
            catch (Exception e)
            {
                await conn.CloseAsync();
                MessageBox.Show("cant reach server \n please check your internet connection and try again");
                return false;
            }
            int row;

            MySqlCommand command = conn.CreateCommand();

            command.CommandText = @"select * from LOCATION where address=@i;";
            command.Parameters.AddWithValue("@i", n);
            row = await command.ExecuteNonQueryAsync();

            try
            {
                MySqlDataReader Reader = command.ExecuteReader();
                while (await Reader.ReadAsync())
                {
                    //locations l1 = new locations();
                    id = Reader.GetInt32(0);
                    address = Reader.GetString(1);





                }
                //  l2 = new List<locations>(l);


            }
            catch (Exception e)
            {
                await conn.CloseAsync();
                return false;
            }


            if (id != -1)
            {
                await conn.CloseAsync();
                return true;
            }
            else
            {
                await conn.CloseAsync();
                return false;
            }
            //MessageBox.Show("Data found!");
        }
        public async Task<bool> retrievedata(int n)
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
           
            command.CommandText = @"select * from LOCATION where locationid=@i;";
            command.Parameters.AddWithValue("@i", n);
            row = await command.ExecuteNonQueryAsync();
            
            try
            {
                MySqlDataReader Reader = command.ExecuteReader();
                while (await Reader.ReadAsync())
                {    locations l1 = new locations();
                    id = Reader.GetInt32(0);
                    address = Reader.GetString(1);
                    
                    
                   
                    
                    
                }
               //  l2 = new List<locations>(l);


            }
            catch (Exception e)
            {
                return false;
            }
           
           
            if (id != -1)
            {
                return true;
            }
            else
            {
                return false;
            }
            //MessageBox.Show("Data found!");
        }

    }
}
