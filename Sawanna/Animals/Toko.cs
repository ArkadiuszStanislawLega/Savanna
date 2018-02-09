using System.Drawing;
using System.Linq;
using Sawanna.Properties;

namespace Sawanna
{
    class Toko : Animal
    {
        public Toko(float animalID, double age, double maxAge, double speedOfGettingOlder, double sizeOfAnimal, double sizeOfCorps, 
            double sizeOfStomach, double currentLevelOfFood, double rateOfEating, double appetite, double fisMaxLvlOfSpeed, 
            double fisCurrentLvlOfSpeed)
            : this(MakeWorld.IdAnimalCouter, 50)
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

            this.FisMaxLvlOfSpeed = MakeWorld.SettingsOfTheWorld.speedOfLife * fisMaxLvlOfSpeed;
            this.FisCurrentSpeed = MakeWorld.SettingsOfTheWorld.speedOfLife * fisCurrentLvlOfSpeed;
        }

        public Toko(float animalID, double x)
        {
            this.AnimalRadioButton.Image = Resources.toko25;
            this.AnimalRadioButton.Name = "Toko ID: " + animalID;
            this.AnimalID = animalID;

            this.Age = 0;
            this.MaxAge = 5;
            this.SpeedOfGettingOlder = MakeWorld.SettingsOfTheWorld.speedOfLife * 0.001;

            this.SizeOfAnimal = 50;
            this.SizeOfCorps = 50;

            this.FoodSizeOfStomach = 50;
            this.FoodCurrentLevelOfFood = x;
            this.FoodRateOfEating = MakeWorld.SettingsOfTheWorld.speedOfLife * 0.18;
            this.FoodAppetite = MakeWorld.SettingsOfTheWorld.speedOfLife * 0.01;
            this.FoodTypeOfFood = "Padlina węża";

            this.FisCurrentAltitude = 0;
            this.FisMaxLvlOfAltitude = 0;
            this.FisCurrentSpeed = MakeWorld.SettingsOfTheWorld.speedOfLife * 4;
            this.FisMaxLvlOfSpeed = MakeWorld.SettingsOfTheWorld.speedOfLife * 4;

            this.checkpoints = false;
            this.CheckpointsGained = 0;
        }

        /// <summary>
        /// If it enters the flight phase, the position of the altitude and the speed will change to a larger one.
        /// Jeżeli wchodzi w fazę lotu to położenie wysokości i prędkość się zmieniają na większe.
        /// </summary>
        private void Flay()
        {
            this.FisCurrentAltitude = 1;
            this.FisMaxLvlOfSpeed = this.FisCurrentSpeed;
        }

        /// <summary>
        /// If it enters the walking phase, the height position and speed change to smaller.
        /// Jeżeli wchodzi w fazę chodzenia to położenie wysokości i prędkość się zmieniają na mniejsze.
        /// </summary>
        private void Walk()
        {
            this.FisCurrentAltitude = 0;
            this.FisMaxLvlOfSpeed = MakeWorld.SettingsOfTheWorld.speedOfLife * 1;
        }

        /// <summary>
        /// Selecting shares from among possible.
        /// </summary>
        public override void ActionChooser()
        {
            if (MakeWorld.manySnakes.Count > 0 || MakeWorld.snakeCorpses.Count > 0) { this.posibleForEatOrHunt = true; }
            if (eat && this.FoodCurrentLevelOfFood >= this.FoodSizeOfStomach-1)
            {
                this.goForEat = false;
                this.eat = false;
            }
            if (MakeWorld.snakeCorpses.Count == 0) { this.eat = false; }
            if (this.goForEat && MakeWorld.snakeCorpses.Count > 0) { Flay(); this.eat = true; }
            if (MakeWorld.snakeCorpses.Count == 0 && MakeWorld.manySnakes.Count == 0)
            {
                this.posibleForEatOrHunt = false;
                this.goForEat = false;
                this.eat = false;
            }
            if (this.posibleForEatOrHunt && this.FoodCurrentLevelOfFood <= 0 && !this.eat && !this.goForEat)
            {
                this.goForEat = true;
                this.eat = true;
            }
            if (this.posibleForEatOrHunt && this.eat && this.goForEat) { Eating(); }
            if (this.posibleForEatOrHunt && !this.eat && this.goForEat) { GoHunt(); }
            if (!this.eat && !this.goForEat) { Waiting(); }
            if (!this.posibleForEatOrHunt) { Waiting(); }
            if (this.eat) { Walk(); }
        }

        protected override void Eating()
        {
            for (int i = 0; i < MakeWorld.snakeCorpses.Count; i++)
            {
                if (!this.Rectangle.IntersectsWith(MakeWorld.snakeCorpses[i].Rectangle))
                {
                    m.MoveAnimalsToPint<SnakeCorpse, Toko>(MakeWorld.snakeCorpses, this);
                }
                else
                {
                    if (this.FoodCurrentLevelOfFood <= this.FoodSizeOfStomach)
                    {
                        this.FoodCurrentLevelOfFood += this.FoodRateOfEating;
                        MakeWorld.snakeCorpses[i].Eaten(this.FoodRateOfEating);
                        if (this.FoodCurrentLevelOfFood >= 100) { this.FoodCurrentLevelOfFood = 100; }
                    }
                }
            }
        }

        public void Waiting()
        {
            Flay();
            if (!this.wait)
            {
                this.CheckpointsGained = r.Next(0, 40000);
                this.wait = true;

                if (this.CheckpointsGained <= 10000) { this.CheckpointsGained = 0; }
                else if (this.CheckpointsGained > 10000 && this.CheckpointsGained <= 20000) { this.CheckpointsGained = 1; }
                else if (this.CheckpointsGained > 20000 && this.CheckpointsGained <= 30000) { this.CheckpointsGained = 2; }
                else { this.CheckpointsGained = 3; }
            }
            if (this.wait)
            {
                this.Rectangle.Location = m.Rec(this.Rectangle.Location.X, this.Rectangle.Location.Y,
                    MakeWorld.trees[this.CheckpointsGained].Rectangle.Location.X, MakeWorld.trees[this.CheckpointsGained].Rectangle.Location.Y, FisMaxLvlOfSpeed).Location;
                if (this.Rectangle.IntersectsWith(MakeWorld.trees[CheckpointsGained].Rectangle))
                {
                    this.wait = false;
                }
            }
        }

        protected override void GoHunt()
        {
            Flay();
            for (int i = 0; i < MakeWorld.manySnakes.Count; i++)
            {
                m.MoveAnimals<Snake,Toko>(MakeWorld.manySnakes,this);
                for (int x = 0; x < MakeWorld.manySnakes.Count; x++)
                {
                    if (this.Rectangle.IntersectsWith(MakeWorld.manySnakes[x].Rectangle))
                    {
                        Walk();
                        if (r.Next(0, MakeWorld.SettingsOfTheWorld.chanceForTokoAttack) == 0)//JEST LOSOWANIE
                        {
                            this.NumberOfToxicBites++;;
                            MakeWorld.BitedAnimalId.Add(MakeWorld.manySnakes[i].AnimalID);
                        }
                    }
                }
            }
            Flay();
        }
    }
}