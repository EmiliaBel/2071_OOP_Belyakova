using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace circleandrectangle
{
    class Train: Figure
    {
        List<Figure> figures = new List<Figure>();
        int height, width;
        Pen pen, penR;
        int count;
        bool check;
        Random rand = new Random();
        int r;

        public Train(int height, int width, int x, int y, int count, Pen pen, Pen penR)
        {
            this.height = height;
            this.width = width;
            this.x = x;
            this.y = y;
            this.count = count;
            this.pen = pen;
            this.penR = penR;
            int wagonX = x;

            for (int i = 0; i < count; i++)
            {
                r = rand.Next(0, 3);
                if (r == 0)
                {
                    Wagon wagon = new Wagon(height, width, wagonX, y, pen, penR);
                    figures.Add(wagon);
                }
                else if(r == 1)
                {
                    WagonSand wagsand = new WagonSand(height, width, wagonX, y, pen, penR);
                    figures.Add(wagsand);
                }
                else if(r == 2)
                {
                    WagonCoal wagcoal = new WagonCoal(height, width, wagonX, y, pen, penR);
                    figures.Add(wagcoal);
                }
                wagonX += width + Convert.ToInt32(0.2*width);
            }
        }

        // высота прям такой и остаётся, через высоту с помощью коэффиента высчитывается оптимальная длина вагона, затем вся длина width делится на длину вагона, из чего мы получаем количество вагонов, если что-то там не умещается то и на кой оно надо

        public override void Draw(Graphics gr)
        {
            foreach (Figure figure in figures)
            {
                figure.Draw(gr);
            }
        }

        public override bool IsPointInside(int x, int y)
        {
            foreach (Figure figure in figures)
            {
                if (figure.IsPointInside(x, y))
                {
                    return true;
                }
            }

            return false;
        }

        public override void Move(int x, int y)
        {
            foreach(Figure figure in figures)
            {
                figure.Move(x, y);
            }
        }
    }
}
