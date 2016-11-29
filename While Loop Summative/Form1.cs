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

namespace While_Loop_Summative
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //create pens and brushes
            Graphics formGraphics = this.CreateGraphics();
            Font drawFont = new Font("Arial", 16, FontStyle.Bold);
            SolidBrush drawBrush = new SolidBrush(Color.White);

            formGraphics.DrawString("Click to Begin", drawFont, drawBrush, 50, 40);
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            //create pens and brushes
            Graphics formGraphics = this.CreateGraphics();
            Pen drawPen = new Pen(Color.Gray, 9);
            Pen circlePen = new Pen(Color.Gray, 4);
            Pen explodePen = new Pen(Color.OrangeRed, 4);
            Pen explodePen2 = new Pen(Color.Orange, 4);
            SolidBrush drawBrush = new SolidBrush(Color.Gray);
            SolidBrush blackBrush = new SolidBrush(Color.Black);
            SolidBrush yellowBrush = new SolidBrush(Color.Yellow);

            int x = this.Width - 100;
            int y = 20;

            while (x > 220)
            {
                //animate plane
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

            while (y < 230)
            {
                //animate bomb
                formGraphics.FillEllipse(yellowBrush, 240, y + 20, 10, 10);
                Thread.Sleep(10);
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

            x = 220;

            while (x > 0)
            {
                //redraw bomb
                formGraphics.FillEllipse(yellowBrush, 240, y + 20, 10, 10);
                //animate plane
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

            while (x <= 255)
            {
                //fade bomb colour
                yellowBrush.Color = Color.FromArgb(255, 255 - x, 0);
                formGraphics.FillEllipse(yellowBrush, 240, y + 20, 10, 10);
                Thread.Sleep(10);
                x = x + 1;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
