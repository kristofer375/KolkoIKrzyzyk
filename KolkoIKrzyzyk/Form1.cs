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
        public String ReturneSymble(int turn)
        {
            if(turn % 2 == 1)
                return "X";
            return "O";
        }
        public System.Drawing.Color DetermineColor(String symbol)
        {
            if(symbol.Equals("O"))
            {
                return System.Drawing.Color.Aqua;
            } else if(symbol.Equals("X"))
            {
                return System.Drawing.Color.Chartreuse;
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
                    ChangeColor(one);
                    ChangeColor(two);
                    ChangeColor(three);
                    MessageBox.Show("O wygrało grę!", "Mamy zwycięzce", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
                } else if (combination.Equals("XXX"))
                {
                    ChangeColor(one);
                    ChangeColor(two);
                    ChangeColor(three);
                    MessageBox.Show("X wygrało grę!", "mamy zwycięzce", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                    MessageBox.Show("Remis!", "Brak zwycięzcy", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
        public void ChangeColor(int number)
        {
            switch(number)
            {
                case 0:
                    button1.BackColor = System.Drawing.Color.Red;
                    break;
                case 1:
                    button2.BackColor = System.Drawing.Color.Red;
                    break;
                case 2:
                    button3.BackColor = System.Drawing.Color.Red;
                    break;
                case 3:
                    button4.BackColor = System.Drawing.Color.Red;
                    break;
                case 4:
                    button5.BackColor = System.Drawing.Color.Red;
                    break;
                case 5:
                    button6.BackColor = System.Drawing.Color.Red;
                    break;
                case 6:
                    button7.BackColor = System.Drawing.Color.Red;
                    break;
                case 7:
                    button8.BackColor = System.Drawing.Color.Red;
                    break;
                case 8:
                    button9.BackColor = System.Drawing.Color.Red;
                    break;
            }
        }
        public void Reset()
        {
            currentTurn = 0;
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

        private void button1_Click(object sender, EventArgs e)
        {
            currentTurn++;
            gameBoard[0] = ReturneSymble(currentTurn);
            Color buttonColor = DetermineColor(gameBoard[0]);
            button1.BackColor = buttonColor;
            button1.Text = gameBoard[0];
            ChechForWinner();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            currentTurn++;
            gameBoard[1] = ReturneSymble(currentTurn);
            Color buttonColor = DetermineColor(gameBoard[1]);
            button2.BackColor = buttonColor;
            button2.Text = gameBoard[1];
            ChechForWinner();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            currentTurn++;
            gameBoard[2] = ReturneSymble(currentTurn);
            Color buttonColor = DetermineColor(gameBoard[2]);
            button3.BackColor = buttonColor;
            button3.Text = gameBoard[2];
            ChechForWinner();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            currentTurn++;
            gameBoard[3] = ReturneSymble(currentTurn);
            Color buttonColor = DetermineColor(gameBoard[3]);
            button4.BackColor = buttonColor;
            button4.Text = gameBoard[3];
            ChechForWinner();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            currentTurn++;
            gameBoard[4] = ReturneSymble(currentTurn);
            Color buttonColor = DetermineColor(gameBoard[4]);
            button5.BackColor = buttonColor;
            button5.Text = gameBoard[4];
            ChechForWinner();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            currentTurn++;
            gameBoard[5] = ReturneSymble(currentTurn);
            Color buttonColor = DetermineColor(gameBoard[5]);
            button6.BackColor = buttonColor;
            button6.Text = gameBoard[5];
            ChechForWinner();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            currentTurn++;
            gameBoard[6] = ReturneSymble(currentTurn);
            Color buttonColor = DetermineColor(gameBoard[6]);
            button7.BackColor = buttonColor;
            button7.Text = gameBoard[6];
            ChechForWinner();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            currentTurn++;
            gameBoard[7] = ReturneSymble(currentTurn);
            Color buttonColor = DetermineColor(gameBoard[7]);
            button8.BackColor = buttonColor;
            button8.Text = gameBoard[7];
            ChechForWinner();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            currentTurn++;
            gameBoard[8] = ReturneSymble(currentTurn);
            Color buttonColor = DetermineColor(gameBoard[8]);
            button9.BackColor = buttonColor;
            button9.Text = gameBoard[8];
            ChechForWinner();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Reset();
        }
    }
}
