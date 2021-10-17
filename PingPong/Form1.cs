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
        int score = 0;


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
            if (goUp == true && player1.Location.Y > -1)
            {
                player1.Location = new Point(player1.Location.X, player1.Location.Y - speed);
            }
            if (goDown == true && player1.Location.Y < 283)
            {
                player1.Location = new Point(player1.Location.X, player1.Location.Y + speed);
            }

            if(isWorking == true)
            {
                player2.Location = new Point(player2.Location.X, player2.Location.Y + speed);
                isWorking = false;
            }
            if (player2.Location.Y > -1 && player2.Location.Y < 129)
            {
                player2.Location = new Point(player2.Location.X, player2.Location.Y - speed);
            }
            if (player2.Location.Y < 283 && player2.Location.Y > 129)
            {
                player2.Location = new Point(player2.Location.X, player2.Location.Y + speed);
            }

        }
    }
}
