using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KolkoIKrzyzyk
{
    public partial class Form2 : Form
    {
        public string graczx = "Gracz X";
        public string graczo = "Gracz O";
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            graczx = textBox1.Text;
            graczo = textBox2.Text;
        }
    }
}
