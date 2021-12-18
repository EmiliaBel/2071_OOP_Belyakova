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
    class Rectangles: Figure
    {
        Pen pen;
        int height, width;

        public Rectangles(int x, int y, int height, int width, Pen pen)
        {
            this.pen = pen;
            this.x = x;
            this.y = y;
            this.height = height;
            this.width = width;
        }

        public override void Draw(Graphics gr)
        {
            gr.DrawRectangle(pen, x, y, width, height);
        }

        //тут тоже что-то не то с x и y, типо почему-то он проходит через конструктор, не знаю правильно это или нет и что с этим делать, типо внешне оно работает, но с кодом какая-то шняга
        //или норм всё, не понимаю

        public override bool IsPointInside(int x, int y)
        {
            if ((this.x + width >= x) && (this.y + height >= y) && (this.x <= x) && (this.y <= y))
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
