using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlappyBird
{
    public partial class Form1 : Form
    {

        int pipeSpeed = 8;
        int gravity = 10;
        int score = 0;



        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void bird_Click(object sender, EventArgs e)
        {

        }

        private void TimerEvent(object sender, EventArgs e)
        {
            bird.Top += gravity;
            pipeBottom.Left -= pipeSpeed;
            pipeTop.Left -= pipeSpeed;
            text.Text = "Score: " + score;

            if (pipeBottom.Left < -150)
            {
                // if the bottom pipes location is -150 then we will reset it back to 800 and add 1 to the score
                pipeBottom.Left = 400;
                score++;

            }
            if (pipeTop.Left < -180)
            {
                // if the top pipe location is -180 then we will reset the pipe back to the 950 and add 1 to the score
                pipeTop.Left = 700;
                score++;
            }

            if (bird.Bounds.IntersectsWith(pipeBottom.Bounds) ||
                bird.Bounds.IntersectsWith(pipeTop.Bounds) ||
                bird.Bounds.IntersectsWith(ground.Bounds) || bird.Top < -25
                )
            {
               
                endGame();
            }

            if (score > 5)
            {
                pipeSpeed = 12; // if score is greater then 5 then we will increase
            }

        }


        private void KeyisDown(object sender, KeyEventArgs e)
        {
            // this is the game key is down event thats linked to the main form
            if (e.KeyCode == Keys.Space)
            {
                // if the space key is pressed then the gravity will be set to -15
                gravity = -10;
            }


        }

        private void KeyisUp(object sender, KeyEventArgs e)
        {
            // this is the game key is up event thats linked to the main form

            if (e.KeyCode == Keys.Space)
            {
                // if the space key is released then gravity is set back to 15
                gravity = 10;
            }

        }

        private void endGame()
        {
            // this is the game end function, this function will when the bird touches the ground or the pipes
            timer.Stop(); // stop the main timer
            text.Text += " Game over!"; // show the game over text on the score text, += is used to add the new string of text next to the score instead of overriding it
        }

    }
}
