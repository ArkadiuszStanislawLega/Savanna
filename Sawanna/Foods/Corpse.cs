using System.Drawing;
using Sawanna.Properties;

namespace Sawanna
{
    class Corpse :  Food
    {
        public Corpse()
        { }

        public Corpse(int numberId, double size, int x, int y)
        {
            this.numberID = numberId;
            this.CurrentSize = size;
            this.MaxTimeOfEgzist = 3;
            this.RateOFGettingOlder = 0.001;
            this.CurrentTimeOFEgsist = 0;
            this.RadioButton.Name = "Padlina";
            this.RadioButton.Image = Resources.corpse25;
            this.RadioButton.Size = new Size(25, 30);
            this.Rectangle.Location = new Point(x, y);
            this.RadioButton.Location = this.Rectangle.Location;
        }
    }
}
