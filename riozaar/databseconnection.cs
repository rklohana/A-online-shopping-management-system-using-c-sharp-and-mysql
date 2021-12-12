using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using System.Windows.Forms;
namespace riozaar
{
    class databseconnection
    {
        public MySqlConnection conn;
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
        public databseconnection()
        {
            connect();
        }
       public async void closeconnect()
        {
            try
            {
                await conn.CloseAsync();
            }
            catch(Exception e)
            {
                MessageBox.Show("Connection already closed");
            }
            }
        public async void openconnect()
        {
            try
            {
                await conn.OpenAsync();
            }
            catch(Exception e)
            {
                MessageBox.Show("Cant connect to server\n Check internet connection");
            }
        }
    }
}
