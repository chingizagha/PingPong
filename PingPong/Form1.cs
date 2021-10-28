using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PingPong
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        bool isWorking = true;
        bool goUp;
        bool goDown;
        int speed = 10;
        int player1Point;
        int player2Point;
        int ballx = 10; 
        int bally = 10;

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                goUp = true;
            }
            if (e.KeyCode == Keys.Down)
            {
                goDown = true;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                goUp = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                goDown = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Game();

            void Game()
            {
                if (goUp == true && player1.Location.Y > -1)
                {
                    player1.Location = new Point(player1.Location.X, player1.Location.Y - speed);
                }
                if (goDown == true && player1.Location.Y < 283)
                {
                    player1.Location = new Point(player1.Location.X, player1.Location.Y + speed);
                }


                if (player2.Location.Y == 0)
                    isWorking = false;
                else if (player2.Location.Y == 290)
                    isWorking = true;

                if (isWorking == true)
                    player2.Location = new Point(player2.Location.X, player2.Location.Y - speed);
                else
                    player2.Location = new Point(player2.Location.X, player2.Location.Y + speed);

                cube.Top -= bally;
                cube.Left -= ballx;

                if (cube.Left < 0)
                {
                    cube.Left = 434;
                    ballx = -ballx;
                    ballx -= 2;
                    player2Point++;
                }


                if (cube.Left + cube.Width > ClientSize.Width)
                {
                    cube.Left = 434;
                    ballx = -ballx;
                    ballx += 2;
                    player1Point++;
                }

                if (cube.Top < 0 || cube.Top + cube.Height > ClientSize.Height)
                {
                    bally = -bally;
                }

                if (cube.Bounds.IntersectsWith(player1.Bounds) || cube.Bounds.IntersectsWith(player2.Bounds))
                {
                    ballx = -ballx;
                }
            }
            

            if(player1Point > 5)
            {
                timer1.Stop();
                MessageBox.Show("Player1 wins, player2 lose");
                var result = MessageBox.Show("Do you want to play Continue", "Confirm", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                    this.Close();
                else
                {
                    player1Score.Text = "00";
                    player2Score.Text = "00";
                    timer1.Start();
                }
            }

            player1Score.Text = Convert.ToString(player1Point);
            player2Score.Text = Convert.ToString(player2Point);


            if (player2Point > 5)
            {
                timer1.Stop();
                MessageBox.Show("Player2 wins, player1 lose");
                var result = MessageBox.Show("Do you want to play Continue", "Confirm", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                    this.Close();
                else
                {
                    player1Score.Text = "00";
                    player2Score.Text = "00";
                    timer1.Start();
                }
            }


        }

        
    }
}
