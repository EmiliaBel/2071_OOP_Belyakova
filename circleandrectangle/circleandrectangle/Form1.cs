using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace circleandrectangle
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Pen pen = new Pen(Color.Black, 3);
        Pen penR = new Pen(Color.DarkRed, 3);
        int x, y, height, width, radius, count;
        Rectangles rect;
        Circle c;
        Wagon wagon;
        Train train;

        private void button1_Click(object sender, EventArgs e)
        {
            radioBut_circle.Checked = false;
            radioBut_rect.Checked = false;
            radioBut_wagon.Checked = false;
            radioBut_train.Checked = false;
        }

        List<Figure> figures = new List<Figure>();

        private void Clear_Click(object sender, EventArgs e)
        {
            //panel1.Invalidate();

            figures.Clear();
            panel1.Refresh();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            height = e.Y - y;
            width = e.X - x;
            
            if (radioBut_circle.Checked)
            {
                if (Math.Abs(e.X - x) > Math.Abs(e.Y - y))
                {
                    radius = e.X - x;
                }
                else
                {
                    radius = e.Y - y;
                }
                c = new Circle(penR, x, y, Math.Abs(radius));
                figures.Add(c);
            }

            if (radioBut_rect.Checked)
            {
                rect = new Rectangles(x, y, height, width, pen);
                figures.Add(rect);
            }

            if (radioBut_wagon.Checked)
            {
                wagon = new Wagon(height, width, x, y, pen, penR);
                figures.Add(wagon);
            }

            if (radioBut_train.Checked)
            {
                count = Convert.ToInt32(count_wagon.Text);
                train = new Train(height, width, x, y, count, pen, penR);
                figures.Add(train);
            }

            if ((!radioBut_circle.Checked) && (!radioBut_rect.Checked) && (!radioBut_wagon.Checked) && (!radioBut_train.Checked))
            {
                foreach (Figure figure in figures)
                {
                    if (figure.IsPointInside(x, y))
                        figure.Move(e.X-x, e.Y-y);
                }
            }

            panel1.Refresh();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            foreach (Figure figure in figures)
            {
                figure.Draw(panel1.CreateGraphics());
            }
        }


    //    private void panel1_MouseClick(object sender, MouseEventArgs e)
    //    {
    //        gr = panel1.CreateGraphics();
    //        if (checkbox_circle.Checked == true)
    //        {
    //            c = new Circle(penR, e.X, e.Y, radius);
    //            figures.Add(c);
    //        }
            
    //        if(checkbox_rect.Checked == true)
    //        {
    //            rect = new Rectangles(height, width, e.X, e.Y, pen);
    //            figures.Add(rect);
    //        }

    //        if (checkbox_wagon.Checked == true)
    //        {
    //            wagon = new Wagon(e.X, e.Y);
    //            figures.Add(rect);
    //        }

    //        panel1.Refresh();
    //    }
    }
}
