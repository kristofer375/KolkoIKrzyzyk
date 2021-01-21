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
        public bool isCheckedX = Form1.isComputerX;
        public bool isCheckedO = Form1.isComputerO;
        
        public Form2()
        {
            InitializeComponent();
            textBox1.Text = playerX;
            textBox2.Text = playerO;
            checkBox1.Checked = isCheckedX;
            checkBox2.Checked = isCheckedO;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            playerX = textBox1.Text;
            playerO = textBox2.Text;
            isCheckedX = checkBox1.Checked;
            isCheckedO = checkBox2.Checked;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                textBox1.Text = "Komp X";
            else
                textBox1.Text = "Gracz X";
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
                textBox2.Text = "Komp O";
            else
                textBox2.Text = "Gracz O";
        }
    }
}
