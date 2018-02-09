using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sawanna.Properties;

namespace Sawanna
{
    class Water : IRectangleble
    {
        public Rectangle Rectangle= new Rectangle(50, 50, 200, 200);
        public Brush waterColour { get; private set; }
        // Image bmp { get; private set; }

        public int X()
        {
           return this.Rectangle.X;
        }

        public int Y()
        {
            return this.Rectangle.Y;
        }

        public Water()
        {
            waterColour = Brushes.CornflowerBlue;
            //this.bmp = new Bitmap(Resources._31493_200);
        }
    }
}
