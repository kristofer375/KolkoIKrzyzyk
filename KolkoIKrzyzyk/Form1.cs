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
        public void ChechForWinner()
        {
            for(int i=0; i <8; i++)
            {
                String combination = "";
                switch(i)
                {
                    case 0:
                        combination = gameBoard[0] + gameBoard[4] + gameBoard[8];
                        break;
                    case 1:
                        combination = gameBoard[2] + gameBoard[4] + gameBoard[6];
                        break;
                    case 2:
                        combination = gameBoard[0] + gameBoard[1] + gameBoard[2];
                        break;
                    case 3:
                        combination = gameBoard[3] + gameBoard[4] + gameBoard[5];
                        break;
                    case 4:
                        combination = gameBoard[6] + gameBoard[7] + gameBoard[8];
                        break;
                    case 5:
                        combination = gameBoard[0] + gameBoard[3] + gameBoard[6];
                        break;
                    case 6:
                        combination = gameBoard[1] + gameBoard[4] + gameBoard[7];
                        break;
                    case 7:
                        combination = gameBoard[2] + gameBoard[5] + gameBoard[8];
                        break;
                }

                ChechDraw();

                if(combination.Equals("OOO"))
                {
                    Reset();
                    MessageBox.Show("O wygrało grę!", "Mamy zwycięzce", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                } else if (combination.Equals("XXX"))
                {
                    Reset();
                    MessageBox.Show("X wygrało grę!", "mamy zwycięzce", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                    Reset();
                    MessageBox.Show("Remis!", "Brak zwycięzcy", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
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
            gameBoard = new string[9];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            currentTurn++;
            gameBoard[0] = ReturneSymble(currentTurn);
            button1.Text = gameBoard[0];
            ChechForWinner();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            currentTurn++;
            gameBoard[1] = ReturneSymble(currentTurn);
            button2.Text = gameBoard[1];
            ChechForWinner();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            currentTurn++;
            gameBoard[2] = ReturneSymble(currentTurn);
            button3.Text = gameBoard[2];
            ChechForWinner();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            currentTurn++;
            gameBoard[3] = ReturneSymble(currentTurn);
            button4.Text = gameBoard[3];
            ChechForWinner();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            currentTurn++;
            gameBoard[4] = ReturneSymble(currentTurn);
            button5.Text = gameBoard[4];
            ChechForWinner();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            currentTurn++;
            gameBoard[5] = ReturneSymble(currentTurn);
            button6.Text = gameBoard[5];
            ChechForWinner();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            currentTurn++;
            gameBoard[6] = ReturneSymble(currentTurn);
            button7.Text = gameBoard[6];
            ChechForWinner();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            currentTurn++;
            gameBoard[7] = ReturneSymble(currentTurn);
            button8.Text = gameBoard[7];
            ChechForWinner();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            currentTurn++;
            gameBoard[8] = ReturneSymble(currentTurn);
            button9.Text = gameBoard[8];
            ChechForWinner();
        }
    }
}
