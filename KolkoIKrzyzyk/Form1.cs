using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Threading;
using System.Timers;

namespace KolkoIKrzyzyk
{
    public partial class Form1 : Form
    {
        public static string player1 = "Gracz X";
        public static string player2 = "Gracz O";

        Button[,] gameBoard = new Button[3, 3];
        int currentTurn = 0;
        int win = 0;
        public static bool isComputerX = false;
        public static bool isComputerO = false;
        public Form1()
        {
            InitializeComponent();
            gameBoard = NewGameBoard(gameBoard);
        }
        public Button[,] NewGameBoard(Button[,] g)
        {
            g[0, 0] = button1;
            g[0, 1] = button2;
            g[0, 2] = button3;
            g[1, 0] = button4;
            g[1, 1] = button5;
            g[1, 2] = button6;
            g[2, 0] = button7;
            g[2, 1] = button8;
            g[2, 2] = button9;
            for(int i=0; i < 3; i++)
                for(int j=0; j < 3; j++)
                {
                    g[i, j].Text = " ";
                    g[i, j].BackColor = System.Drawing.Color.White;
                    g[i, j].Enabled = true;
                }
            return g;
        }
        public Button[,] PlayerMove(Button[,] g, int turn, int x, int y)
        {
            g[x, y].Text = ReturneSymbole(turn);
            g[x, y].BackColor = DetermineColor(g[x, y].Text);
            return g;
        }
        public String ReturneSymbole(int turn)
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
        public int CheckForWinner(Button[,] g)
        {
            if(zmien.Enabled == true)
                zmien.Enabled = false;
            String combination = " ";
            for(int i=1; i <10; i++)
            {
                int temp = 0;
                switch (i)
                {
                    case 1:
                        combination = g[0, 0].Text + g[0, 1].Text + g[0, 2].Text;
                        temp = 1;
                        break;
                    case 2:
                        combination = g[1, 0].Text + g[1, 1].Text + g[1, 2].Text;
                        temp = 2;
                        break;
                    case 3:
                        combination = g[2, 0].Text + g[2, 1].Text + g[2, 2].Text;
                        temp = 3;
                        break;
                    case 4:
                        combination = g[0, 0].Text + g[1, 0].Text + g[2, 0].Text;
                        temp = 4;
                        break;
                    case 5:
                        combination = g[0, 1].Text + g[1, 1].Text + g[2, 1].Text;
                        temp = 5;
                        break;
                    case 6:
                        combination = g[0, 2].Text + g[1, 2].Text + g[2, 2].Text;
                        temp = 6;
                        break;
                    case 7:
                        combination = g[0, 0].Text + g[1, 1].Text + g[2, 2].Text;
                        temp = 7;
                        break;
                    case 8:
                        combination = g[2, 0].Text + g[1, 1].Text + g[0, 2].Text;
                        temp = 8;
                        break;
                    case 9:
                        int counter = 0;
                        for (int x = 0; x < 3; x++)
                            for (int y = 0; y < 3; y++)
                                if (g[x, y].Text != " ")
                                    counter++;
                        if (counter == 9)
                            return 9;
                        break;
                }
                if (combination.Equals("OOO") || combination.Equals("XXX"))
                    return temp;
            }
            return 0;
        }
        //public void ChangeColor(int number, string symbol)
        //{
        //    switch(number)
        //    {
        //        case 0:
        //            if(symbol == "X")
        //                button1.BackColor = System.Drawing.ColorTranslator.FromHtml("#468C00");
        //            else
        //                button1.BackColor = System.Drawing.ColorTranslator.FromHtml("#009494");
        //            break;
        //        case 1:
        //            if (symbol == "X")
        //                button2.BackColor = System.Drawing.ColorTranslator.FromHtml("#468C00");
        //            else
        //                button2.BackColor = System.Drawing.ColorTranslator.FromHtml("#009494");
        //            break;
        //        case 2:
        //            if (symbol == "X")
        //                button3.BackColor = System.Drawing.ColorTranslator.FromHtml("#468C00");
        //            else
        //                button3.BackColor = System.Drawing.ColorTranslator.FromHtml("#009494");
        //            break;
        //        case 3:
        //            if (symbol == "X")
        //                button4.BackColor = System.Drawing.ColorTranslator.FromHtml("#468C00");
        //            else
        //                button4.BackColor = System.Drawing.ColorTranslator.FromHtml("#009494");
        //            break;
        //        case 4:
        //            if (symbol == "X")
        //                button5.BackColor = System.Drawing.ColorTranslator.FromHtml("#468C00");
        //            else
        //                button5.BackColor = System.Drawing.ColorTranslator.FromHtml("#009494");
        //            break;
        //        case 5:
        //            if (symbol == "X")
        //                button6.BackColor = System.Drawing.ColorTranslator.FromHtml("#468C00");
        //            else
        //                button6.BackColor = System.Drawing.ColorTranslator.FromHtml("#009494");
        //            break;
        //        case 6:
        //            if (symbol == "X")
        //                button7.BackColor = System.Drawing.ColorTranslator.FromHtml("#468C00");
        //            else
        //                button7.BackColor = System.Drawing.ColorTranslator.FromHtml("#009494");
        //            break;
        //        case 7:
        //            if (symbol == "X")
        //                button8.BackColor = System.Drawing.ColorTranslator.FromHtml("#468C00");
        //            else
        //                button8.BackColor = System.Drawing.ColorTranslator.FromHtml("#009494");
        //            break;
        //        case 8:
        //            if (symbol == "X")
        //                button9.BackColor = System.Drawing.ColorTranslator.FromHtml("#468C00");
        //            else
        //                button9.BackColor = System.Drawing.ColorTranslator.FromHtml("#009494");
        //            break;
        //    }
        //}
        public Button[,] ReColor(Button[,] g, int number)
        {
            switch(number)
            {
                case 1:
                    if(g[0, 0].Text == "X")
                    {
                        g[0, 0].BackColor = System.Drawing.ColorTranslator.FromHtml("#468C00");
                        g[0, 1].BackColor = g[0, 2].BackColor = g[0, 0].BackColor;
                    }
                    else
                    {
                        g[0, 0].BackColor = System.Drawing.ColorTranslator.FromHtml("#009494");
                        g[0, 1].BackColor = g[0, 2].BackColor = g[0, 0].BackColor;
                    }
                    break;
                case 2:
                    if (g[1, 0].Text == "X")
                    {
                        g[1, 0].BackColor = System.Drawing.ColorTranslator.FromHtml("#468C00");
                        g[1, 1].BackColor = g[1, 2].BackColor = g[1, 0].BackColor;
                    }
                    else
                    {
                        g[1, 0].BackColor = System.Drawing.ColorTranslator.FromHtml("#009494");
                        g[1, 1].BackColor = g[1, 2].BackColor = g[1, 0].BackColor;
                    }
                    break;
                case 3:
                    if (g[2, 0].Text == "X")
                    {
                        g[2, 0].BackColor = System.Drawing.ColorTranslator.FromHtml("#468C00");
                        g[2, 1].BackColor = g[2, 2].BackColor = g[2, 0].BackColor;
                    }
                    else
                    {
                        g[2, 0].BackColor = System.Drawing.ColorTranslator.FromHtml("#009494");
                        g[2, 1].BackColor = g[2, 2].BackColor = g[2, 0].BackColor;
                    }
                    break;
                case 4:
                    if (g[0, 0].Text == "X")
                    {
                        g[0, 0].BackColor = System.Drawing.ColorTranslator.FromHtml("#468C00");
                        g[1, 0].BackColor = g[2, 0].BackColor = g[0, 0].BackColor;
                    }
                    else
                    {
                        g[0, 0].BackColor = System.Drawing.ColorTranslator.FromHtml("#009494");
                        g[1, 0].BackColor = g[2, 0].BackColor = g[0, 0].BackColor;
                    }
                    break;
                case 5:
                    if (g[0, 1].Text == "X")
                    {
                        g[0, 1].BackColor = System.Drawing.ColorTranslator.FromHtml("#468C00");
                        g[1, 1].BackColor = g[2, 1].BackColor = g[0, 1].BackColor;
                    }
                    else
                    {
                        g[0, 1].BackColor = System.Drawing.ColorTranslator.FromHtml("#009494");
                        g[1, 1].BackColor = g[2, 1].BackColor = g[0, 1].BackColor;
                    }
                    break;
                case 6:
                    if (g[0, 2].Text == "X")
                    {
                        g[0, 2].BackColor = System.Drawing.ColorTranslator.FromHtml("#468C00");
                        g[1, 2].BackColor = g[2, 2].BackColor = g[0, 2].BackColor;
                    }
                    else
                    {
                        g[0, 2].BackColor = System.Drawing.ColorTranslator.FromHtml("#009494");
                        g[1, 2].BackColor = g[2, 2].BackColor = g[0, 2].BackColor;
                    }
                    break;
                case 7:
                    if (g[0, 0].Text == "X")
                    {
                        g[0, 0].BackColor = System.Drawing.ColorTranslator.FromHtml("#468C00");
                        g[1, 1].BackColor = g[2, 2].BackColor = g[0, 0].BackColor;
                    }
                    else
                    {
                        g[0, 0].BackColor = System.Drawing.ColorTranslator.FromHtml("#009494");
                        g[1, 1].BackColor = g[2, 2].BackColor = g[0, 0].BackColor;
                    }
                    break;
                case 8:
                    if (g[2, 0].Text == "X")
                    {
                        g[2, 0].BackColor = System.Drawing.ColorTranslator.FromHtml("#468C00");
                        g[1, 1].BackColor = g[0, 2].BackColor = g[2, 0].BackColor;
                    }
                    else
                    {
                        g[2, 0].BackColor = System.Drawing.ColorTranslator.FromHtml("#009494");
                        g[1, 1].BackColor = g[0, 2].BackColor = g[2, 0].BackColor;
                    }
                    break;
            }
            return g;
        }
        public void Reset()
        {
            currentTurn = 0;
            win = 0;
            zmien.Enabled = true;
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
            button1.Text = " ";
            button2.Text = " ";
            button3.Text = " ";
            button4.Text = " ";
            button5.Text = " ";
            button6.Text = " ";
            button7.Text = " ";
            button8.Text = " ";
            button9.Text = " ";
            button1.BackColor = System.Drawing.Color.White;
            button2.BackColor = System.Drawing.Color.White;
            button3.BackColor = System.Drawing.Color.White;
            button4.BackColor = System.Drawing.Color.White;
            button5.BackColor = System.Drawing.Color.White;
            button6.BackColor = System.Drawing.Color.White;
            button7.BackColor = System.Drawing.Color.White;
            button8.BackColor = System.Drawing.Color.White;
            button9.BackColor = System.Drawing.Color.White;
            gameBoard = NewGameBoard(gameBoard);
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
        public void Rounds()
        {
            if(label1.Text != "Remis!")
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
                if (win > 0 && win < 9)
                {
                    switch (currentTurn % 2)
                    {
                        case 1:
                            label1.Text += "Wygrywa " + textBox1.Text + " w ";
                            break;
                        case 0:
                            label1.Text += "Wygrywa " + textBox2.Text + " w ";
                            currentTurn--;
                            break;
                    }
                }
                switch ((currentTurn) / 2)
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
                if (win == 0)
                {
                    switch (currentTurn % 2)
                    {
                        case 0:
                            label1.Text += " - ";
                            label1.Text += textBox1.Text;
                            break;
                        case 1:
                            label1.Text += " - ";
                            label1.Text += textBox2.Text;
                            break;
                    }
                }
            }
        }
        public Button[,] ComputerMove(Button[,] g, int r, int i, int j)
        {
            for(int x=0; x < 3; x++)
            {
                for(int y=0; y < 3; y++)
                {
                    if(g[x, y].Text == g[x, (y+1)%3].Text && g[x, y].Text != " " && g[x, (y+2)%3].Text == " ")
                    {
                        g[x, (y + 2) % 3].Text = ReturneSymbole(r);
                        g[x, (y + 2) % 3].BackColor = DetermineColor(g[x, (y + 2) % 3].Text);
                        return g;
                    }else if (g[x, y].Text == g[(x + 1)%3, y].Text && g[x, y].Text != " " && g[(x + 2) % 3, y].Text == " ")
                    {
                        g[(x + 2) % 3, y].Text = ReturneSymbole(r);
                        g[(x + 2) % 3, y].BackColor = DetermineColor(g[(x + 2) % 3, y].Text);
                        return g;
                    }else if (x == y && g[x, y].Text == g[(x + 1) % 3, (y + 1) % 3].Text && g[x, y].Text != " " && g[(x + 2) % 3, (y + 2) % 3].Text == " ")
                    {
                        g[(x + 2) % 3, (y + 2) % 3].Text = ReturneSymbole(r);
                        g[(x + 2) % 3, (y + 2) % 3].BackColor = DetermineColor(g[(x + 2) % 3, (y + 2) % 3].Text);
                        return g; 
                    }else if (x + y == 2 && g[x, y].Text == g[(x + 1) % 3, (y + 2) % 3].Text && g[x, y].Text != " " && g[(x + 2) % 3, (y + 1) % 3].Text == " ")
                    {
                        g[(x + 2) % 3, (y + 1) % 3].Text = ReturneSymbole(r);
                        g[(x + 2) % 3, (y + 1) % 3].BackColor = DetermineColor(g[(x + 2) % 3, (y + 1) % 3].Text);
                        return g;
                    }
                }
            }
            Random random = new Random();
            int a;
            int b;
            do
            {
                a = random.Next(0, 3);
                b = random.Next(0, 3);

            }while (g[a, b].Text != " " || (a == i && b == j));
            g[a, b].Text = ReturneSymbole(r);
            g[a, b].BackColor = DetermineColor(g[a, b].Text);
                return g;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(button1.Text == " ")
            {
                gameBoard = PlayerMove(gameBoard, ++currentTurn, 0, 0);
                win = CheckForWinner(gameBoard);
                if (win == 0)
                {
                    if (isComputerO && currentTurn < 9)
                    {
                        gameBoard = ComputerMove(gameBoard, ++currentTurn, 0, 0);
                        win = CheckForWinner(gameBoard);
                        if (win == 0)
                        {

                        }
                        else if (win == 9)
                        {
                            ButtonSwitch();
                            label1.Text = "Remis!";
                        }
                        else
                        {
                            ButtonSwitch();
                            gameBoard = ReColor(gameBoard, win);
                        }
                    }
                }
                else if (win == 9)
                {
                    ButtonSwitch();
                    label1.Text = "Remis!";
                }
                else
                {
                    ButtonSwitch();
                    gameBoard = ReColor(gameBoard, win);
                }
                Rounds();
                if (currentTurn % 2 == 0 && isComputerX == true)
                    button11_Click(sender, e);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(button2.Text == " ")
            {
                gameBoard = PlayerMove(gameBoard, ++currentTurn, 0, 1);
                win = CheckForWinner(gameBoard);
                if (win == 0)
                {
                    if (isComputerO && currentTurn < 9)
                    {
                        gameBoard = ComputerMove(gameBoard, ++currentTurn, 0, 1);
                        win = CheckForWinner(gameBoard);
                        if (win == 0)
                        {

                        }
                        else if (win == 9)
                        {
                            ButtonSwitch();
                            label1.Text = "Remis!";
                        }
                        else
                        {
                            ButtonSwitch();
                            gameBoard = ReColor(gameBoard, win);
                        }
                    }
                }
                else if (win == 9)
                {
                    ButtonSwitch();
                    label1.Text = "Remis!";
                }
                else
                {
                    ButtonSwitch();
                    gameBoard = ReColor(gameBoard, win);
                }
                Rounds();
                if (currentTurn % 2 == 0 && isComputerX == true)
                    button11_Click(sender, e);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(button3.Text == " ")
            {
                gameBoard = PlayerMove(gameBoard, ++currentTurn, 0, 2);
                win = CheckForWinner(gameBoard);
                if (win == 0)
                {
                    if (isComputerO && currentTurn < 9)
                    {
                        gameBoard = ComputerMove(gameBoard, ++currentTurn, 0, 2);
                        win = CheckForWinner(gameBoard);
                        if (win == 0)
                        {

                        }
                        else if (win == 9)
                        {
                            ButtonSwitch();
                            label1.Text = "Remis!";
                        }
                        else
                        {
                            ButtonSwitch();
                            gameBoard = ReColor(gameBoard, win);
                        }
                    }
                }
                else if (win == 9)
                {
                    ButtonSwitch();
                    label1.Text = "Remis!";
                }
                else
                {
                    ButtonSwitch();
                    gameBoard = ReColor(gameBoard, win);
                }
                Rounds();
                if (currentTurn % 2 == 0 && isComputerX == true)
                    button11_Click(sender, e);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(button4.Text == " ")
            {
                gameBoard = PlayerMove(gameBoard, ++currentTurn, 1, 0);
                win = CheckForWinner(gameBoard);
                if (win == 0)
                {
                    if (isComputerO && currentTurn < 9)
                    {
                        gameBoard = ComputerMove(gameBoard, ++currentTurn, 1, 0);
                        win = CheckForWinner(gameBoard);
                        if (win == 0)
                        {

                        }
                        else if (win == 9)
                        {
                            ButtonSwitch();
                            label1.Text = "Remis!";
                        }
                        else
                        {
                            ButtonSwitch();
                            gameBoard = ReColor(gameBoard, win);
                        }
                    }
                }
                else if (win == 9)
                {
                    ButtonSwitch();
                    label1.Text = "Remis!";
                }
                else
                {
                    ButtonSwitch();
                    gameBoard = ReColor(gameBoard, win);
                }
                Rounds();
                if (currentTurn % 2 == 0 && isComputerX == true)
                    button11_Click(sender, e);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(button5.Text == " ")
            {
                gameBoard = PlayerMove(gameBoard, ++currentTurn, 1, 1);
                win = CheckForWinner(gameBoard);
                if (win == 0)
                {
                    if (isComputerO && currentTurn < 9)
                    {
                        gameBoard = ComputerMove(gameBoard, ++currentTurn, 1, 1);
                        win = CheckForWinner(gameBoard);
                        if (win == 0)
                        {

                        }
                        else if (win == 9)
                        {
                            ButtonSwitch();
                            label1.Text = "Remis!";
                        }
                        else
                        {
                            ButtonSwitch();
                            gameBoard = ReColor(gameBoard, win);
                        }
                    }
                }
                else if (win == 9)
                {
                    ButtonSwitch();
                    label1.Text = "Remis!";
                }
                else
                {
                    ButtonSwitch();
                    gameBoard = ReColor(gameBoard, win);
                }
                Rounds();
                if (currentTurn % 2 == 0 && isComputerX == true)
                    button11_Click(sender, e);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if(button6.Text == " ")
            {
                gameBoard = PlayerMove(gameBoard, ++currentTurn, 1, 2);
                win = CheckForWinner(gameBoard);
                if (win == 0)
                {
                    if (isComputerO && currentTurn < 9)
                    {
                        gameBoard = ComputerMove(gameBoard, ++currentTurn, 1, 2);
                        win = CheckForWinner(gameBoard);
                        if (win == 0)
                        {

                        }
                        else if (win == 9)
                        {
                            ButtonSwitch();
                            label1.Text = "Remis!";
                        }
                        else
                        {
                            ButtonSwitch();
                            gameBoard = ReColor(gameBoard, win);
                        }
                    }
                }
                else if (win == 9)
                {
                    ButtonSwitch();
                    label1.Text = "Remis!";
                }
                else
                {
                    ButtonSwitch();
                    gameBoard = ReColor(gameBoard, win);
                }
                Rounds();
                if (currentTurn % 2 == 0 && isComputerX == true)
                    button11_Click(sender, e);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if(button7.Text == " ")
            {
                gameBoard = PlayerMove(gameBoard, ++currentTurn, 2, 0);
                win = CheckForWinner(gameBoard);
                if (win == 0)
                {
                    if (isComputerO && currentTurn < 9)
                    {
                        gameBoard = ComputerMove(gameBoard, ++currentTurn, 2, 0);
                        win = CheckForWinner(gameBoard);
                        if (win == 0)
                        {

                        }
                        else if (win == 9)
                        {
                            ButtonSwitch();
                            label1.Text = "Remis!";
                        }
                        else
                        {
                            ButtonSwitch();
                            gameBoard = ReColor(gameBoard, win);
                        }
                    }
                }
                else if (win == 9)
                {
                    ButtonSwitch();
                    label1.Text = "Remis!";
                }
                else
                {
                    ButtonSwitch();
                    gameBoard = ReColor(gameBoard, win);
                }
                Rounds();
                if (currentTurn % 2 == 0 && isComputerX == true)
                    button11_Click(sender, e);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if(button8.Text == " ")
            {
                gameBoard = PlayerMove(gameBoard, ++currentTurn, 2, 1);
                win = CheckForWinner(gameBoard);
                if (win == 0)
                {
                    if (isComputerO && currentTurn < 9)
                    {
                        gameBoard = ComputerMove(gameBoard, ++currentTurn, 2, 1);
                        win = CheckForWinner(gameBoard);
                        if (win == 0)
                        {

                        }
                        else if (win == 9)
                        {
                            ButtonSwitch();
                            label1.Text = "Remis!";
                        }
                        else
                        {
                            ButtonSwitch();
                            gameBoard = ReColor(gameBoard, win);
                        }
                    }
                }
                else if (win == 9)
                {
                    ButtonSwitch();
                    label1.Text = "Remis!";
                }
                else
                {
                    ButtonSwitch();
                    gameBoard = ReColor(gameBoard, win);
                }
                Rounds();
                if (currentTurn % 2 == 0 && isComputerX == true)
                    button11_Click(sender, e);
            }

        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (button9.Text == " ")
            {
                gameBoard = PlayerMove(gameBoard, ++currentTurn, 2, 2);
                win = CheckForWinner(gameBoard);
                if (win == 0)
                {
                    if (isComputerO && currentTurn < 9)
                    {
                        gameBoard = ComputerMove(gameBoard, ++currentTurn, 2, 2);
                        win = CheckForWinner(gameBoard);
                        if (win == 0)
                        {

                        }
                        else if (win == 9)
                        {
                            ButtonSwitch();
                            label1.Text = "Remis!";
                        }
                        else
                        {
                            ButtonSwitch();
                            gameBoard = ReColor(gameBoard, win);
                        }
                    }
                }
                else if (win == 9)
                {
                    ButtonSwitch();
                    label1.Text = "Remis!";
                }
                else
                {
                    ButtonSwitch();
                    gameBoard = ReColor(gameBoard, win);
                }
                Rounds();
                if (currentTurn % 2 == 0 && isComputerX == true)
                    button11_Click(sender, e);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Reset();
            if (isComputerX == true)
            {
                ButtonSwitch();
                button11.Visible = true;
            }
        }

        private void nowaGraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void oProgramieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Kółko i krzyżyk\n\nAutor: Krzysztof Żmuda\nWersja: 2.2\nRok Wydania: 2021", "O programie", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void zmien_Click(object sender, EventArgs e)
        {
            using (Form2 form2 = new Form2())
            {
                form2.playerX = textBox1.Text;
                form2.playerO = textBox2.Text;
                if (form2.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    player1 = textBox1.Text = form2.playerX;
                    player2 = textBox2.Text = form2.playerO;
                    Reset();
                    isComputerX = form2.isCheckedX;
                    if (isComputerX)
                    {
                        button11.Visible = true;
                        ButtonSwitch();
                    }
                    else
                        button11.Visible = false;
                    isComputerO = form2.isCheckedO;
                    label1.Text = "Runda nr 1 - " + textBox1.Text;
                }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            button11.Visible = false;
            if(currentTurn == 0)
                ButtonSwitch();
            gameBoard = ComputerMove(gameBoard, ++currentTurn, 3, 3);
            win = CheckForWinner(gameBoard);
            Application.DoEvents();
            Thread.Sleep(1000);
            if (win == 0)
            {
                if (isComputerO == true)
                {
                    Rounds();
                    button11_Click(sender, e);
                }
            }
            else if (win == 9)
            {
                ButtonSwitch();
                label1.Text = "Remis!";
            }
            else
            {
                ButtonSwitch();
                gameBoard = ReColor(gameBoard, win);
            }
            Rounds();
        }
    }
}
