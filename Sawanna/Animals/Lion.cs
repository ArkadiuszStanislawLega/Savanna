using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using Sawanna.Properties;

namespace Sawanna
{
    class Lion : Animal
    {
        public Lion(float animalID, double age, double maxAge, double speedOfGettingOlder, double sizeOfAnimal, double sizeOfCorps, double areaOfWaterInStomach,
            double currentLevelOfWater, double rateOfDrinking, double rateOfWaterLos, double sizeOfStomach, double currentLevelOfFood,
            double rateOfEating, double appetite, double fisMaxLvlOfSpeed)
            : this(MakeWorld.IdAnimalCouter, 50, 50)
        {
            this.AnimalRadioButton.Image = Resources.antylopa25;
            this.AnimalRadioButton.Name = "Antylopa ID: " + animalID;

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

        public Lion(float animalID, double lvlOfFood, double lvlOfWater)
        {
            this.AnimalRadioButton.ImageAlign = ContentAlignment.BottomLeft;
            this.AnimalRadioButton.Image = Resources.lion25;
            //this.AnimalRadioButton.Text = "Lion ID: " + animalID;
            this.AnimalRadioButton.Name = "Lew ID: " + animalID;

            this.AnimalID = animalID;
            this.Age = 0;
            this.MaxAge = 15;
            this.SpeedOfGettingOlder = MakeWorld.SettingsOfTheWorld.speedOfLife * 0.001;

            this.SizeOfAnimal = 450;
            this.SizeOfCorps = 450;

            this.FoodSizeOfStomach = 100;
            this.FoodCurrentLevelOfFood = lvlOfFood;
            this.FoodRateOfEating = MakeWorld.SettingsOfTheWorld.speedOfLife * 3;
            this.FoodAppetite = MakeWorld.SettingsOfTheWorld.speedOfLife * 0.01;
            this.FoodTypeOfFood = "Mięso";

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
            this.FisMaxLvlOfSpeed = MakeWorld.SettingsOfTheWorld.speedOfLife * 3;

            this.numOfIndexInterChckp = 0;
        }

        /// <summary>
        /// Checks if the animal is in contact with food and eat it.
        /// Sprawdza czy jest styczność zwierzęcia z jedzeniem i je.
        /// </summary>
        /// <typeparam name="T"> He only commits classes inheriting from the Food class. | Pyrzjmuje tylko i wyłącznie klasy dziedziczące z klasy Food.</typeparam>
        /// <param name="x">A list with food to check. | Lista z jedzeniem do sprawdzenia.</param>
        public override void TryEat<T>(List<T> x) 
        {
            for (int i = 0; i < x.Count; i++)
            {
                if (this.Rectangle.IntersectsWith(x[i].Rectangle) && x[i].CurrentSize >= 0 && x[i].CurrentTimeOFEgsist < 0.30)
                {
                    this.goForEat = false;
                    this.eat = true;
                    x[i].Eaten(this.FoodRateOfEating);
                }
                if (x[i].CurrentSize <= 0) { this.eat = false; }
            }
        }

        /// <summary>
        /// Selecting shares from among possible.
        /// </summary>
        public override void ActionChooser()
        {
            if (this.FoodCurrentLevelOfFood <= 0 && this.WaterCurrentLevelOfWater <= 0) { this.goingForWater = false; this.goForEat = true; }
            if (this.WaterCurrentLevelOfWater <= 0 && !this.eat && !this.goForEat) { this.goingForWater = true; }
            if (this.goingForWater) { AllForDrink(0); }
            if (this.FoodCurrentLevelOfFood <= 0 && !eat) { this.goForEat = true; }
            if (this.goForEat && penaltyForLoseFight == 0 && !eat)
            {
                BackAfterDrink(); //ta metoda lepiej mi pasowała niż GoToCheckPoint która jest podobna i ma lepszą nazwe.
                if (Rectangle.IntersectsWith(MakeWorld.checkpoints[0].Rectangle)) { CheckpointsGained++; }
                if (CheckpointsGained == 2) { goForEat = false; CheckpointsGained = 0; }

                CheckIterRectangle(MakeWorld.manyAntylopes,MakeWorld.SettingsOfTheWorld.chanceForLionBite);
                CheckIterRectangle(MakeWorld.manyHyenas, MakeWorld.SettingsOfTheWorld.chanceForLionBite);
                CheckIterRectangle(MakeWorld.manySnakes, MakeWorld.SettingsOfTheWorld.chanceForLionBite);
                CheckIterRectangle(MakeWorld.manyTokos, MakeWorld.SettingsOfTheWorld.chanceForLionBite);

                TryEat(MakeWorld.snakeCorpses);
                TryEat(MakeWorld.corpses);

                if (ifBite && !ifBiteSucces)
                {
                    FisMaxLvlOfSpeed = 0;
                    penaltyForLoseFight++;
                }
                ifBite = false;
            }
            if (eat && !goForEat)
            {
                TryEat(MakeWorld.snakeCorpses);
                TryEat(MakeWorld.corpses);
                Eating();
            }
                
            if (penaltyForLoseFight > 0) { penaltyForLoseFight++; if (penaltyForLoseFight == 50) { FisMaxLvlOfSpeed = 5; penaltyForLoseFight = 0; } }
            if (!this.eat && !this.goingForWater && !this.backingAfterDrink && !this.goForEat) { Waiting(400, 600, 250, 450); }
        }
    }
}
