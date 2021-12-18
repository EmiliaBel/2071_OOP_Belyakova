using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace circleandrectangle
{
    class WagonCoal: Figure
    {

        Circle c, c2;
        Rectangles rect;
        int height, width;
        Rectangle coal;
        Brush brush = new SolidBrush(Color.Black);
        public WagonCoal(int height, int width, int x, int y, Pen pen, Pen penR)
        {
            this.height = height;
            this.width = width;
            rect = new Rectangles(x, y, height, width, pen);
            c = new Circle(penR, x + Convert.ToInt32(0.2 * width), y + Convert.ToInt32(height + Convert.ToInt32(0.07 * width)), Convert.ToInt32(0.07 * width));
            c2 = new Circle(penR, x + Convert.ToInt32(0.8 * width), y + Convert.ToInt32(height + Convert.ToInt32(0.07 * width)), Convert.ToInt32(0.07 * width));
            coal = new Rectangle(x, y - Convert.ToInt32(0.2 * height), width, Convert.ToInt32(0.2 * height));
        }

        public override void Draw(Graphics gr)
        {
            rect.Draw(gr);
            c.Draw(gr);
            c2.Draw(gr);
            gr.FillRectangle(brush, coal);
        }

        public override bool IsPointInside(int x, int y)
        {
            if (c.IsPointInside(x, y) || c2.IsPointInside(x, y) || rect.IsPointInside(x, y) || ((this.x + width >= x) && (this.y - Convert.ToInt32(0.2 * height) + Convert.ToInt32(0.2 * height) >= y) && (this.x <= x) && (this.y - Convert.ToInt32(0.2 * height) <= y)))
                return true;
            else return false;
        }

        public override void Move(int x, int y)
        {
            c.Move(x, y);
            c2.Move(x, y);
            rect.Move(x, y);
            coal.X += x;
            coal.Y += y;
        }

    }
}

