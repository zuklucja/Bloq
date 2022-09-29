using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsLab
{
    public partial class NewDiagramWindow : Form
    {
        public int CanvasHeight { get; private set; }
        public int CanvasWidth { get; private set; }
        public bool Change { get; private set; } = false;

        public NewDiagramWindow()
        {
            InitializeComponent();
            CanvasHeight = (int)numericUpDown2.Value;
            CanvasWidth = (int)numericUpDown1.Value;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            CanvasHeight = (int)numericUpDown2.Value;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            CanvasWidth = (int)numericUpDown1.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Change = true;
            Close();
        }
    }
}
