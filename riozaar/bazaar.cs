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
    class bazaar
    {
        string id;
        string st;
        string ed;
        int shops;
        List<int> location;
        public bazaar()
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
        public void setdata(string did, string st_time, string ed_time, int n,List<int> locs)
        {
            id = did;
            st = st_time;
            ed = ed_time;
            location = new List<int>(locs);
            shops = n;
            
        }
        public string getst()
        {
            return st;
        }
        public string getdid()
        {
            return id;
        }
        public string geted()
        {
            return ed;
        }
        public int getshops()
        {
            return shops;
        }
        public List<int> getlocation()
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

            command.CommandText = @"select BazaarID,Start_Time,End_Time,NoOfShops from BAZAAR where BazaarID=@BazaarID;";
            command.Parameters.AddWithValue("@BazaarID", id);
            row = await command.ExecuteNonQueryAsync();
            using (MySqlDataReader Reader = command.ExecuteReader())
            {
                while (Reader.Read())
                {
                    id = Reader.GetString(0);
                    st = Reader.GetString(1);
                    ed = Reader.GetString(2);
                    shops = Reader.GetInt32(3);
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

            command.CommandText = @"delete from BAZAAR where BazaarID=@BazaarID;";
            command.Parameters.AddWithValue("@BazaarID", em);
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
                command.CommandText = @"INSERT INTO BAZAAR (BazaarID,Start_Time,End_Time,NoOfShops) VALUES (@BazaarID,@Start_Time,@End_Time,@NoOfShops);";
                command.Parameters.AddWithValue("@BazaarID", id);
                command.Parameters.AddWithValue("@Start_Time",st);
                command.Parameters.AddWithValue("@End_Time", ed);
                command.Parameters.AddWithValue("@NoOfShops", shops);
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
