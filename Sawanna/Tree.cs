using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sawanna.Properties;
using System.Windows.Forms;

namespace Sawanna
{
    /// <summary>
    /// Tree on which Toko birds stop.
    /// Drzewo na którym ptaki Toko się zatrzymują.
    /// </summary>
    class Tree :IRectangleble
    {
        public Rectangle Rectangle = new Rectangle(50, 50, 50, 25);
        public System.Windows.Forms.RadioButton treeButton;
        public Image imageTree = Resources.akacja25x50;

        public Tree()
        {
            treeButton = new RadioButton();
            this.treeButton.Image = Resources.akacja25x50;
        }

        public int X()
        {
            return Rectangle.X;
        }

        public int Y()
        {
            return Rectangle.Y;
        }
    }
}
