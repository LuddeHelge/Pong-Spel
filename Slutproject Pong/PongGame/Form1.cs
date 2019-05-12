using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PongSpel
{
    public partial class Form1 : Form
    {
        bool upPressed, downPressed;
        bool OPupPressed, OPdownPressed;
        const int Movementspeed = 4;
        int BallSpeedX;
        int BallSpeedY;
        int PlayerScore = 0;
        int AiScore = 0;

        public Form1()
        {
            InitializeComponent();
            ResetBall();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //-- Paddelens Kontroll
            if(upPressed) {
                Paddle2.Location = new Point(Paddle2.Location.X, Math.Max(0,Paddle2.Location.Y - Movementspeed));
            } else if (downPressed) {
                Paddle2.Location = new Point(Paddle2.Location.X, Math.Min(425, Paddle2.Location.Y + Movementspeed));
            }


            if (OPupPressed) {
                Paddle1.Location = new Point(Paddle1.Location.X, Math.Max(0,Paddle1.Location.Y - Movementspeed));
            } else if (OPdownPressed) {
                Paddle1.Location = new Point(Paddle1.Location.X, Math.Min(425, Paddle1.Location.Y + Movementspeed));
            }


            //-- Bollens Kontroll
            if(Ball.Location.Y > 525 || Ball.Location.Y < -2)  { BallSpeedY = BallSpeedY * -1; };
            if (Paddle1.Bounds.Contains(Ball.Bounds) || Paddle2.Bounds.Contains(Ball.Bounds)) { BallSpeedX = BallSpeedX * -1; };
            Ball.Location = new Point(Ball.Location.X + BallSpeedX, Ball.Location.Y + BallSpeedY);
            if (Ball.Location.X > 976 ) { 
                ResetBall();
                PlayerScore++;
                label4.Text = PlayerScore.ToString();
            }; 
            if (Ball.Location.X < 0) { // Spelaren
                ResetBall();
                AiScore++;
                label3.Text = AiScore.ToString();

            }; 

            //-- Datorns kontroll
            if (Ball.Location.X > 300) {
                if (Paddle2.Location.Y > Ball.Location.Y) { upPressed = true; } else { upPressed = false; };
                if (Paddle2.Location.Y < Ball.Location.Y) { downPressed = true; } else { downPressed = false; };
            }
          

        }

        //-- Knappar
        private void Form1_KeyDown(object sender, KeyEventArgs e) {
            
            if (e.KeyCode == Keys.W) { OPupPressed = true; } else if (e.KeyCode == Keys.S) { OPdownPressed = true; }
        }

        private void textBox1_TextChanged(object sender, EventArgs e) {

        }

        private void label1_Click(object sender, EventArgs e) {

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e) {
            
            if (e.KeyCode == Keys.W) { OPupPressed = false; } else if (e.KeyCode == Keys.S) { OPdownPressed = false; }
        }

        public void ResetBall() {
            Thread.Sleep(1000);
            Random random = new System.Random();
            Ball.Location = new Point(476,240);
            BallSpeedY = random.Next(-10, 10);
            BallSpeedX = random.Next(-8, 8);
            
        }


    }
}
