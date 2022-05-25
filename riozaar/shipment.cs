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
    
    class shipment
    {
        string sdate;
        string orderId;
        string DMid;
        string status;
        string paymentstatus;
        string location;
      

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
        public shipment()
        {
            connect();
        }
        public void setdata(string sd, string oid, string dmid, string st, string pst,string loc)
        {
            sdate = sd;
            orderId = oid;
            DMid = dmid;
            status= st;
            paymentstatus = pst;
            location = loc;
            
        }
        public string getoid()
        {
            return orderId;
        }
        public string getsd()
        {
            return sdate;
        }
        public string getdmid()
        {
            return DMid;
        }
        public string getstatus()
        {
            return status;
        }
        public string getpstatus()
        {
            return paymentstatus;
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

            command.CommandText = @"select sdate,shipmentStatus,paymentStatus,DELIVERYMAN_DeliveryManID,ORDERS_orderID from SHIPMENT where ORDERS_orderID=@ORDERS_orderID;";
            command.Parameters.AddWithValue("@ORDERS_orderID", orderId);
            row = await command.ExecuteNonQueryAsync();
            using (MySqlDataReader Reader = command.ExecuteReader())
            {
                while (Reader.Read())
                {
                    sdate= Reader.GetString(0);
                    orderId = Reader.GetString(1);
                    DMid = Reader.GetString(2);
                    status = Reader.GetString(3);
                    paymentstatus = Reader.GetString(4);
                    
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

            command.CommandText = @"delete from SHIPMENT where ORDERS_orderID=@ORDERS_orderID;";
            command.Parameters.AddWithValue("@ORDERS_orderID", em);
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
                command.CommandText = @"INSERT INTO SHIPMENT(sdate,shipmentStatus,paymentStatus,DELIVERYMAN_DeliveryManID,ORDERS_orderID) VALUES (sdate,shipmentStatus,paymentStatus,DELIVERYMAN_DeliveryManID,ORDERS_orderID);";
                command.Parameters.AddWithValue("@ORDERS_orderID", orderId);
                command.Parameters.AddWithValue("@sdate", sdate);
                command.Parameters.AddWithValue("@shipmentStatus", status);
                command.Parameters.AddWithValue("@paymentStatus", paymentstatus);
                command.Parameters.AddWithValue("@DELIVERYMAN_DeliveryManID", DMid);
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
