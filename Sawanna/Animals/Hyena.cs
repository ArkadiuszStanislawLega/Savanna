using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sawanna.Properties;

namespace Sawanna
{
    class Hyena : Animal
    {

        public Hyena(float animalID, double age, double maxAge, double speedOfGettingOlder, double sizeOfAnimal, double sizeOfCorps, double areaOfWaterInStomach,
          double currentLevelOfWater, double rateOfDrinking, double rateOfWaterLos, double sizeOfStomach, double currentLevelOfFood,
          double rateOfEating, double appetite, double fisMaxLvlOfSpeed)
            : this(MakeWorld.IdAnimalCouter, 50, 50)
        { 
            this.AnimalID = animalID;
            this.Age = age;
            this.MaxAge = maxAge;
            this.SpeedOfGettingOlder = MakeWorld.SettingsOfTheWorld.speedOfLife * speedOfGettingOlder;

            this.SizeOfAnimal = sizeOfAnimal;
            this.SizeOfCorps = sizeOfCorps;

            this.FoodSizeOfStomach = sizeOfStomach;
            this.FoodCurrentLevelOfFood = currentLevelOfFood;
            this.FoodRateOfEating = MakeWorld.SettingsOfTheWorld.speedOfLife * rateOfEating;
            this.FoodAppetite = MakeWorld.SettingsOfTheWorld.speedOfLife * appetite;

            this.WaterAreaOfWaterInStomach = areaOfWaterInStomach;
            this.WaterCurrentLevelOfWater = currentLevelOfWater;
            this.WaterRateOfDrinking = MakeWorld.SettingsOfTheWorld.speedOfLife * rateOfDrinking;
            this.WaterRateOfWaterLos = MakeWorld.SettingsOfTheWorld.speedOfLife * rateOfWaterLos;

            this.FisMaxLvlOfSpeed = MakeWorld.SettingsOfTheWorld.speedOfLife * fisMaxLvlOfSpeed;
        }

        public Hyena(float animalID, double lvlOfFood, double lvlOfWater)
        {
            this.AnimalRadioButton.Image = Resources.hyena25;
            this.AnimalRadioButton.Name = "Hyane ID: " + animalID;

            this.AnimalID = animalID;
            this.Age = 0;
            this.MaxAge = 15;
            this.SpeedOfGettingOlder = MakeWorld.SettingsOfTheWorld.speedOfLife * 0.001;

            this.SizeOfAnimal = 400;
            this.SizeOfCorps = 400;

            this.FoodSizeOfStomach = 100;
            this.FoodCurrentLevelOfFood = lvlOfFood;
            this.FoodRateOfEating = MakeWorld.SettingsOfTheWorld.speedOfLife * 3;
            this.FoodAppetite = MakeWorld.SettingsOfTheWorld.speedOfLife * 0.01;
            this.FoodTypeOfFood = "Padlina";

            this.WaterAreaOfWaterInStomach = 100;
            this.WaterCurrentLevelOfWater = lvlOfWater;
            this.WaterRateOfDrinking = MakeWorld.SettingsOfTheWorld.speedOfLife * 0.6;
            this.WaterRateOfWaterLos = MakeWorld.SettingsOfTheWorld.speedOfLife * 0.05;

            this.ToxCurrentLvlOfPoison = 0;
            this.ToxPoisonTank = 0;
            this.ToxRateOfPoisonRegeneration = 0;
            this.ToxLevelOfPosionToBite = 1;

            this.FisCurrentAltitude = 0;
            this.FisMaxLvlOfAltitude = 0;
            this.FisCurrentSpeed = MakeWorld.SettingsOfTheWorld.speedOfLife * 0;
            this.FisMaxLvlOfSpeed = MakeWorld.SettingsOfTheWorld.speedOfLife * 2;
        }

        /// <summary>
        /// Selecting shares from among possible.
        /// Wybiera akcje z możliwych.
        /// </summary>
        public override void ActionChooser()
        {
            if (this.WaterCurrentLevelOfWater <= 0) this.goingForWater = true; 
            if (this.FoodCurrentLevelOfFood <= 0 && this.WaterCurrentLevelOfWater <= 0) this.goingForWater = false; this.goForEat = true; 

            if (eat)
            {
                this.goingForWater = false;
                this.goForEat = false;
                this.wait = false;
            }

            if (this.goingForWater) AllForDrink(8); 
            if (this.FoodCurrentLevelOfFood <= 0 && !eat) this.goForEat = true; 

            if (this.goForEat && !eat)
            {
                BackAfterDrink(); 
                if (Rectangle.IntersectsWith(MakeWorld.checkpoints[8].Rectangle)) { CheckpointsGained++; }
                if (CheckpointsGained == 2) { CheckpointsGained = 0; }
                TryEat(MakeWorld.corpses);
                TryEat(MakeWorld.snakeCorpses);
            }
        
            if (eat && !goForEat)
            {
                TryEat(MakeWorld.corpses);
                TryEat(MakeWorld.snakeCorpses);
                Eating();
            }
            if (!this.eat && !this.goingForWater && !this.backingAfterDrink && !this.goForEat) { Waiting(0, 100, 500, 700); }
        }
    }
}
