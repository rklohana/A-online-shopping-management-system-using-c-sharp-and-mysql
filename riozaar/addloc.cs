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
    public partial class addloc : UserControl
    {
        public addloc()
        {
            InitializeComponent();
        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            locations l = new locations();
            l.add(bunifuTextBox1.Text);
        }
    }
}
