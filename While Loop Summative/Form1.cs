///Created by Joy Harris
///Novemeber 29 2016
///For the purpose of recreating an animation from Star Wars
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
using System.Media;

namespace While_Loop_Summative
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            //create pens and brushes
            Font drawFont = new Font("Letter Gothic Std", 14, FontStyle.Bold);
            Font secondFont = new Font("Segoe Script", 12, FontStyle.Bold);
            Graphics formGraphics = this.CreateGraphics();
            Pen drawPen = new Pen(Color.Gray, 9);
            Pen circlePen = new Pen(Color.Gray, 4);
            Pen explodePen = new Pen(Color.OrangeRed, 3);
            Pen explodePen2 = new Pen(Color.Orange, 3);
            SolidBrush briefingBrush = new SolidBrush(Color.LightGray);
            SolidBrush drawBrush = new SolidBrush(Color.Gray);
            SolidBrush blackBrush = new SolidBrush(Color.Black);
            SolidBrush yellowBrush = new SolidBrush(Color.Yellow);

            int x = this.Width - 100;
            int y = 20;

            formGraphics.DrawString("Mission Briefing", drawFont, briefingBrush, 20, 40);
            Thread.Sleep(500);
            formGraphics.DrawString("You will navigate fighter jet to the Death \nStar to drop a bomb through the exhaust \nport in an attempt to destroy the Death \nStar.", drawFont, drawBrush, 20, 100);
            Thread.Sleep(3000);

            //plane enter screen
            while (x > 220)
            {
                formGraphics.FillPie(drawBrush, x, 20, 40, 40, 340, 35);
                Thread.Sleep(10);
                x = x - 2;
                Refresh();

                //redraw star
                formGraphics.DrawEllipse(drawPen, 150, 75, 200, 200);
                formGraphics.FillRectangle(blackBrush, 240, 71, 15, 15);
                formGraphics.FillRectangle(drawBrush, 236, 73, 4, 170);
                formGraphics.FillRectangle(drawBrush, 254, 73, 4, 170);
                formGraphics.DrawEllipse(circlePen, 233, 240, 25, 25);
                formGraphics.FillRectangle(blackBrush, 240, 239, 15, 10);
            }

            SoundPlayer player = new SoundPlayer(Properties.Resources.airstrike);
            player.Play();

            //drop bomb
            while (y < 230)
            {
                formGraphics.FillEllipse(yellowBrush, 240, y + 20, 10, 10);
                Thread.Sleep(6);
                y = y + 2;
                Refresh();
                //redraw star
                formGraphics.DrawEllipse(drawPen, 150, 75, 200, 200);
                formGraphics.FillRectangle(blackBrush, 240, 71, 15, 15);
                formGraphics.FillRectangle(drawBrush, 236, 73, 4, 170);
                formGraphics.FillRectangle(drawBrush, 254, 73, 4, 170);
                formGraphics.DrawEllipse(circlePen, 233, 240, 25, 25);
                formGraphics.FillRectangle(blackBrush, 240, 239, 15, 10);
                //redraw plane
                formGraphics.FillPie(drawBrush, 220, 20, 40, 40, 340, 35);
            }

            //set x value to 220
            x = 220;

            //plane exit screen
            while (x > 0)
            {
                formGraphics.FillPie(drawBrush, x, 20, 40, 40, 340, 35);
                Thread.Sleep(6);
                //redraw bomb
                formGraphics.FillEllipse(yellowBrush, 240, y + 20, 10, 10);
                x = x - 2;
                Refresh();
                //redraw star
                formGraphics.DrawEllipse(drawPen, 150, 75, 200, 200);
                formGraphics.FillRectangle(blackBrush, 240, 71, 15, 15);
                formGraphics.FillRectangle(drawBrush, 236, 73, 4, 170);
                formGraphics.FillRectangle(drawBrush, 254, 73, 4, 170);
                formGraphics.DrawEllipse(circlePen, 233, 240, 25, 25);
                formGraphics.FillRectangle(blackBrush, 240, 239, 15, 10);
            }

            //fade bomb colour
            while (x <= 255)
            {
                yellowBrush.Color = Color.FromArgb(255, 255 - x, 0);
                formGraphics.FillEllipse(yellowBrush, 240, y + 20, 10, 10);

                Thread.Sleep(5);
                x = x + 1;
            }

            //create explosion
            for (int length = 0; length <= 40; length++)
            {
                formGraphics.DrawLine(explodePen, 260, y + 20, 260 + length, y + 20);
                formGraphics.DrawLine(explodePen, 230, y + 20, 230 - length, y + 20);
                formGraphics.DrawLine(explodePen, 245, y + 15, 245, y + 15 - length);
                formGraphics.DrawLine(explodePen, 245, y + 40, 245, y + 40 + length);
                formGraphics.DrawLine(explodePen, 260, y + 10, 260 + length, y + 10 - length);
                formGraphics.DrawLine(explodePen, 230, y + 10, 230 - length, y + 10 - length);
                formGraphics.DrawLine(explodePen, 260, y + 40, 260 + length, y + 40 + length);
                formGraphics.DrawLine(explodePen, 230, y + 40, 230 - length, y + 40 + length);

                Thread.Sleep(5);
            }

            player = new SoundPlayer(Properties.Resources.Explosion);
            player.Play();

            formGraphics.DrawString("Good Luck!", secondFont, briefingBrush, 200, 310);
            Thread.Sleep(500);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
