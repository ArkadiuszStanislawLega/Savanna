using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Sawanna
{
    class Antelope : Animal
    {
        public Antelope (int animalID)
        {
            this.image = new Bitmap("antelope.png");
            this.AnimalID = animalID;
            this.Age = 0;
            this.MaxAge = 20;
            this.SpeedOfGettingOlder = 1; // ustalic

            this.SizeOfAnimal = 30;
            this.SizeOfCorps = 30;

            this.FoodSizeOfStomach = 10;
            this.FoodCurrentLevelOfFood = 7;
            this.FoodRateOfEating = 1; //ustalic
            this.FoodAppetite = 1; //ustalic
            this.FoodTypeOfFood = "Meat";

            this.WaterAreaOfWaterInStomach = 3;
            this.WaterCurrentLevelOfWater = 3;
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
