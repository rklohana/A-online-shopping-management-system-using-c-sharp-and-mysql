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
                Image ir = new Bitmap(on.FileName);
                pictureBox1.Image = ir.GetThumbnailImage(128, 130, null, new IntPtr());
            }
        }
    }
}
