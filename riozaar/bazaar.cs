using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;
using System.Data.SqlClient;
namespace riozaar
{   struct host
    {
      public  int loc;
       public string day;
    }
    class bazaar
    {
        string id;
        string st;
        string ed;
        int shops;
        List<host> h;
        public bazaar()
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
        public void setdata( string st_time, string ed_time, List<host> l)
        {
            generateid();
            st = st_time;
            ed = ed_time;
            h = new List<host>(l);
            //shops = n;0
            
        }
        public async void generateid()
        {
            int n;
            string str = "b";
            databseconnection dc = new databseconnection();
            await dc.conn.OpenAsync();
            MySqlCommand command = dc.conn.CreateCommand();
            command.CommandText = "Select count(*) from BAZAAR;";
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
        public List<host> getlocation()
        {
            return h;
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
     0
        public void update()
        {

        }
        public async void addwhole()
        {

            {
                databseconnection dc = new databseconnection();
                try
                {
                    await dc.conn.OpenAsync();
                    // conn.Open();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
                int rowCount=0;
                var command = dc.conn.CreateCommand();
                MySqlTransaction trans;
                //trans = conn.BeginTransaction();
                trans = await dc.conn.BeginTransactionAsync();

                // DateTime.ParseExact(st, "HH:mm:ss",InvariantCulture);

                //Convert.ToDateTime(st);

                //command.CommandText = "SAVEPOINT before_add";
                //await command.ExecuteNonQueryAsync();
                TimeSpan st1 = TimeSpan.Parse(st);
                TimeSpan ed1 = TimeSpan.Parse(ed);
                command.Connection = dc.conn;
                command.Transaction = trans;
                command.CommandText = @"INSERT INTO BAZAAR (BAZAARID,START_TIME,END_TIME) VALUES (@id, @st,@et);";
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@st",st1 );
                command.Parameters.AddWithValue("@et", ed1);

                //rowCount= command.ExecuteNonQuery();
                rowCount = await command.ExecuteNonQueryAsync();
                if (rowCount > 0)
                {
                    MessageBox.Show("Inserted");
                }
                //  await dc.conn.CloseAsync();
                //using (var command = conn.CreateCommand())


                int i1 = 0;
                foreach(var i in h)
                {
                   // await dc.conn.OpenAsync();
                    //using (var command1= conn.CreateCommand()) {
                    //    command1.Connection = dc.conn;
                    //    command1.Transaction = trans;

                        command.CommandText = @"INSERT INTO host VALUES (@p"+i1.ToString()+ ",@s" + i1.ToString() + ",@v" + i1.ToString() + ");";
                        command.Parameters.AddWithValue("@p"+i1.ToString(), i.loc);

                    
                        command.Parameters.AddWithValue("@s"+i1.ToString(), id); 
                        command.Parameters.AddWithValue("@v"+i1.ToString(), i.day);

                    i1++;
                        try
                        {
                            // rowCount = command.ExecuteNonQuery();
                            rowCount += await command.ExecuteNonQueryAsync();
                            //await dc.conn.CloseAsync();
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.Message);
                            //  trans.Rollback();
                            await trans.RollbackAsync();
                            //command.CommandText = "ROLLBACK TO before_add";
                            //await command.ExecuteNonQueryAsync();
                            MessageBox.Show("Rolled back to save points");
                            rowCount = 0;
                            await dc.conn.CloseAsync();
                            break;
                            //  await conn.CloseAsync();

                        }

                   // }
                    

                }
                
                try
                {
                    if (rowCount > 0)
                    {
                        await trans.CommitAsync();
                        MessageBox.Show("Inserted");
                    }
                    // conn.Close();
                    await dc.conn.CloseAsync();
                }0
                catch (Exception e1)
                {
                   // await conn.CloseAsync();
                    MessageBox.Show(e1.ToString());
                }

            }
        }
    }
    }


