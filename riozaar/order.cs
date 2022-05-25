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
    struct det{
       public string pid;
       public string vid;
    }

    class order
    {
        string id;
        string orddate;
        float totalamount;
        string custId;
        List<det> d;
        string location;
        MySqlConnection conn;
        void connect()
        {
            var builder = new MySqlConnectionStringBuilder
            {
               Server = "localhost",
                Database = "riozaar",
                UserID = "root",
                Password = "eVlfl8pexq",
                 SslMode = MySqlSslMode.Required,
            };

            conn = new MySqlConnection(builder.ConnectionString);

        }
        public order()
        {
            connect();
        }
        public void setdata(string n, float ta, string cid, List<det> p,string loc)
        {
            generateid();
            orddate = n;
            totalamount = ta;
            custId = cid;
            location = loc;
            d = new List<det>(p);
           
        }

       


        public async void generateid()
        {
            int n;
            string str = "o";
            databseconnection dc = new databseconnection();
            await dc.conn.OpenAsync();
            MySqlCommand command = dc.conn.CreateCommand();
            command.CommandText = "Select count(*) from orders;";
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
             MessageBox.Show(str);
            id = str;


        }



        public string getorddate()
        {
            return orddate;
        }
        public string getdid()
        {
            return id;
        }
        public float gettotalamount()
        {
            return totalamount;
        }
        public string getcustid()
        {
            return custId;
        }
        public List<det> getpid()
        {
            return d;
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
                    orddate = Reader.GetString(1);
                    totalamount= Reader.GetFloat(2);
                    custId= Reader.GetString(3);
                    

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
            conn.Open();
            MySqlCommand command = conn.CreateCommand();

            command.CommandText = @"delete from ORDERS where orderID=@orderID;";
            command.Parameters.AddWithValue("@orderID", em);
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
                command.CommandText = @"INSERT INTO ORDERS (orderID,ODate,CUSTOMER_email,totalAmount) VALUES (@orderID,@ODate,@CUSTOMER_email,@totalAmount);";
                command.Parameters.AddWithValue("@orderID", id);
                command.Parameters.AddWithValue("@ODate", orddate);
                command.Parameters.AddWithValue("@CUSTOMER_email", custId);
                command.Parameters.AddWithValue("@totalAmount", totalamount);
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
