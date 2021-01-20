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
        public string graczx = Form1.gracz1;
        public string graczo = Form1.gracz2;
        
        public Form2()
        {
            InitializeComponent();
            textBox1.Text = graczx;
            textBox2.Text = graczo;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            graczx = textBox1.Text;
            graczo = textBox2.Text;
        }
    }
}
