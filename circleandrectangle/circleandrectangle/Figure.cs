using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace circleandrectangle
{
    class Figure
    {
        protected int x, y;  
        public virtual void Draw(Graphics gr)
        {

        }
        public virtual void Move(int x, int y)
        {

        }

        public virtual bool IsPointInside(int x, int y)
        {
            return false;
        }
    }
}
