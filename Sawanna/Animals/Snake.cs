using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sawanna.Properties;

namespace Sawanna
{
    class Snake : Animal
    {
        public Snake(float animalID, double age, double maxAge, double speedOfGettingOlder, double sizeOfAnimal, 
            double sizeOfCorps, double toxicTank, double toxicCurrentLvl, double toxicRegeneration, double toxicNeedToBite, 
            double fisMaxLvlOfSpeed)
            : this(MakeWorld.IdAnimalCouter, 50)
        {
            this.AnimalRadioButton.Image = Resources.snake25;
            this.AnimalRadioButton.Name = "Wąż ID: " + animalID;

            this.AnimalID = animalID;
            this.Age = age;
            this.MaxAge = maxAge;
            this.SpeedOfGettingOlder = MakeWorld.SettingsOfTheWorld.speedOfLife * speedOfGettingOlder;

            this.SizeOfAnimal = sizeOfAnimal;
            this.SizeOfCorps = sizeOfCorps;

            this.ToxCurrentLvlOfPoison = toxicCurrentLvl;
            this.ToxLevelOfPosionToBite = toxicNeedToBite;
            this.ToxPoisonTank = MakeWorld.SettingsOfTheWorld.speedOfLife * toxicTank;
            this.ToxRateOfPoisonRegeneration = MakeWorld.SettingsOfTheWorld.speedOfLife * toxicRegeneration;

            this.FisMaxLvlOfSpeed = MakeWorld.SettingsOfTheWorld.speedOfLife * fisMaxLvlOfSpeed;
        }

        public Snake(float animalID, double LvlOfToxic)
        {
            this.AnimalRadioButton.Image = Resources.snake25;

            this.AnimalRadioButton.Name = "Wąż ID: " + animalID;
            this.AnimalID = animalID;
            this.Age = 0;
            this.MaxAge = 5;
            this.SpeedOfGettingOlder = MakeWorld.SettingsOfTheWorld.speedOfLife * 0.0001;

            this.SizeOfAnimal = 125;
            this.SizeOfCorps = 125;

            this.FoodSizeOfStomach = 100;
            this.FoodCurrentLevelOfFood = 100;
            this.FoodRateOfEating = MakeWorld.SettingsOfTheWorld.speedOfLife * 0;
            this.FoodAppetite = MakeWorld.SettingsOfTheWorld.speedOfLife * 0;
            this.FoodTypeOfFood = " ";

            this.WaterAreaOfWaterInStomach = 0;
            this.WaterCurrentLevelOfWater = 0;
            this.WaterRateOfDrinking = 0;
            this.WaterRateOfWaterLos = 0;

            this.ToxCurrentLvlOfPoison = LvlOfToxic;
            this.ToxPoisonTank = 100;
            this.ToxRateOfPoisonRegeneration = MakeWorld.SettingsOfTheWorld.speedOfLife * 0.05;
            this.ToxLevelOfPosionToBite = 20;

            this.FisCurrentAltitude = 0;
            this.FisMaxLvlOfAltitude = 0;
            this.FisCurrentSpeed = MakeWorld.SettingsOfTheWorld.speedOfLife * 0;
            this.FisMaxLvlOfSpeed = MakeWorld.SettingsOfTheWorld.speedOfLife * 2;

            this.FoodBar.Maximum = (int)this.FoodSizeOfStomach;
            this.WaterBar.ForeColor = Color.GreenYellow;
            this.WaterBar.Maximum = (int)this.ToxPoisonTank;
            this.WhatIsGoingOn = "Ssssssssssssssssyczy i podąża swoimi ścieżkami.";

            this.CheckpointsGained = 2;
        }

        /// <summary>
        /// Selecting shares from among possible.
        /// </summary>
        public override void ActionChooser()
        {
            GoToCheckPoint();
            if (CheckLvlOfPoison())
            {
                if (!ifBite)
                {
                    CheckIterRectangle(MakeWorld.manyAntylopes, MakeWorld.SettingsOfTheWorld.chanceForSnakeBite);
                    CheckIterRectangle(MakeWorld.manyHyenas, MakeWorld.SettingsOfTheWorld.chanceForSnakeBite);
                    CheckIterRectangle(MakeWorld.manyLions, MakeWorld.SettingsOfTheWorld.chanceForSnakeBite);
                    CheckIterRectangle(MakeWorld.manyTokos, MakeWorld.SettingsOfTheWorld.chanceForSnakeBite);

                    if (ifBite && !ifBiteSucces)
                    {
                        FisMaxLvlOfSpeed = 0;
                        penaltyForLoseFight++;
                    }
                }
                else  this.ToxCurrentLvlOfPoison -= this.ToxLevelOfPosionToBite; ifBite = false; 
            }
            if (penaltyForLoseFight > 0)
            {
                penaltyForLoseFight++;
                if (penaltyForLoseFight == 50) FisMaxLvlOfSpeed = MakeWorld.SettingsOfTheWorld.speedOfLife * 2; penaltyForLoseFight = 0;
            } 
        }
    }
}

