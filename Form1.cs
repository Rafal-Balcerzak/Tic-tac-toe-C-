﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kolko_i_krzyzyk
{
    public partial class Form1 : Form
    {
        List<Button> buttons = new List<Button>();
        private readonly Random random = new Random();      
        bool isXorY = true;
        int valueScorePlayer1 = 0;
        int valueScorePlayer2 = 0;
        bool isSinglePlayer = false;

        public Form1()
        {
            InitializeComponent();
        }

        public int RandomNumber(int min, int max)
        {
            return random.Next(min, max);
        }

        private void ClickButton(object sender, EventArgs e)
        {
            
            Button btn = sender as Button;
            
            btn.Text = isXorY ? "x" : "o";
            btn.Enabled = false;
            PlayerTurn.Text = isXorY ? "Kolej gracza 2" : "Kolej gracza 1";
            isXorY ^= true;

            checkWin();
            if (isSinglePlayer && !isXorY)
            {
                buttons.Remove(btn);
                Task.Delay(1500).Wait();
                randomMove();
            }
            
        }
        public void ResetFields()
        {
            
            button7.Text = string.Empty;
            button8.Text = string.Empty;
            button9.Text = string.Empty;
            button2.Text = string.Empty;
            button3.Text = string.Empty;
            button4.Text = string.Empty;
            button6.Text = string.Empty;
            button5.Text = string.Empty;
            button1.Text = string.Empty;

            button7.BackColor = Color.SpringGreen;
            button8.BackColor = Color.SpringGreen;
            button9.BackColor = Color.SpringGreen;
            button2.BackColor = Color.SpringGreen;
            button3.BackColor = Color.SpringGreen;
            button4.BackColor = Color.SpringGreen;
            button6.BackColor = Color.SpringGreen;
            button5.BackColor = Color.SpringGreen;
            button1.BackColor = Color.SpringGreen;

            addButtonsToList();
        }
        public void TurnOnButtons()
        {
            button8.Enabled = true;
            button9.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button6.Enabled = true;
            button5.Enabled = true;
            button1.Enabled = true;
            button7.Enabled = true;
        }
        public void TurnOffButtons()
        {
            button8.Enabled = false;
            button9.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button6.Enabled = false;
            button5.Enabled = false;
            button1.Enabled = false;
            button7.Enabled = false;
        }

        private void newGame_Click(object sender, EventArgs e)
        {
            ResetFields();
            TurnOnButtons();

        }
        public void checkWin(){
            check3Fields(button1, button2, button3);
            check3Fields(button4, button5, button6);
            check3Fields(button7, button8, button9);
            check3Fields(button1, button4, button7);
            check3Fields(button2, button5, button8);
            check3Fields(button3, button6, button9);
            check3Fields(button1, button5, button9);
            check3Fields(button3, button5, button7);
        }
        public Boolean check3Fields(Button button1,Button button2, Button button3)
        {
            if (button1.Text.Equals(button2.Text) && button2.Text.Equals(button3.Text) && !button1.Text.Equals(string.Empty) && !button2.Equals(string.Empty) && !button3.Equals(string.Empty))
            {
                addButtonsToList();
                button1.BackColor = Color.Red;
                button2.BackColor = Color.Red;
                button3.BackColor = Color.Red;
                TurnOffButtons();
                PlayerTurn.Text = isXorY ? "Wygrał Gracz 2" : "Wygrał Gracz 1";
                if (isXorY)
                {
                    valueScorePlayer2++;
                    scorePlayer1.Text = valueScorePlayer1.ToString();
                    scorePlayer2.Text =  valueScorePlayer2.ToString();
                }
                else
                {
                    valueScorePlayer1++;
                    scorePlayer1.Text = valueScorePlayer1.ToString();
                    scorePlayer2.Text = valueScorePlayer2.ToString();
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        private void SinglePlayerButton_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            SInglePlayerButton.Visible = false;
            MultiplayerButton.Visible = false;
            isSinglePlayer = true;

            addButtonsToList();
        }

        private void MultiplayerButton_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            SInglePlayerButton.Visible = false;
            MultiplayerButton.Visible = false;   
        }

        public void randomMove()
        {
            int buttonIndex = RandomNumber(0, buttons.Count - 1);
            buttons[buttonIndex].Text = "o";
            buttons[buttonIndex].Enabled = false;
            buttons.RemoveAt(buttonIndex);

            PlayerTurn.Text = isXorY ? "Kolej gracza 2" : "Kolej gracza 1";
            isXorY ^= true;
            checkWin();
        }

        public void addButtonsToList()
        {
            buttons.Clear();
            buttons.Add(button1);
            buttons.Add(button2);
            buttons.Add(button3);
            buttons.Add(button4);
            buttons.Add(button5);
            buttons.Add(button6);
            buttons.Add(button7);
            buttons.Add(button8);
            buttons.Add(button9);
        }
        
    }
}
    