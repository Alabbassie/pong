using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pong
{
    public partial class pong : Form
    {

        public int speed_left = 2;
        public int speed_top = 4;
        public int points = 0;


        public pong()
        {
            InitializeComponent();
            timer1.Interval = 1;
            timer1.Enabled = true;
            Cursor.Hide();
            

            this.FormBorderStyle = FormBorderStyle.None;
            this.TopMost = true;
            this.Bounds = Screen.PrimaryScreen.Bounds;
            racket.Top = playground.Bottom - (playground.Bottom / 10);

            gameover_lbl.Left = (playground.Width / 2) - ( gameover_lbl.Width / 2 ) ;
            gameover_lbl.Top = (playground.Height / 2) - (gameover_lbl.Height / 2);
            gameover_lbl.Visible = false;


             
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            racket.Left = Cursor.Position.X - (racket.Width / 2);

            ball.Left += (int) speed_left;
            Console.WriteLine(speed_left);
            ball.Top += (int) speed_top;

            if (ball.Bottom >= racket.Top && ball.Bottom <= racket.Bottom && ball.Left >= (racket.Left - ball.Width/2 ) && ball.Right <= (racket.Right + ball.Width/2))
            {
                if(speed_left < 0)
                {
                    speed_left -= 1;
                   
                }
                else
                {
                    speed_left += 1 ;
                }

                speed_top += 1;
                speed_top = -speed_top;
                points += 1;
                points_lbl.Text = points.ToString();

                Random r = new Random();
                playground.BackColor = Color.FromArgb(r.Next(150, 255), r.Next(150, 255), r.Next(150, 255));

            }
            if (speed_top > 30) 
            {
                speed_top = 30;
            }
            if( speed_left > 30)
            {
                speed_left = 30;
            }
            if (ball.Left <= playground.Left)
            {
                speed_left = -speed_left;

            }

            if(ball.Right >= playground.Right)
            {
                speed_left = -speed_left;
            }
            if (ball.Top <= playground.Top)
            {
                speed_top = -speed_top;
            }
            if (ball.Bottom >= playground.Bottom)
            {
                timer1.Enabled = false;
                gameover_lbl.Visible = true;
            }
        } 

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            if (e.KeyCode == Keys.F1)
            {
                ball.Top = 50;
                ball.Left = 50;
                speed_left = 4;
                speed_top = 4;
                points = 0;
                points_lbl.Text = "0";
                timer1.Enabled = true;
                gameover_lbl.Visible = false;
            }
           
        }

        private void ball_Click(object sender, EventArgs e)
        {

        }
    }
}

