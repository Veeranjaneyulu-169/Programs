using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyMatchingGame
{
    public partial class Form1 : Form
    {
        Label firstClicked = null, secondClicked = null;
        Random random = new Random();
        List<String> icons = new List<string>()
        {
          "!", "!", "N", "N", ",", ",", "k", "k",
          "b", "b", "v", "v", "w", "w", "z", "z"
        };
        public Form1()
        {
            InitializeComponent();
            AssignIconsToSquares();
        }
        private void AssignIconsToSquares()
        {
            foreach (Control ctrl in tableLayoutPanel1.Controls)
            {
                Label cell = ctrl as Label;
                if (cell != null)
                {
                    int randomNumber = random.Next(icons.Count);
                    cell.Text = icons[randomNumber];
                    cell.ForeColor = cell.BackColor;
                    icons.RemoveAt(randomNumber);
                }
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            firstClicked.ForeColor = firstClicked.BackColor;
            secondClicked.ForeColor = secondClicked.BackColor;

            firstClicked = null;
            secondClicked = null;
        }
        private void label_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == true)
                return;
            if (secondClicked != null)
                return;
            Label clickedLabel = sender as Label;
            if (clickedLabel != null)
            {
                if (clickedLabel.ForeColor == Color.Black)
                    return;
                if (firstClicked == null)
                {
                    firstClicked = clickedLabel;
                    firstClicked.ForeColor = Color.Black;
                    return;
                }
                secondClicked = clickedLabel;
                secondClicked.ForeColor = Color.Black;

                CheckForWinner();

                if (firstClicked.Text == secondClicked.Text)
                {
                    firstClicked = null;
                    secondClicked = null;
                    return;
                }
                timer1.Start();
            }
        }
        private void CheckForWinner()
        {
            foreach (Control ctrl in tableLayoutPanel1.Controls)
            {
                Label cell = ctrl as Label;
                if (cell != null)
                {
                    if (cell.ForeColor != Color.Black)
                    {
                        return;
                    }
                }
            }
            MessageBox.Show("You have finished the game", "Congragulations");
            Close();
        }
    }
}