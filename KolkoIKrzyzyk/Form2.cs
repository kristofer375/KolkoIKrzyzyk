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
        public string playerX = Form1.player1;
        public string playerO = Form1.player2;
        public bool isChecked = Form1.isComputer;
        
        public Form2()
        {
            InitializeComponent();
            textBox1.Text = playerX;
            textBox2.Text = playerO;
            checkBox1.Checked = isChecked;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            playerX = textBox1.Text;
            playerO = textBox2.Text;
            isChecked = checkBox1.Checked;
        }
    }
}
