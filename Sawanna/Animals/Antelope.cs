using System;
using System.Drawing;
using Sawanna.Properties;

namespace Sawanna
{
    class Antelope : Animal
    {
        private int numberOfIndex; //potrzebny do zapamiętywania numeru wylosowanego kępy trawy.

        private bool waitingRun = false;
        private bool zeroFoodAndWater = false;

        public Antelope(float animalID, double age, double maxAge, double speedOfGettingOlder, double sizeOfAnimal, double sizeOfCorps, double areaOfWaterInStomach,
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

        public Antelope(int animalID, double lvlOfFood, double lvlOfWater) 
        {
            this.AnimalRadioButton.Image = Resources.antylopa25;

            this.AnimalRadioButton.Name = "Antylopa ID: " + animalID;
            this.AnimalID = animalID;
            this.Age = 0;
            this.MaxAge = 10;
            this.SpeedOfGettingOlder = MakeWorld.SettingsOfTheWorld.speedOfLife * 0.001;

            this.SizeOfAnimal = 350;
            this.SizeOfCorps = 350;

            this.FoodSizeOfStomach = 100;
            this.FoodCurrentLevelOfFood = lvlOfFood;
            this.FoodRateOfEating = MakeWorld.SettingsOfTheWorld.speedOfLife * 0.4;
            this.FoodAppetite = MakeWorld.SettingsOfTheWorld.speedOfLife * 0.1;
            this.FoodTypeOfFood = "Trawa";

            this.WaterAreaOfWaterInStomach = 100;
            this.WaterCurrentLevelOfWater = lvlOfWater;
            this.WaterRateOfDrinking = MakeWorld.SettingsOfTheWorld.speedOfLife * 0.4;
            this.WaterRateOfWaterLos = MakeWorld.SettingsOfTheWorld.speedOfLife * 0.05;

            this.ToxCurrentLvlOfPoison = 0;
            this.ToxPoisonTank = 0;
            this.ToxRateOfPoisonRegeneration = 0;
            this.ToxLevelOfPosionToBite = 1;

            this.FisMaxLvlOfAltitude = 0;
            this.FisCurrentSpeed = MakeWorld.SettingsOfTheWorld.speedOfLife * 0;
            this.FisMaxLvlOfSpeed = MakeWorld.SettingsOfTheWorld.speedOfLife * 3;
        }

        /// <summary>
        /// Selecting shares from among possible.
        /// </summary>
        public override void ActionChooser()
        {
            if (this.FoodCurrentLevelOfFood <= 0 && !this.drink && !this.zeroFoodAndWater)
            {
                this.goingForWater = false;
                this.backingAfterDrink = false;
            }

            if (!this.goingForWater && !this.backingAfterDrink && !this.drink)
            {
                if (this.FoodCurrentLevelOfFood <= 90)
                {
                    for (int i = 0; i < MakeWorld.grass.Count; i++)
                    {
                        if (this.Rectangle.IntersectsWith(MakeWorld.grass[i].Rectangle))
                        {
                            this.waitingRun = false;
                            this.eat = true;
                            this.Eating();
                        }
                    }
                }
                else { this.Waiting(); }
            }

            if (this.eat) { this.Eating(); if (this.FoodCurrentLevelOfFood >= 99) { this.eat = false; }  }
            if (!this.goingForWater && !this.backingAfterDrink && !this.eat && !this.goForEat && !this.drink) { this.Waiting(); }
            if (this.WaterCurrentLevelOfWater <= 0 && !this.goingForWater ) { this.goingForWater = true; }
            if (this.goingForWater) { this.waitingRun = false; this.GoDrink(); }
            if (this.WaterCurrentLevelOfWater <= 0 && this.FoodCurrentLevelOfFood <= 0 ) { this.zeroFoodAndWater = true; }
            if (this.zeroFoodAndWater) { this.GoDrink(); }

            if (this.drink && this.WaterCurrentLevelOfWater >= 99)
            {
                this.backingAfterDrink = true;
                this.goingForWater = false;
                this.drink = false;
                this.haveIndex4 = false;
                this.numOfIndexInterChckp = 5;
            }
            if (this.backingAfterDrink && !eat)
            {
                this.Rectangle = m.Rec(this.Rectangle.X, this.Rectangle.Y, MakeWorld.checkpoints[this.numOfIndexInterChckp].Rectangle.X,
                       MakeWorld.checkpoints[this.numOfIndexInterChckp].Rectangle.Y, this.FisMaxLvlOfSpeed);
                if (this.Rectangle.IntersectsWith(MakeWorld.checkpoints[this.numOfIndexInterChckp].Rectangle))
                {
                    this.numOfIndexInterChckp++;
                }
                if (this.numOfIndexInterChckp == 7) { this.backingAfterDrink = false; }
            }
        }

        public void Waiting()
        {
            if (!this.waitingRun)
            {
                if (this.AnimalRadioButton.Location.X <= 505 && this.AnimalRadioButton.Location.Y <= 800)
                {
                    this.numberOfIndex = r.Next(0, 240);
                    this.waitingRun  = true;
                }
                else
                {
                    this.numberOfIndex = r.Next(241, MakeWorld.grass.Count);
                    this.waitingRun = true;
                }
               
            }
            if (this.waitingRun)
            {
                this.Rectangle = m.Rec(this.Rectangle.X, this.Rectangle.Y, MakeWorld.grass[this.numberOfIndex].Rectangle.X,
                    MakeWorld.grass[this.numberOfIndex].Rectangle.Y, this.FisMaxLvlOfSpeed);
                if (this.Rectangle.IntersectsWith(MakeWorld.grass[this.numberOfIndex].Rectangle))
                {
                    this.waitingRun = false;
                }
            }
        }
    }
}
