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
    public partial class ModalDialog : Form
    {
        public ModalDialog()
        {
            InitializeComponent();
        }
        public int Time
        {
            get
            {
                return (int)numericUpDownTime.Value;
            }
            set
            {
                numericUpDownTime.Value = value;
            }
        }
        public int Width
        {
            get
            {
                
                return (int)numericUpDownCWidth.Value;
            }
            set
            {
                numericUpDownCWidth.Value = value;
            }
        }
        public int Height
        {
            get
            {
                return (int)numericUpDownCHeight.Value;
            }
            set
            {
                numericUpDownCHeight.Value = value;
            }
        }


    }
}
