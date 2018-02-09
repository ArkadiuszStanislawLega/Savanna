using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sawanna
{
    class CheckPoint : IRectangleble
    {
        public Rectangle Rectangle { get; private set; }

        public CheckPoint(int x, int y)
        {
            this.Rectangle = new Rectangle(x, y, 5, 5);
        }

        public int X()
        {
            return this.Rectangle.X;
        }

        public int Y()
        {
            return this.Rectangle.Y;
        }
    }
}
