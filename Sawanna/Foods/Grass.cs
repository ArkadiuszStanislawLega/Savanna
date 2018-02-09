using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sawanna.Properties;
using System.Drawing;

namespace Sawanna
{
    class Grass : Food
    {
        public Bitmap bmp;
        public Brush colourOfGrass = Brushes.DarkOliveGreen;
        public Grass()
        {
            this.Rectangle = new Rectangle(0, 0, 15, 15);
            this.RadioButton.Name = "Trawa";
            this.bmp = Resources.grass;
        }
    }
}
