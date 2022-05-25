using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;
namespace riozaar
{
    public partial class bazaaradd : UserControl
    {
        List<string>[] l = new List<string>[7];
        public bazaaradd()
        {

            InitializeComponent();
            fillboxes();
        }
        async void fillboxes()
        {
            for (int i = 0; i < 7; i++)
            {
                l[i] = new List<string>();
            }
            string[] str = { "monday", "tuesday", "wednesday", "thursday", "friday", "saturday", "sunday" };
            for (int i = 0; i < 7; i++)
            {
                await addlocs(str[i], i);

            }
            foreach (var i1 in l[0])
            {
                monbox.Items.Add(i1);
                // MessageBox.Show(i1);
            }
            foreach (var i1 in l[1])
            {
                tuebox.Items.Add(i1);
                // MessageBox.Show(i1);
            }
            foreach (var i1 in l[2])
            {
                wedbox.Items.Add(i1);
                // MessageBox.Show(i1);
            }
            foreach (var i1 in l[3])
            {
                thurbox.Items.Add(i1);
                // MessageBox.Show(i1);
            }
            foreach (var i1 in l[4])
            {
                fribox.Items.Add(i1);
                // MessageBox.Show(i1);
            }
            foreach (var i1 in l[5])
            {
                satbox.Items.Add(i1);
                // MessageBox.Show(i1);
            }
            foreach (var i1 in l[6])
            {
                sunbox.Items.Add(i1);
                // MessageBox.Show(i1);
            }

        }
        async Task<bool> addlocs(string d, int i)
        {
            databseconnection dc = new databseconnection();
            try
            {
                await dc.conn.OpenAsync();
            }
            catch (Exception e)
            {
                MessageBox.Show("Cant connect to database");
                return false;
            }
            MySqlCommand command = dc.conn.CreateCommand();
            command.CommandText = "select address from location where locationid not in(select l.locationid from location l,host h where l.locationid=h.LOCATION_LocationID and h.days =@da);";
            command.Parameters.AddWithValue("@da", d);
            try
            {
                await command.ExecuteNonQueryAsync();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }
            try
            {
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    l[i].Add(reader.GetString(0));
                    // MessageBox.Show(reader.GetString(0));
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("some error");
                return false;
            }
            try
            {
                await dc.conn.CloseAsync();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("cant close");
                return false;
            }

        }
        private void bazaaradd_Load(object sender, EventArgs e)
        {
           // dateTimePicker1.Format = DateTimePickerFormat.Time;
           // dateTimePicker1.ShowUpDown = true;
            //MessageBox.Show(dateTimePicker1.Value.ToString("t"));

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        async void dowork()
        {
            locations l1 = new locations();

            List<host> l = new List<host>();
            if (monbox.SelectedIndex != -1)
            {
                await l1.retrieveid(monbox.SelectedItem.ToString());
                //MessageBox.Show(l1.getid().ToString());
                host h11 = new host();
                h11.loc = l1.getid();
                h11.day = "monday";
                l.Add(h11);
            }
            if (tuebox.SelectedIndex != -1)
            {
                await l1.retrieveid(tuebox.SelectedItem.ToString());
                //MessageBox.Show(l1.getid().ToString());
                host h11 = new host();
                h11.loc = l1.getid();
                h11.day = "tuesday";
                l.Add(h11);
            }
            if (wedbox.SelectedIndex != -1)
            {
                await l1.retrieveid(wedbox.SelectedItem.ToString());
                //MessageBox.Show(l1.getid().ToString());
                host h11 = new host();
                h11.loc = l1.getid();
                h11.day = "wednesday";
                l.Add(h11);
            }
            if (thurbox.SelectedIndex != -1)
            {
                await l1.retrieveid(thurbox.SelectedItem.ToString());
                //MessageBox.Show(l1.getid().ToString());
                host h11 = new host();
                h11.loc = l1.getid();
                h11.day = "thursday";
                l.Add(h11);
            }
            if (fribox.SelectedIndex != -1)
            {
                await l1.retrieveid(fribox.SelectedItem.ToString());
                //MessageBox.Show(l1.getid().ToString());
                host h11 = new host();
                h11.loc = l1.getid();
                h11.day = "friday";
                l.Add(h11);
            }
            if (satbox.SelectedIndex != -1)
            {
                await l1.retrieveid(satbox.SelectedItem.ToString());
                //MessageBox.Show(l1.getid().ToString());
                host h11 = new host();
                h11.loc = l1.getid();
                h11.day = "saturday";
                l.Add(h11);
            }
            if (sunbox.SelectedIndex != -1)
            {
                await l1.retrieveid(sunbox.SelectedItem.ToString());
                //MessageBox.Show(l1.getid().ToString());
                host h11 = new host();
                h11.loc = l1.getid();
                h11.day = "sunday";
                l.Add(h11);
            }
            //foreach (var i in l)
            //{
            //    MessageBox.Show(i.loc.ToString() + " " + i.day);
            //}
            // MessageBox.Show("Added");
            bazaar b = new bazaar();
            b.setdata(dateTimePicker1.Value.ToString("HH:mm:ss"), dateTimePicker2.Value.ToString("HH:mm:ss"), l);
            b.addwhole();
           

        }
        private  void signupbutt_Click(object sender, EventArgs e)
        {

            if (dateTimePicker1.Value < dateTimePicker2.Value)
            {
                dowork();
            }
            else
            {
                MessageBox.Show("please select valid time");
            }
        //        databseconnection dc = new databseconnection();
        //        try
        //        {
        //            await dc.conn.OpenAsync();
        //            // conn.Open();
        //        }
        //        catch (Exception e1)
        //        {
        //            MessageBox.Show(e.ToString());
        //        }
        //        int rowCount;
        //        var command = dc.conn.CreateCommand();
        //        MySqlTransaction trans;
        //        //trans = conn.BeginTransaction();
        //        trans = await dc.conn.BeginTransactionAsync();




        //        //command.CommandText = "SAVEPOINT before_add";
        //        //await command.ExecuteNonQueryAsync();
        //        command.Connection = dc.conn;
        //        command.Transaction = trans;
        //        command.CommandText = @"INSERT INTO PRODUCT (productID,Pname,Image,Description) VALUES (@productID, @Pname,@Image,@Description);";
        //        command.Parameters.AddWithValue("@productID", id);
        //        command.Parameters.AddWithValue("@Pname", name);
        //        command.Parameters.AddWithValue("@Image", images);
        //        command.Parameters.AddWithValue("@Description", description);
        //        //rowCount= command.ExecuteNonQuery();
        //        rowCount = await command.ExecuteNonQueryAsync();
        //        if (rowCount > 0)
        //        {
        //            MessageBox.Show("Inserted");
        //        }

        //        //using (var command = conn.CreateCommand())

        //        command.CommandText = @"INSERT INTO sold_by (PRODUCT_productID,stock,VENDOR_VendorID,price) VALUES (@p,@s,@v,@price);";
        //        command.Parameters.AddWithValue("@p", id);
        //        command.Parameters.AddWithValue("@s", qt);
        //        command.Parameters.AddWithValue("@v", vendorid);
        //        command.Parameters.AddWithValue("@price", price);
        //        try
        //        {
        //            // rowCount = command.ExecuteNonQuery();
        //            rowCount = await command.ExecuteNonQueryAsync();
        //            if (rowCount > 0)
        //            {
        //                await trans.CommitAsync();
        //                MessageBox.Show("Inserted");
        //            }
        //        }
        //        catch (Exception e)
        //        {
        //            MessageBox.Show(e.Message);
        //            //  trans.Rollback();
        //            await trans.RollbackAsync();
        //            //command.CommandText = "ROLLBACK TO before_add";
        //            //await command.ExecuteNonQueryAsync();
        //            MessageBox.Show("Rolled back to save points");


        //            try
        //            {
        //                // conn.Close();
        //                await conn.CloseAsync();
        //            }
        //            catch (Exception e1)
        //            {
        //                MessageBox.Show(e1.ToString());
        //            }
        //        }

        //    }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
