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
        bool hasArrived = false;    
        bool isWorking = true;
        bool goUp;
        bool goDown;
        bool player1Bounds = false;
        bool player2Bounds = false; 
        int speed = 10;
        int speedBall = 1;
        //int speed1 = 129;
        int score = 0;
        int destX;
        int destXX;
        int destY;


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


        private void timer1_Tick(object sender, EventArgs e)
        {
            //Player1 code for moving up and down
            if (goUp == true && player1.Location.Y > -1)
            {
                player1.Location = new Point(player1.Location.X, player1.Location.Y - speed);
            }
            if (goDown == true && player1.Location.Y < 283)
            {
                player1.Location = new Point(player1.Location.X, player1.Location.Y + speed);
            }

            //Player2 code for moving up and down
            if (player2.Location.Y == 0)
                isWorking = false;
            else if (player2.Location.Y == 290)
                isWorking = true;

            if (isWorking == true)
                player2.Location = new Point(player2.Location.X, player2.Location.Y - speed);
            else
                player2.Location = new Point(player2.Location.X, player2.Location.Y + speed);


            var rand = new Random();
            int rnd = rand.Next(0, 280);

            destX = 0;
            destXX = 807;
            destY = rnd;

            while(hasArrived == false)
            {
                if(cube.Location.X != destX && cube.Location.X > destX)
                {
                    cube.Location = new Point(cube.Location.X - speedBall, cube.Location.Y);
                }
                else if(cube.Location.X != destX && cube.Location.X < destX)
                {
                    cube.Location = new Point(cube.Location.X + speedBall, cube.Location.Y);
                }
                if (cube.Location.Y != destY && cube.Location.Y > destY)
                {
                    cube.Location = new Point(cube.Location.X, cube.Location.Y - speedBall);
                }
                else if (cube.Location.Y != destY && cube.Location.Y < destY)
                {
                    cube.Location = new Point(cube.Location.X, cube.Location.Y + speedBall);
                }
                if (cube.Location.X <= destX && cube.Location.Y <= destY)
                    hasArrived = true;
            }

            //this.SuspendLayout();
            //cube.Location = new Point(30, rnd);
            //this.ResumeLayout(); 

            if (player1.Bounds.IntersectsWith(cube.Bounds))
            {
                player1Bounds = true;
                //if (cube.Location.X != destXX && cube.Location.X > destXX)
                //{
                //    cube.Location = new Point(cube.Location.X - speedBall, cube.Location.Y);
                //}
                //else if (cube.Location.X != destXX && cube.Location.X < destXX)
                //{
                //    cube.Location = new Point(cube.Location.X + speedBall, cube.Location.Y);
                //}
                //if (cube.Location.Y != destY && cube.Location.Y > destY)
                //{
                //    cube.Location = new Point(cube.Location.X, cube.Location.Y - speedBall);
                //}
                //else if (cube.Location.Y != destY && cube.Location.Y < destY)
                //{
                //    cube.Location = new Point(cube.Location.X, cube.Location.Y + speedBall);
                //}
            }

            if (player2.Bounds.IntersectsWith(cube.Bounds))
            {
                player2Bounds = true;
                //if (cube.Location.X != destX && cube.Location.X > destX)
                //{
                //    cube.Location = new Point(cube.Location.X - speedBall, cube.Location.Y);
                //}
                //else if (cube.Location.X != destX && cube.Location.X < destX)
                //{
                //    cube.Location = new Point(cube.Location.X + speedBall, cube.Location.Y);
                //}
                //if (cube.Location.Y != destY && cube.Location.Y > destY)
                //{
                //    cube.Location = new Point(cube.Location.X, cube.Location.Y - speedBall);
                //}
                //else if (cube.Location.Y != destY && cube.Location.Y < destY)
                //{
                //    cube.Location = new Point(cube.Location.X, cube.Location.Y + speedBall);
                //}
            }

            while(player1Bounds == true)
            {
                if (cube.Location.X != destXX && cube.Location.X > destXX)
                {
                    cube.Location = new Point(cube.Location.X - speedBall, cube.Location.Y);
                }
                else if (cube.Location.X != destXX && cube.Location.X < destXX)
                {
                    cube.Location = new Point(cube.Location.X + speedBall, cube.Location.Y);
                }
                if (cube.Location.Y != destY && cube.Location.Y > destY)
                {
                    cube.Location = new Point(cube.Location.X, cube.Location.Y - speedBall);
                }
                else if (cube.Location.Y != destY && cube.Location.Y < destY)
                {
                    cube.Location = new Point(cube.Location.X, cube.Location.Y + speedBall);
                }
                if (cube.Location.X <= destXX && cube.Location.Y <= destY)
                    player1Bounds = false;
            }

            while(player2Bounds == true)
            {
                if (cube.Location.X != destX && cube.Location.X > destX)
                {
                    cube.Location = new Point(cube.Location.X - speedBall, cube.Location.Y);
                }
                else if (cube.Location.X != destX && cube.Location.X < destX)
                {
                    cube.Location = new Point(cube.Location.X + speedBall, cube.Location.Y);
                }
                if (cube.Location.Y != destY && cube.Location.Y > destY)
                {
                    cube.Location = new Point(cube.Location.X, cube.Location.Y - speedBall);
                }
                else if (cube.Location.Y != destY && cube.Location.Y < destY)
                {
                    cube.Location = new Point(cube.Location.X, cube.Location.Y + speedBall);
                }
                if (cube.Location.X <= destX && cube.Location.Y <= destY)
                    player2Bounds = false;
            }




        }
    }
}
