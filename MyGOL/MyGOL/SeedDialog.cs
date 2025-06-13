using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyGOL
{
    public partial class SeedDialog : Form
    {

        public int seed
        {
            get
            {
                return (int)numericUpDownSeed.Value;
            }
            set
            {
                numericUpDownSeed.Value = value;
            }
        }
        public SeedDialog()
        {
            InitializeComponent();
            numericUpDownSeed.Maximum = 1200000;
            numericUpDownSeed.Minimum = -1200000;
        }

        private void SeedOk_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random R = new Random();

            seed = R.Next(-1200000 , 1200000) ;
        }
    }
}
