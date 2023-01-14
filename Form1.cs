using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe_2._0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //data members
        bool Xturn = true;              //flag for the turn of x player
        byte numOfPlays = 0;            //keep track of number of turns in case of draw it will be 9
        short Oscore = 0, Xscore = 0;   //counter for each player score

        private void Buttun_CLick(object sender, EventArgs e)
        {
            Button b = (Button)sender;

            //check if the button was pressed before
            if (b.Text != "")
                return;

            //assign the button color and text acorrding to the player turn
            if (Xturn)
            {
                b.Text = "X";
                b.ForeColor = System.Drawing.Color.WhiteSmoke;
            }
            else
            {
                b.Text = "O";
                b.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(162)))), ((int)(((byte)(0))))); ;
            }

            numOfPlays++;
            checkforwinner();
            Xturn = !Xturn;     //switch turn
        }

        private void checkforwinner()
        {
            bool thereisawinner = false;
            //
            //Horizental check
            //
            if ((button_A1.Text == button_A2.Text) & (button_A2.Text == button_A3.Text) & (button_A1.Text != ""))
                thereisawinner = true;
            else if ((button_B1.Text == button_B2.Text) & (button_B2.Text == button_B3.Text) & (button_B1.Text != ""))
                thereisawinner = true;
            else if ((button_C1.Text == button_C2.Text) & (button_C2.Text == button_C3.Text) & (button_C1.Text != ""))
                thereisawinner = true;
            //
            //Vertical check
            //
            else if ((button_A1.Text == button_B1.Text) & (button_B1.Text == button_C1.Text) & (button_A1.Text != ""))
                thereisawinner = true;
            else if ((button_A2.Text == button_B2.Text) & (button_B2.Text == button_C2.Text) & (button_A2.Text != ""))
                thereisawinner = true;
            else if ((button_A3.Text == button_B3.Text) & (button_B3.Text == button_C3.Text) & (button_A3.Text != ""))
                thereisawinner = true;
            //
            //Diagonal check
            //
            else if ((button_A1.Text == button_B2.Text) & (button_B2.Text == button_C3.Text) & (button_A1.Text != ""))
                thereisawinner = true;
            else if ((button_C1.Text == button_B2.Text) & (button_B2.Text == button_A3.Text) & (button_C1.Text != ""))
                thereisawinner = true;
            
            if (thereisawinner)
            {
                string winner = "";
                if (Xturn)
                {
                    Xscore++;
                    winner = "X";
                }
                else
                {
                    Oscore++;
                    winner = "O";
                }

                Xturn = !Xturn;     //return the position for the winner
                update_Score();     //update the score board in the GUI

                MessageBox.Show("player " + winner + " wins.", "Yah", MessageBoxButtons.OK);

                clear_Buttons_Text_and_Recount_Plays();         //clear the text of all the buttons 
            }

            else if (numOfPlays == 9)
            {
                MessageBox.Show("Draw!", "OOPS");
                clear_Buttons_Text_and_Recount_Plays();         //clear the text of all the buttons
            }
        }

        private void update_Score()
        {
            scorex.Text = Xscore.ToString();
            scoreo.Text = Oscore.ToString();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tic Tac Toe 2.0\n" + "@2022 Mostafa Wahiep", "About Tic Tac Toe", MessageBoxButtons.OK);
        }

        private void newgameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Xturn = true;
            Xscore = Oscore = 0;
            clear_Buttons_Text_and_Recount_Plays();
            update_Score();
        }

        private void clear_Buttons_Text_and_Recount_Plays()
        {
            foreach (Control b in Controls)
            {
                if (b is Button)
                    b.Text = null;
            }
            numOfPlays = 0;
        }
    }
}