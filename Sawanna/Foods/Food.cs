using System.Drawing;
using System;
using System.Windows.Forms;
using Sawanna.Properties;

namespace Sawanna
{
    public class Food : IRectangleble
    {
        public Rectangle Rectangle = new Rectangle(0, 0, 25, 25);
        public RadioButton RadioButton = new RadioButton();

        public int numberID { get; protected set; }
        public double CurrentSize { get; protected set; }
        public double MaxTimeOfEgzist { get; protected set; }
        public double CurrentTimeOFEgsist { get; protected set; }
        public double RateOFGettingOlder { get; protected set; }

        protected Food()
            : this(10, 0.001, 20)
        { }

        protected Food(double size, double rateOfGettingOlder, double maxTimeOfEgzist)
        {
            this.Rectangle.Location = this.RadioButton.Location;

            this.RadioButton.Image = Resources.corpse25;
            this.RadioButton.AutoSize = true;
            this.RadioButton.CheckAlign = ContentAlignment.BottomLeft;
            this.RadioButton.FlatAppearance.BorderColor = Color.Yellow;
            this.RadioButton.FlatAppearance.MouseDownBackColor = Color.Red;
            this.RadioButton.FlatStyle = FlatStyle.Flat;
            this.RadioButton.Size = new Size(25, 25);
            this.RadioButton.TabIndex = 0;
            this.RadioButton.TabStop = true;
            this.RadioButton.TextImageRelation = TextImageRelation.Overlay;
            this.RadioButton.UseVisualStyleBackColor = true;
            this.RadioButton.BackColor = Color.Transparent;
            this.RadioButton.UseVisualStyleBackColor = true;

            this.CurrentSize = size;
            this.RateOFGettingOlder = rateOfGettingOlder;
            this.MaxTimeOfEgzist = maxTimeOfEgzist;
        }

        public virtual void AtributesRunning()
        {
            if (this.CurrentTimeOFEgsist <= this.MaxTimeOfEgzist) { this.CurrentTimeOFEgsist += this.RateOFGettingOlder; }
            else
            {
                this.CurrentSize = 0;
                this.RadioButton.Visible = false;
            }
        }

        public virtual void Eaten(double eatenRate)
        {
            if (this.CurrentSize >= 0) { this.CurrentSize -= eatenRate; }
            if (this.CurrentSize <= 0) MakeWorld.NumberIdOfEatenCorpses.Add(this.numberID);
        }

        public int X() { return this.Rectangle.X; }
        public int Y() { return this.Rectangle.Y; }
    }
}
