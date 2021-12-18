using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace circleandrectangle
{
    class WagonSand: Figure
    { 
        Circle c, c2;
        Rectangles rect;
        Point[] points;
        int height, width;
        Brush brush = new SolidBrush(Color.Gold);
        public WagonSand(int height, int width, int x, int y, Pen pen, Pen penR)
        {
            this.height = height;
            this.width = width;
            rect = new Rectangles(x, y, height, width, pen);
            c = new Circle(penR, x + Convert.ToInt32(0.2 * width), y + Convert.ToInt32(height + Convert.ToInt32(0.07 * width)), Convert.ToInt32(0.07 * width));
            c2 = new Circle(penR, x + Convert.ToInt32(0.8 * width), y + Convert.ToInt32(height + Convert.ToInt32(0.07 * width)), Convert.ToInt32(0.07 * width));
            Point point1 = new Point(x, y);
            Point point2 = new Point(x + width, y);
            Point point3 = new Point(x + Convert.ToInt32(0.5 * width), y - Convert.ToInt32(0.5 * height));
            points = new Point[]{ point1, point2, point3 };
        }

        public override void Draw(Graphics gr)
        {
            rect.Draw(gr);
            c.Draw(gr);
            c2.Draw(gr);
            gr.FillPolygon(brush, points);
        }

        public override bool IsPointInside(int x, int y)
        {
            if (c.IsPointInside(x, y) || c2.IsPointInside(x, y) || rect.IsPointInside(x, y))
                return true;
            else return false;
        }

        public override void Move(int x, int y)
        {
            c.Move(x, y);
            c2.Move(x, y);
            rect.Move(x, y);
            for (int i = 0; i < 3; i++)
            {
                points[i].X += x;
                points[i].Y += y;
            }
        }

    }
}

