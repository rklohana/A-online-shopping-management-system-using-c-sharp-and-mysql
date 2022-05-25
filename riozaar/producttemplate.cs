using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace riozaar
{
    public partial class producttemplate : UserControl
    {
        Image ir;
        Bitmap b;
        public producttemplate()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog on = new OpenFileDialog();
            on.Title = "Photo";
            on.Filter = "Image (jpg,jpeg,png) | *.jpg;*.jpeg;*.png|all files|*.*";
            if (on.ShowDialog() == DialogResult.OK)
            {
                b = new Bitmap(on.FileName);
                 ir = new Bitmap(on.FileName);
                pictureBox1.Image = ir.GetThumbnailImage(128, 130, null, new IntPtr());
            }
            product p = new product();
            MessageBox.Show(p.photoconvert(b).Length.ToString());
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            product p = new product();
            p.setdata("2", textBox1.Text, p.photoconvert(b), textBox2.Text, float.Parse(textBox5.Text),decimal.ToInt32( numericUpDown1.Value));
            p.add();
            Console.WriteLine(float.Parse(textBox5.Text)+" \n");
        }
    }
}
