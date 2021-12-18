using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace circleandrectangle
{
    class Wagon : Figure
    {
        Circle c, c2;
        Rectangles rect;
        int height, width;
        public Wagon(int height, int width, int x, int y, Pen pen, Pen penR)
        {
            this.height = height;
            this.width = width;
            rect = new Rectangles(x, y, height, width, pen);
            //c = new Circle(penR, (Convert.ToInt32(0.1 * width) + x), (y + Convert.ToInt32(height)), Convert.ToInt32(0.07 * width));
            //c2 = new Circle(penR, (x + Convert.ToInt32(width * 0.8)), (y + Convert.ToInt32(height)), Convert.ToInt32(0.1 * width));
            c = new Circle(penR, x + Convert.ToInt32(0.2 * width), y + Convert.ToInt32(height + Convert.ToInt32(0.07 * width)), Convert.ToInt32(0.07 * width));
            c2 = new Circle(penR, x + Convert.ToInt32(0.8 * width), y + Convert.ToInt32(height + Convert.ToInt32(0.07 * width)), Convert.ToInt32(0.07 * width));
        }

        public override void Draw(Graphics gr)
        {
            rect.Draw(gr);
            c.Draw(gr);
            c2.Draw(gr);
        }

        public override bool IsPointInside(int x, int y)
        {
            //if (((this.x + width > x) && (this.y + height > y) && (this.x < x) && (this.y < y)) || ((x - (this.x + Convert.ToInt32(0.1 * width)) + Convert.ToInt32(0.1 * width)) * (x - (this.x + Convert.ToInt32(0.1 * width)) + Convert.ToInt32(0.1 * width)) + (y - (this.y + Convert.ToInt32(0.1 * width)) + Convert.ToInt32(0.1 * width)) * (y - (this.y + Convert.ToInt32(0.1 * width)) + Convert.ToInt32(0.1 * width)) <= Convert.ToInt32(0.1 * width) * Convert.ToInt32(0.1 * width)))
            if (c.IsPointInside(x, y) || c2.IsPointInside(x, y) || rect.IsPointInside(x, y))
                return true;
            else return false;
        }

        //чёт с x и y не то, radius заменить на Convert.ToInt32(0.1 * width)
        //вроде бы как таковых x и y у меня в вагоне нет, есть собственные x и y у каждой фигуры, так что как-то надо через все фигуры отдельно проверку делать

        public override void Move(int x, int y)
        {
            c.Move(x, y);
            c2.Move(x, y);
            rect.Move(x, y);
        }

    }
}
