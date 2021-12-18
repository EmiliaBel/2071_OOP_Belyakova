using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace circleandrectangle
{
    class Circle: Figure
    {
        Pen penR;
        Rectangle rect;
        int radius;

        public Circle(Pen penR, int x, int y, int radius)
        {
            this.penR = penR;
            this.x = x;
            this.y = y;
            this.radius = radius;
        }

        public override void Draw(Graphics gr)
        {
            rect = new Rectangle(x-radius, y-radius, 2*radius, 2*radius);
            gr.DrawEllipse(penR, rect);
        }

        //(x - this.x + radius)^2 + (y - this.y + radius)^2 <= radius^2
        //слева число в разы больше числа справа, может формула не та или я её не так встроила в свой код

        public override bool IsPointInside(int x, int y)
        {
            if (Math.Pow(x - this.x, 2) + Math.Pow(y - this.y, 2) <= Math.Pow(radius, 2))
                return true;
            else return false;
        }

        public override void Move(int x, int y)
        {
            this.x += x;
            this.y += y;
        }
    }
}
