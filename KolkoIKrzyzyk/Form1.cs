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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        String[] gameBoard = new string[9];
        int currentTurn = 0;
        bool wygrana = false;
        public String ReturneSymble(int turn)
        {
            if(turn % 2 == 1)
                return "X";
            return "O";
        }
        public Color DetermineColor(String symbol)
        {
            if(symbol.Equals("O"))
            {
                return ColorTranslator.FromHtml("#00FFFF");
            } else if(symbol.Equals("X"))
            {
                return ColorTranslator.FromHtml("#7FFF00");
            }
            return System.Drawing.Color.White;
        }
        public void ChechForWinner()
        {
            
            for(int i=0; i <8; i++)
            {
                String combination = "";
                int one = 0, two = 0, three = 0;
                switch (i)
                {
                    case 0:
                        combination = gameBoard[0] + gameBoard[4] + gameBoard[8];
                        one = 0;
                        two = 4;
                        three = 8;
                        break;
                    case 1:
                        combination = gameBoard[2] + gameBoard[4] + gameBoard[6];
                        one = 2;
                        two = 4;
                        three = 6;
                        break;
                    case 2:
                        combination = gameBoard[0] + gameBoard[1] + gameBoard[2];
                        one = 0;
                        two = 1;
                        three = 2;
                        break;
                    case 3:
                        combination = gameBoard[3] + gameBoard[4] + gameBoard[5];
                        one = 3;
                        two = 4;
                        three = 5;
                        break;
                    case 4:
                        combination = gameBoard[6] + gameBoard[7] + gameBoard[8];
                        one = 6;
                        two = 7;
                        three = 8;
                        break;
                    case 5:
                        combination = gameBoard[0] + gameBoard[3] + gameBoard[6];
                        one = 0;
                        two = 3;
                        three = 6;
                        break;
                    case 6:
                        combination = gameBoard[1] + gameBoard[4] + gameBoard[7];
                        one = 1;
                        two = 4;
                        three = 7;
                        break;
                    case 7:
                        combination = gameBoard[2] + gameBoard[5] + gameBoard[8];
                        one = 2;
                        two = 5;
                        three = 8;
                        break;
                }

                

                if(combination.Equals("OOO"))
                {
                    ButtonSwitch();
                    ChangeColor(one, "O");
                    ChangeColor(two, "O");
                    ChangeColor(three, "O");
                    wygrana = true;
                    break;
                } else if (combination.Equals("XXX"))
                {
                    ButtonSwitch();
                    ChangeColor(one, "X");
                    ChangeColor(two, "X");
                    ChangeColor(three, "X");
                    wygrana = true;
                    break;
                } else if (i == 7)
                {
                    ChechDraw();
                }
            }
        }

        public void ChechDraw()
        {
            int counter = 0;
            for(int i = 0; i < gameBoard.Length; i++)
            {
                if(gameBoard[i] != null)
                    counter++;
                if(counter == 9)
                {
                    ButtonSwitch();
                    label1.Text = "Remis";
                }
            }
        }
        public void ChangeColor(int number, string symbol)
        {
            switch(number)
            {
                case 0:
                    if(symbol == "X")
                        button1.BackColor = System.Drawing.ColorTranslator.FromHtml("#468C00");
                    else
                        button1.BackColor = System.Drawing.ColorTranslator.FromHtml("#009494");
                    break;
                case 1:
                    if (symbol == "X")
                        button2.BackColor = System.Drawing.ColorTranslator.FromHtml("#468C00");
                    else
                        button2.BackColor = System.Drawing.ColorTranslator.FromHtml("#009494");
                    break;
                case 2:
                    if (symbol == "X")
                        button3.BackColor = System.Drawing.ColorTranslator.FromHtml("#468C00");
                    else
                        button3.BackColor = System.Drawing.ColorTranslator.FromHtml("#009494");
                    break;
                case 3:
                    if (symbol == "X")
                        button4.BackColor = System.Drawing.ColorTranslator.FromHtml("#468C00");
                    else
                        button4.BackColor = System.Drawing.ColorTranslator.FromHtml("#009494");
                    break;
                case 4:
                    if (symbol == "X")
                        button5.BackColor = System.Drawing.ColorTranslator.FromHtml("#468C00");
                    else
                        button5.BackColor = System.Drawing.ColorTranslator.FromHtml("#009494");
                    break;
                case 5:
                    if (symbol == "X")
                        button6.BackColor = System.Drawing.ColorTranslator.FromHtml("#468C00");
                    else
                        button6.BackColor = System.Drawing.ColorTranslator.FromHtml("#009494");
                    break;
                case 6:
                    if (symbol == "X")
                        button7.BackColor = System.Drawing.ColorTranslator.FromHtml("#468C00");
                    else
                        button7.BackColor = System.Drawing.ColorTranslator.FromHtml("#009494");
                    break;
                case 7:
                    if (symbol == "X")
                        button8.BackColor = System.Drawing.ColorTranslator.FromHtml("#468C00");
                    else
                        button8.BackColor = System.Drawing.ColorTranslator.FromHtml("#009494");
                    break;
                case 8:
                    if (symbol == "X")
                        button9.BackColor = System.Drawing.ColorTranslator.FromHtml("#468C00");
                    else
                        button9.BackColor = System.Drawing.ColorTranslator.FromHtml("#009494");
                    break;
            }
        }
        public void Reset()
        {
            currentTurn = 0;
            wygrana = false;
            label1.Text = "Runda nr 1 - Gracz X";
            textBox1.BorderStyle = BorderStyle.Fixed3D;
            textBox2.BorderStyle = BorderStyle.None;
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
            button1.Text = "";
            button2.Text = "";
            button3.Text = "";
            button4.Text = "";
            button5.Text = "";
            button6.Text = "";
            button7.Text = "";
            button8.Text = "";
            button9.Text = "";
            button1.BackColor = System.Drawing.Color.White;
            button2.BackColor = System.Drawing.Color.White;
            button3.BackColor = System.Drawing.Color.White;
            button4.BackColor = System.Drawing.Color.White;
            button5.BackColor = System.Drawing.Color.White;
            button6.BackColor = System.Drawing.Color.White;
            button7.BackColor = System.Drawing.Color.White;
            button8.BackColor = System.Drawing.Color.White;
            button9.BackColor = System.Drawing.Color.White;
            gameBoard = new string[9];
        }
        public void ButtonSwitch()
        {
            button1.Enabled = !button1.Enabled;
            button2.Enabled = !button2.Enabled;
            button3.Enabled = !button3.Enabled;
            button4.Enabled = !button4.Enabled;
            button5.Enabled = !button5.Enabled;
            button6.Enabled = !button6.Enabled;
            button7.Enabled = !button7.Enabled;
            button8.Enabled = !button8.Enabled;
            button9.Enabled = !button9.Enabled;
        }
        public void Rundy()
        {
            if(label1.Text != "Remis")
            {
                label1.Text = "";
                if (textBox1.BorderStyle == BorderStyle.None)
                {
                    textBox1.BorderStyle = BorderStyle.Fixed3D;
                    textBox2.BorderStyle = BorderStyle.None;
                }
                else
                {
                    textBox1.BorderStyle = BorderStyle.None;
                    textBox2.BorderStyle = BorderStyle.Fixed3D;
                }
                if (wygrana)
                {
                    switch (currentTurn % 2)
                    {
                        case 0:
                            label1.Text += "Wygrał Gracz O w ";
                            break;
                        case 1:
                            label1.Text += "Wygrał Gracz X w ";
                            break;
                    }
                }
                switch ((currentTurn-1) / 2)
                {
                    case 0:
                        label1.Text += "Runda nr 1";
                        break;
                    case 1:
                        label1.Text += "Runda nr 2";
                        break;
                    case 2:
                        label1.Text += "Runda nr 3";
                        break;
                    case 3:
                        label1.Text += "Runda nr 4";
                        break;
                    case 4:
                        label1.Text += "Runda nr 5";
                        break;
                }
                if (!wygrana)
                {
                    switch (currentTurn % 2)
                    {
                        case 0:
                            label1.Text += " - Gracz X";
                            break;
                        case 1:
                            label1.Text += " - Gracz O";
                            break;
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            currentTurn++;
            gameBoard[0] = ReturneSymble(currentTurn);
            Color buttonColor = DetermineColor(gameBoard[0]);
            button1.BackColor = buttonColor;
            button1.Text = gameBoard[0];
            ChechForWinner();
            Rundy();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            currentTurn++;
            gameBoard[1] = ReturneSymble(currentTurn);
            Color buttonColor = DetermineColor(gameBoard[1]);
            button2.BackColor = buttonColor;
            button2.Text = gameBoard[1];
            ChechForWinner();
            Rundy();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            currentTurn++;
            gameBoard[2] = ReturneSymble(currentTurn);
            Color buttonColor = DetermineColor(gameBoard[2]);
            button3.BackColor = buttonColor;
            button3.Text = gameBoard[2];
            ChechForWinner();
            Rundy();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            currentTurn++;
            gameBoard[3] = ReturneSymble(currentTurn);
            Color buttonColor = DetermineColor(gameBoard[3]);
            button4.BackColor = buttonColor;
            button4.Text = gameBoard[3];
            ChechForWinner();
            Rundy();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            currentTurn++;
            gameBoard[4] = ReturneSymble(currentTurn);
            Color buttonColor = DetermineColor(gameBoard[4]);
            button5.BackColor = buttonColor;
            button5.Text = gameBoard[4];
            ChechForWinner();
            Rundy();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            currentTurn++;
            gameBoard[5] = ReturneSymble(currentTurn);
            Color buttonColor = DetermineColor(gameBoard[5]);
            button6.BackColor = buttonColor;
            button6.Text = gameBoard[5];
            ChechForWinner();
            Rundy();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            currentTurn++;
            gameBoard[6] = ReturneSymble(currentTurn);
            Color buttonColor = DetermineColor(gameBoard[6]);
            button7.BackColor = buttonColor;
            button7.Text = gameBoard[6];
            ChechForWinner();
            Rundy();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            currentTurn++;
            gameBoard[7] = ReturneSymble(currentTurn);
            Color buttonColor = DetermineColor(gameBoard[7]);
            button8.BackColor = buttonColor;
            button8.Text = gameBoard[7];
            ChechForWinner();
            Rundy();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            currentTurn++;
            gameBoard[8] = ReturneSymble(currentTurn);
            Color buttonColor = DetermineColor(gameBoard[8]);
            button9.BackColor = buttonColor;
            button9.Text = gameBoard[8];
            ChechForWinner();
            Rundy();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void nowaGraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void oProgramieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Kółko i krzyżyk\n\nAutor: Krzysztof Żmuda\nWersja: 2\nRok Wydania: 2021", "O programie", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
