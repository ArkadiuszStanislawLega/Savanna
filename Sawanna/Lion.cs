using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Sawanna
{
     class Lion : Animal
    {
        public Lion(float animalID)
        {
            this.image = new Bitmap("lion.png");
            this.AnimalID = animalID;
            this.Age = 0;
            this.MaxAge = 20;
            this.SpeedOfGettingOlder = 1; // ustalic

            this.SizeOfAnimal = 40;
            this.SizeOfCorps = 40;

            this.FoodSizeOfStomach = 15;
            this.FoodCurrentLevelOfFood = 15;
            this.FoodRateOfEating = 1; //ustalic
            this.FoodAppetite = 1; //ustalic
            this.FoodTypeOfFood = "Meat";

            this.WaterAreaOfWaterInStomach = 5;
            this.WaterCurrentLevelOfWater = 5;
            this.WaterRateOfDrinking = 1;//ustalic
            this.WaterRateOfWaterLos = 1;//ustalic

            this.ToxCurrentLvlOfPoison = 0;
            this.ToxPoisonTank = 0;
            this.ToxRateOfPoisonRegeneration = 0;
            this.ToxLevelOfPosionToBite = 1;

            this.FisCurrentHigh = 0;
            this.FisMaxLvlOfAltitude = 0;
            this.FisCurrentSpeed = 0; 
            this.FisMaxLvlOfSpeed = 1; //ustalic
        }
    }
}
