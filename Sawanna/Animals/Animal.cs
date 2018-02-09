using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Sawanna.Properties;

namespace Sawanna
{
    public class Animal
    {
        public Rectangle Rectangle = new Rectangle(10, 10, 25, 25);
        public RadioButton AnimalRadioButton = new RadioButton();
        public ProgressBar FoodBar = new ProgressBar();
        public ProgressBar WaterBar = new ProgressBar();

        public bool Lives = true;
        public string WhatIsGoingOn = "";

        protected Random r = new Random();
        protected Moving m = new Moving();

        //LIFE DATA
        public float AnimalID { get; protected set; }
        public double Age { get; protected set; }
        public double MaxAge { get; protected set; }
        public double SpeedOfGettingOlder { get; protected set; }
        //BIO DATA
        public double SizeOfAnimal { get; protected set; }
        public double SizeOfCorps { get; protected set; }
        //WATER DATA
        public double WaterAreaOfWaterInStomach { get; protected set; }
        public double WaterCurrentLevelOfWater { get; protected set; }
        public double WaterRateOfDrinking { get; protected set; }
        public double WaterRateOfWaterLos { get; protected set; }
        //FOOD DATA
        public double FoodSizeOfStomach { get; protected set; }
        public double FoodCurrentLevelOfFood { get; protected set; }
        public double FoodRateOfEating { get; protected set; }
        public double FoodAppetite { get; protected set; }

        public string FoodTypeOfFood { get; protected set; } 
        //TOX DATA
        public double ToxCurrentLvlOfPoison { get; protected set; }
        public double ToxPoisonTank { get; protected set; }
        public double ToxRateOfPoisonRegeneration { get; protected set; }
        public double ToxLevelOfPosionToBite { get; protected set; }
        //FIZ DATA
        public double FisCurrentAltitude { get; protected set; }
        public double FisMaxLvlOfAltitude { get; protected set; }
        public double FisCurrentSpeed { get; protected set; }
        public double FisMaxLvlOfSpeed { get; protected set; }

        public int CheckpointsGained { get; protected set; }
        public int NumberOfToxicBites { get; protected set; }

        protected int numOfIndexInterChckp = 0; //potrzebne w metodzie GoDrink. Pierwszy checkpoint który będzie najbliżej antylopy, a później kolejny i kolejny.
        protected int waitingX = 0;
        protected int waitingY = 0;
        protected int penaltyForLoseFight = 0;

        protected bool checkpoints = false;
        protected bool eat = false;
        protected bool hunting = false;
        protected bool goForEat = false;
        protected bool posibleForEatOrHunt = false;
        protected bool wait = false;
        protected bool goingForWater = false;
        protected bool drink = false;
        protected bool haveIndex4 = false; // potrzebne w metodzie GoDrink
        protected bool backingAfterDrink = false;
        protected bool ifBite = false;
        protected bool ifBiteSucces = false;

        public Animal()
            : this(0, 0, 20, 0.0001, 10, 10, 0, 0, 0, 0, 0, 0, 0, 0, "", 0, 0, 0, 0, 0, 0, 0, 0)
        { }
        protected Animal(float animalID)
           : this(animalID, 0, 20, 0.0001, 10, 10, 0, 0, 0, 0, 0, 0, 0, 0, "", 0, 0, 0, 0, 0, 0, 0, 0)
        { }

        /// <summary>
        /// Sets all stats.
        /// Ustawia wszystkie atrybuty na raz.
        /// </summary>
        /// <param name="animalID">Numer identyfikacyjny zwierzęcia, każdy inny.</param>
        /// <param name="age">Aktualny wiek zwierzęcia.</param>
        /// <param name="maxAge">Maksymalny wiek zwierzęcia.</param>
        /// <param name="speedOfGettingOlder">Szybkość stażenia się.</param>
        /// <param name="sizeOfAnimal">Wielkość zwierzęcia.</param>
        /// <param name="sizeOfCorps">Wielkość padliny pozostawiona po śmierci.</param>
        /// <param name="waterAreaOfWaterInStomach">Miejsce przeznaczone dla wody w żołądku.</param>
        /// <param name="waterCurrentLevelOfWater">Aktualny poziom wody w żołądku.</param>
        /// <param name="waterRateOfDrinking">Szybkość picia wody.</param>
        /// <param name="waterRateOfWaterLos">Szybkość utraty wody z żołądka.</param>
        /// <param name="foodSizeOfStomach">Rozmiar żołądka. </param>
        /// <param name="foodCurrentLevelOfFood">Aktualny poziom jedzenia w żołądku.</param>
        /// <param name="foodRateOfEating">Szybkość pochłaniania jedzenia.</param>
        /// <param name="foodAppetite">Apetyt. Szybkość zmniejszania się pokarmu w żoładku.</param>
        /// <param name="foodTypeOfFood">Typ jedzenia.</param>
        /// <param name="toxCurrentLvlOfPoison">Aktulny poziom jadu.</param>
        /// <param name="toxPoisonTank">Ilość jadu którą możne wyprodukować.</param>
        /// <param name="toxRateOFPosionRegeneration">Tempo produkowania jadu.</param>
        /// <param name="toxLevelOfPosionToBite">Poziom jadu wymagany na jedno ugryzienie.</param>
        /// <param name="fisCurrentHigh">Aktualna wysokość.</param>
        /// <param name="fisMaxLvlOfAltutude">Maksymalny poziom wysokośći.</param>
        /// <param name="fisCurrentSpeed">Aktualna prędkość.</param>
        /// <param name="fisMaxLvlOfSpeed">Maksymalna szybkość poruszania się.</param>
        /// <param name="fisX">Położenie względem osi x.</param>
        /// <param name="fisY">Położenie względem osi y.</param>
        protected Animal(float animalID, double age, double maxAge, double speedOfGettingOlder,
            double sizeOfAnimal, double sizeOfCorps, double waterAreaOfWaterInStomach, double waterCurrentLevelOfWater, double waterRateOfDrinking, double waterRateOfWaterLos,
            double foodSizeOfStomach, double foodCurrentLevelOfFood, double foodRateOfEating, double foodAppetite, string foodTypeOfFood,
            double toxCurrentLvlOfPoison, double toxPoisonTank, double toxRateOFPosionRegeneration, double toxLevelOfPosionToBite,
            double fisCurrentHigh, double fisMaxLvlOfAltutude, double fisCurrentSpeed, double fisMaxLvlOfSpeed
            )
        {
            SetPersonalities(animalID, age, maxAge, speedOfGettingOlder);
            SetBioData(sizeOfAnimal, sizeOfCorps, waterAreaOfWaterInStomach, waterCurrentLevelOfWater, waterRateOfDrinking, waterRateOfWaterLos,
                foodSizeOfStomach, foodCurrentLevelOfFood, foodRateOfEating, foodAppetite, foodTypeOfFood,
                toxCurrentLvlOfPoison, toxPoisonTank, toxRateOFPosionRegeneration, toxLevelOfPosionToBite);
            FisData(fisCurrentHigh, fisMaxLvlOfAltutude, fisCurrentSpeed, fisMaxLvlOfSpeed);

            this.AnimalRadioButton.AutoSize = true;
            this.AnimalRadioButton.CheckAlign = ContentAlignment.BottomLeft;
            this.AnimalRadioButton.FlatAppearance.BorderColor = Color.Green;
            this.AnimalRadioButton.FlatAppearance.MouseDownBackColor = Color.Red;
            this.AnimalRadioButton.FlatStyle = FlatStyle.Flat;
            this.AnimalRadioButton.Size = new Size(25, 25);
            this.AnimalRadioButton.TabIndex = 0;
            this.AnimalRadioButton.TabStop = true;
            this.AnimalRadioButton.TextAlign = ContentAlignment.BottomCenter;
            this.AnimalRadioButton.TextImageRelation = TextImageRelation.ImageAboveText;
            this.AnimalRadioButton.UseVisualStyleBackColor = true;
            this.AnimalRadioButton.BackColor = Color.Transparent;
            this.AnimalRadioButton.UseVisualStyleBackColor = true;

            this.FoodBar.BackColor = SystemColors.MenuText;
            this.FoodBar.ForeColor = Color.PaleVioletRed;
            this.FoodBar.Location = new Point(AnimalRadioButton.Location.X + 10, AnimalRadioButton.Location.Y - 10);
            this.FoodBar.Margin = new Padding(0);
            this.FoodBar.Name = "FoodBar";
            this.FoodBar.Size = new Size(34, 5);
            this.FoodBar.TabIndex = 1;
            this.FoodBar.Maximum = (int)this.FoodSizeOfStomach;
            this.FoodBar.Minimum = 0;
            this.FoodBar.Value = (int)this.FoodCurrentLevelOfFood;
            this.FoodBar.Height = 7;

            this.WaterBar.BackColor = SystemColors.MenuText;
            this.WaterBar.ForeColor = Color.Aqua;
            this.WaterBar.Location = new Point(AnimalRadioButton.Location.X + 10, AnimalRadioButton.Location.Y - 5);
            this.WaterBar.Margin = new Padding(0);
            this.WaterBar.Name = "WaterBr";
            this.WaterBar.Size = new Size(34, 5);
            this.WaterBar.TabIndex = 2;
            this.WaterBar.Minimum = 0;
            this.WaterBar.Height = 7;

            this.CheckpointsGained = 0;
        }

        /// <summary>
        /// Sets the attributes that determine the animal number, age, max age, aging rate and birth speed.
        /// Ustawia atrybuty ustalające numer zwierzęcia, wiek, max wiek, szybkość starzenia i szybkość narodzin.
        /// </summary>
        /// <param name="animalID">Animal identification number, each animal has different. | Numer identyfikacyjny zwierzęcia, każdy inny.</param>
        /// <param name="age">The current age of the animal. | Aktualny wiek zwierzęcia.</param>
        /// <param name="maxAge">The maximum age of the animal | Maksymalny wiek zwierzęcia.</param>
        /// <param name="speedOfGettingOlder">The speed of aging. | Szybkość stażenia się.</param>
        protected virtual void SetPersonalities(float animalID, double age, double maxAge, double speedOfGettingOlder)
        {
            this.AnimalID = animalID;
            this.Age = age;
            this.MaxAge = maxAge;
            this.SpeedOfGettingOlder = speedOfGettingOlder;  
        }

        ///<summary> 
        /// Sets all biological attributes.
        /// Ustawia wszystkie atrybuty biologiczne.
        /// </summary>
        /// <param name="sizeOfAnimal">Wielkość zwierzęcia.</param>
        /// <param name="sizeOfCorps">Wielkość padliny pozostawiona po śmierci.</param>
        /// <param name="waterAreaOfWaterInStomach">Miejsce przeznaczone dla wody w żołądku.</param>
        /// <param name="waterCurrentLevelOfWater">Aktualny poziom wody w żołądku.</param>
        /// <param name="waterRateOfDrinking">Szybkość picia wody.</param>
        /// <param name="waterRateOfWaterLos">Szybkość utraty wody z żołądka.</param>
        /// <param name="foodSizeOfStomach">Rozmiar żołądka. </param>
        /// <param name="foodCurrentLevelOfFood">Aktualny poziom jedzenia w żołądku.</param>
        /// <param name="foodRateOfEating">Szybkość pochłaniania jedzenia.</param>
        /// <param name="foodAppetite">Apetyt. Szybkość zmniejszania się pokarmu w żoładku.</param>
        /// <param name="foodTypeOfFood">Typ jedzenia.</param>
        /// <param name="toxCurrentLvlOfPoison">Aktulny poziom jadu.</param>
        /// <param name="toxPoisonTank">Ilość jadu którą możne wyprodukować.</param>
        /// <param name="toxRateOFPosionRegeneration">Tempo produkowania jadu.</param>
        /// <param name="toxLevelOfPosionToBite">Poziom jadu wymagany na jedno ugryzienie.</param>
        protected virtual void SetBioData(double sizeOfAnimal, double sizeOfCorps, double waterAreaOfWaterInStomach, double waterCurrentLevelOfWater, double waterRateOfDrinking, double waterRateOfWaterLos,
            double foodSizeOfStomach, double foodCurrentLevelOfFood, double foodRateOfEating, double foodAppetite, string foodTypeOfFood,
            double toxCurrentLvlOfPoison, double toxPoisonTank, double toxRateOFPosionRegeneration, double toxLevelOfPosionToBite)
        {
            this.SizeOfAnimal = sizeOfAnimal;
            this.SizeOfCorps = sizeOfCorps;
            SetWaterAtributes(waterAreaOfWaterInStomach, waterCurrentLevelOfWater, waterRateOfDrinking, waterRateOfWaterLos);
            SetFoodAtributes(foodSizeOfStomach, foodCurrentLevelOfFood, foodRateOfEating, foodAppetite, foodTypeOfFood);
            SetPoisonAtribute(toxCurrentLvlOfPoison, toxPoisonTank, toxRateOFPosionRegeneration, toxLevelOfPosionToBite);
        }

        /// <summary>
        /// Changes age, max age, aging rate, size of an animal, speed and size of corpses.
        /// Zmiana wieku, max wieku, szybkości starzenia, wielkości zwierzęcia, szybkość i wielkości zwłok.
        /// </summary>
        /// <param name="age"></param>
        /// <param name="maxAge"></param>
        /// <param name="rateOfGettingOlder"></param>
        /// <param name="sizeOfAnimals"></param>
        /// <param name="sizeOfCorp"></param>
        public virtual void SetAgeAndSize(double age, double maxAge, double rateOfGettingOlder, double sizeOfAnimals, double sizeOfCorp, double maxSpeed)
        {
            this.Age = age;
            this.MaxAge = maxAge;
            this.SpeedOfGettingOlder = rateOfGettingOlder;
            this.SizeOfAnimal = sizeOfAnimals;
            this.SizeOfCorps = sizeOfCorp;
            this.FisMaxLvlOfSpeed = maxSpeed;
        }

        /// <summary>
        /// Settings for attributes related to water.Water prefix for easier search.
        /// Ustawienia atrybutów związanych z wodą/nawodnieniem. Przedrostek Water dla ułatwienia wyszukiwania.
        /// </summary>
        /// <param name="waterAreaOfWaterInStomach">A place for water in the stomach. | Miejsce przeznaczone dla wody w żołądku.</param>
        /// <param name="waterCurrentLevelOfWater">Current water level in the stomach. | Aktualny poziom wody w żołądku.</param>
        /// <param name="waterRateOfDrinking">Speed of dringking. | Szybkość picia wody.</param>
        /// <param name="waterRateOfWaterLos">Speed of water los. | Szybkość utraty wody z żołądka.</param>
        public virtual void SetWaterAtributes(double waterAreaOfWaterInStomach, double watercurRentLevelOfWater, double waterRateOfDrinking, double waterRateOfWaterLos)
        {
            this.WaterAreaOfWaterInStomach = waterAreaOfWaterInStomach;
            this.WaterCurrentLevelOfWater = watercurRentLevelOfWater;
            this.WaterRateOfDrinking = MakeWorld.SettingsOfTheWorld.speedOfLife*waterRateOfDrinking;
            this.WaterRateOfWaterLos = MakeWorld.SettingsOfTheWorld.speedOfLife * waterRateOfWaterLos;
        }

        /// <summary>
        /// Setting food attributes.Prefix Food for ease of search.
        /// Ustawienie atrybutów jedzenia. Przedrostek Food dla ułatwienia wyszukiwania.
        /// </summary>
        /// <param name="foodSizeOfStomach">Size of stomach. | Rozmiar żołądka. </param>
        /// <param name="foodCurrentLevelOfFood">Current level of food in stomach. | Aktualny poziom jedzenia w żołądku.</param>
        /// <param name="foodRateOfEating">Rate of eating. | Szybkość pochłaniania jedzenia.</param>
        /// <param name="foodAppetite">Apetyt. Szybkość zmniejszania się pokarmu w żoładku.</param>
        /// <param name="foodTypeOfFood">Type of food. | Typ jedzenia.</param>
        public virtual void SetFoodAtributes(double foodSizeOfStomach, double foodCurrentLevelOfFood, double foodRateOfEating, double foodAppetite, string foodTypeOfFood)
        {
            this.FoodSizeOfStomach = foodSizeOfStomach;
            this.FoodCurrentLevelOfFood = foodCurrentLevelOfFood;
            this.FoodRateOfEating = MakeWorld.SettingsOfTheWorld.speedOfLife * foodRateOfEating;
            this.FoodAppetite = MakeWorld.SettingsOfTheWorld.speedOfLife * foodAppetite;
            this.FoodTypeOfFood = foodTypeOfFood;
        }

        /// <summary>
        /// Poison attribute settings.The Tox prefix for easier searching.
        /// Ustawienia atrybutów trucizny. Przedrostek Tox dla ułatwienia wyszukiwania.
        /// </summary>
        /// <param name="toxCurrentLvlOfPoison">Current level of poison. | Aktulny poziom jadu.</param>
        /// <param name="toxPoisonTank">Amount of poison that can be produced. | Ilość jadu którą możne wyprodukować.</param>
        /// <param name="toxRateOFPosionRegeneration">The rate of poison production. | Tempo produkowania jadu.</param>
        /// <param name="toxLevelOfPosionToBite">The level of poison required for one bite. | Poziom jadu wymagany na jedno ugryzienie.</param>
        public virtual void SetPoisonAtribute(double toxCurrentLvlOfPoison, double toxPoisonTank, double toxRateOFPosionRegeneration, double toxLevelOfPosionToBite)
        {
            this.ToxCurrentLvlOfPoison = toxCurrentLvlOfPoison;
            this.ToxPoisonTank = toxPoisonTank;
            this.ToxRateOfPoisonRegeneration = MakeWorld.SettingsOfTheWorld.speedOfLife * toxRateOFPosionRegeneration;
            this.ToxLevelOfPosionToBite = toxLevelOfPosionToBite;
        }

        /// <summary>
        /// Sets physical attributes.Fis prefix for easier searching.
        /// Ustawia atrybuty fizyczne. Przedrostek Fis dla ułatwienia wyszukiwania.
        /// </summary>
        /// <param name="fisCurrentHigh">Current altitude. | Aktualna wysokość.</param>
        /// <param name="fisMaxLvlOfAltutude">Maximum altitude level. | Maksymalny poziom wysokośći.</param>
        /// <param name="fisCurrentSpeed">Current speed. | Aktualna prędkość.</param>
        /// <param name="fisMaxLvlOfSpeed">Maximum speed. | Maksymalna szybkość poruszania się.</param>
        /// <param name="fisX">Position relative to the X axis | Położenie względem osi x.</param>
        /// <param name="fisY">Position relative to the Y axis | Położenie względem osi y.</param>
        public virtual void FisData(double fisCurrentHigh, double fisMaxLvlOfAltutude, double fisCurrentSpeed, double fisMaxLvlOfSpeed)
        {
            this.FisCurrentAltitude = fisCurrentHigh;
            this.FisMaxLvlOfAltitude = fisMaxLvlOfAltutude;
            this.FisCurrentSpeed = MakeWorld.SettingsOfTheWorld.speedOfLife * fisCurrentSpeed;
            this.FisMaxLvlOfSpeed = MakeWorld.SettingsOfTheWorld.speedOfLife * fisMaxLvlOfSpeed;
        }

        /// <summary>
        /// He chooses the description on the right bar, at the bottom, what the animal is doing at the moment.
        /// Wybiera opis na prawym pasku, na samym dole co zwierze robi aktualnie.
        /// </summary>
        /// <returns></returns>
        protected string WhatActionIsBeingTaken()
        {
            if (this.eat)  return this.WhatIsGoingOn = "Je: " + this.FoodTypeOfFood + ".";    //"Eating: "
            if (this.hunting && !this.eat)  return this.WhatIsGoingOn = "Poluje.";            //"Hunting: "
            if (this.goForEat && !this.eat)  return this.WhatIsGoingOn = "Szuka jedzenia.";   //"Looking for food: "
            if (this.wait)  return this.WhatIsGoingOn = "Wałęsa się, odpoczywa, robi swoje sprawy ... a tak po za tym co Cie to obchodzi? Nie interesuj się!";  // "He hangs, rests, does his business ... and what's the matter with you? Do not be interested!"
            if (this.goingForWater && !this.drink)  return this.WhatIsGoingOn = "Idzie po wodę.";        //"Goes for water."                                                          
            if (this.drink)  return this.WhatIsGoingOn = "Pije wodę.";                                   //"Drinking." 
            if (this.backingAfterDrink && !this.drink)  return this.WhatIsGoingOn = "Wraca z wodopoju.";  //"He returns from the waterhole."
            return this.WhatIsGoingOn;
        }

        /// <summary>
        /// Full set of requirements for the animal to drink.
        /// Pełny zasób wymagań do tego żeby poszło się zwierze napić.
        /// </summary>
        /// <param name="x">Enter the index number of the checkpoint where you want to end your journey. | Należy wpisać numer indeksu checkpointu na którym ma zakończyć swoją podróż.</param>
        protected virtual void AllForDrink(int x)
        {
            if (!this.backingAfterDrink) { GoDrink(); }
            if (this.WaterCurrentLevelOfWater >= 99) { this.backingAfterDrink = true; }

            if (this.backingAfterDrink)
            {
                if (!this.Rectangle.IntersectsWith(MakeWorld.checkpoints[x].Rectangle)) { BackAfterDrink(); }
                else
                {
                    this.haveIndex4 = false;
                    this.backingAfterDrink = false;
                    this.goingForWater = false;
                }
            }
        }

        /// <summary>
        /// He goes to the waterhole after checkpoints.
        /// Idzie po checkpointach do wodopoju.
        /// </summary>
        protected virtual void GoDrink()
        {
            if (this.haveIndex4 && !this.checkpoints)
            {
                this.Rectangle = m.Rec(this.Rectangle.X, this.Rectangle.Y, 902, 198, this.FisMaxLvlOfSpeed);
                if (this.Rectangle.IntersectsWith(MakeWorld.water[0].Rectangle))
                {
                    Drinking();
                    this.drink = true;
                }
            }

            if (!this.checkpoints && !this.haveIndex4)
            {
                m.MoveAnimalsToPint<CheckPoint, Antelope>(MakeWorld.checkpoints, this);
                for (int i = 0; i < MakeWorld.checkpoints.Count; i++)
                {
                    if (this.Rectangle.IntersectsWith(MakeWorld.checkpoints[i].Rectangle))
                    {
                        this.numOfIndexInterChckp = i;
                        this.numOfIndexInterChckp++;
                        this.checkpoints = true;
                        if (this.numOfIndexInterChckp == 9) { this.numOfIndexInterChckp = 0; }
                    }
                }
            }

            if (this.checkpoints && !this.haveIndex4)
            {
                if (this.Rectangle.IntersectsWith(MakeWorld.checkpoints[4].Rectangle))
                {
                    this.haveIndex4 = true;
                    this.checkpoints = false;
                }

                if (this.numOfIndexInterChckp == 8 && !this.Rectangle.IntersectsWith(MakeWorld.checkpoints[4].Rectangle))
                  this.numOfIndexInterChckp = 0; //jest 9 checkpointów liczonych od 0 

                this.Rectangle = m.Rec(this.Rectangle.X, this.Rectangle.Y, MakeWorld.checkpoints[numOfIndexInterChckp].X(),
                    MakeWorld.checkpoints[this.numOfIndexInterChckp].Y(), this.FisMaxLvlOfSpeed);

                if (this.Rectangle.IntersectsWith(MakeWorld.checkpoints[this.numOfIndexInterChckp].Rectangle)
                    && !this.Rectangle.IntersectsWith(MakeWorld.checkpoints[4].Rectangle))
                 this.numOfIndexInterChckp++; 
            }
        }

        /// <summary>
        /// A method for returning animals after drinking.
        /// Metoda służąca do powrotu zwierząt po napojeniu się.
        /// </summary>
        protected virtual void BackAfterDrink()
        {
            if (this.numOfIndexInterChckp < 9)
            {
                this.Rectangle = m.Rec(this.Rectangle.X, this.Rectangle.Y, MakeWorld.checkpoints[this.numOfIndexInterChckp].Rectangle.X,
                         MakeWorld.checkpoints[this.numOfIndexInterChckp].Rectangle.Y, this.FisMaxLvlOfSpeed);
                if (this.Rectangle.IntersectsWith(MakeWorld.checkpoints[this.numOfIndexInterChckp].Rectangle)) { this.numOfIndexInterChckp++; }
            }
            else
                this.numOfIndexInterChckp = 0; 
        }

        /// <summary>
        /// Checks if the animal is in contact with food and eat it.
        /// Sprawdza czy jest styczność zwierzęcia z jedzeniem i je.
        /// </summary>
        /// <typeparam name="T">He only commits classes inheriting from the Food class. | Pyrzjmuje tylko i wyłącznie klasy dziedziczące z klasy Food.</typeparam>
        /// <param name="x">A list with food to check. | Lista z jedzeniem do sprawdzenia.</param>
        public virtual void TryEat<T>(List<T> x) where T : Food
        {
            for (int i = 0; i < x.Count; i++)
            {
                if (this.Rectangle.IntersectsWith(x[i].Rectangle) && x[i].CurrentSize >= 0)
                {
                    this.goForEat = false;
                    this.eat = true;
                    x[i].Eaten(this.FoodRateOfEating);
                }
                if (x[i].CurrentSize <= 0) { this.eat = false; }
            }
        }

        /// <summary>
        /// Expands
        /// <param FoodCurrentLevelOfFood> The value of food in the stomach </ param>
        /// about
        /// <param FoodRateOfEating> bugs size value </ param>.
        /// To reach 100
        /// =========================================================================
        /// Powiększa 
        /// "FoodCurrentLevelOfFood" Wartość jedzenia w żołądku</param> 
        /// o 
        /// "FoodRateOfEating" wartość wielkości ukąszeń </param>.
        /// Do osiągnięcia 100
        /// </summary>
        protected virtual void Eating()
        {
            if (this.FoodCurrentLevelOfFood <= this.FoodSizeOfStomach)
            {
                this.FoodCurrentLevelOfFood += this.FoodRateOfEating;
                if (this.FoodCurrentLevelOfFood > this.FoodSizeOfStomach)
                {
                    this.FoodCurrentLevelOfFood = this.FoodSizeOfStomach;
                    this.eat = false;
                    this.goForEat = false;
                }
            }
        }

        /// <summary>
        ///  Increases the amount of water in the stomach(WaterCurrentLevelOfWater) by a value of (WaterRateOfDrinking).
        /// Powiększa wartość wody w żołądku (WaterCurrentLevelOfWater) o wartość wielkości jednego hełsta (WaterRateOfDrinking).
        /// </summary>
        protected virtual void Drinking()
        {
            if (this.WaterCurrentLevelOfWater <= this.WaterAreaOfWaterInStomach)
            {
                this.WaterCurrentLevelOfWater += this.WaterRateOfDrinking;
                if (this.WaterCurrentLevelOfWater > 100)
                    this.WaterCurrentLevelOfWater = 100;
            }
        }

        /// <summary>
        /// They move along a specific path, after next checkpoints.
        /// Poruszają się wzdłuż określonej ścieżki, po kolejnych checkpointach.
        /// </summary>
        protected virtual void GoToCheckPoint()
        {
            this.Rectangle.Location = m.Rec(this.Rectangle.Location.X, this.Rectangle.Location.Y,
                MakeWorld.checkpoints[this.CheckpointsGained].X(), MakeWorld.checkpoints[this.CheckpointsGained].Y(), this.FisMaxLvlOfSpeed).Location;

            if (this.Rectangle.IntersectsWith(MakeWorld.checkpoints[this.CheckpointsGained].Rectangle))
            {
                this.CheckpointsGained++;
                if (this.CheckpointsGained == MakeWorld.checkpoints.Count()) { this.CheckpointsGained = 0; }
            }
        }

        /// <summary>
        ///  He checks if some rectengle interacted with another rectengle of the animal.
        /// Sprawdza czy jakiś rectengle miał interakcje z innym rectenglem zwierzęcia.
        /// </summary>
        /// <typeparam name="T">Works only with the animal class. | Działa tylko z klasą animal.</typeparam>
        /// <param name="x">The list from which he checks. | Lista z której sprawdza.</param>
        protected virtual void CheckIterRectangle<T>(List<T> x, int chanceForBite) where T : Animal
        {
            for (int i = 0; i < x.Count(); i++)
            {
                if (this.Rectangle.IntersectsWith(x[i].Rectangle))
                {
                    if (x[i].FisCurrentAltitude == 0)
                    {
                        this.ifBite = true;
                        if (r.Next(0, chanceForBite) == 0) 
                        {
                            this.ifBiteSucces = true;
                            this.NumberOfToxicBites++;
                            MakeWorld.BitedAnimalId.Add(x[i].AnimalID);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Checks whether there is a possibility of toxic biting.
        /// Sprawdza czy jest możliwość ugryzienia toksycznego.
        /// </summary>
        /// <returns></returns>
        protected virtual bool CheckLvlOfPoison()
        {
            if (this.ToxCurrentLvlOfPoison - this.ToxLevelOfPosionToBite >= 0)
                return true; 
            else
                return false; 
        }

        /// <summary>
        /// It is used to circulate randomly in a specific region.
        /// Służy do krążenia losowo w określonym rejonie.
        /// </summary>
        /// <param name="minX">The minimum range of X in which animals are to move. | Minimalny zakres X w którym mają się zwierzaki poruszać.</param>
        /// <param name="maxX">The maximum range of X in which animals are to move. | Maksymalny zakres X w którym mają się zwierzaki poruszać.</param>
        /// <param name="minY">The minimum range of Y in which animals are to move. | Minimalny zakres Y w którym mają się zwierzaki poruszać.</param>
        /// <param name="maxY">The maximum range of Y in which animals are to move. | Maksymalny zakres Y w którym mają się zwierzaki poruszać.</param>
        protected virtual void Waiting(int minX, int maxX, int minY, int maxY)
        {
            int random = (int)Math.Sqrt(r.Next(0, 10000) * r.Next(0, 10000));
            if (!this.wait)
            {
                if (random >= 500 && random <= 600)
                {
                    Random r1 = new Random();
                    this.waitingX = r1.Next(minX, maxX);
                    this.waitingY = r1.Next(minY, maxY);
                    random = (int)Math.Sqrt(r1.Next(0, 1000) * r.Next(0, 1000) / 3);
                }
                else
                {
                    this.waitingX = r.Next(minX, maxX);
                    this.waitingY = r.Next(minY, maxY);
                }
                this.wait = true;
            }
            else
            {
                this.Rectangle = m.Rec(this.Rectangle.X, this.Rectangle.Y, this.waitingX, this.waitingY, this.FisMaxLvlOfSpeed);
                if (random >= 500 && random <= 600)
                     this.wait = false; 
            }
        }

        protected virtual void GoHunt() { }

        public virtual void ActionChooser() { }

        /// <summary>
        /// Setting windowsForms to "false" during a deadly blow by others.
        /// Ustawienie windowsFormów na "false" zwierzęcia w czasie śmiertelnego uderzenia przez inne.
        /// </summary>
        public virtual void HitToDeath()
        {
            this.AnimalRadioButton.Visible = false;
            this.FoodBar.Visible = false;
            this.WaterBar.Visible = false;
            this.Lives = false;
        }

        /// <summary>
        /// The expiry of all biological values ​​according to the assigned values.
        /// Upływ wszystkich wartości biologicznych zgodnie z przypisanymi wartościami.   
        /// <param name="waterOrToxicMax">You have to give the value that will be in the lower progressbar. Max WaterSizeInStomach or ToxPoisonTank. | Trzeba podać wartość która będzie w niższym "progresbarze". Max WaterSizeInStomach albo ToxPoisonTank. </param>
        /// <param name="waterOrToxicCurr">You have to give the value that will be in the lower progressbar. Current WaterCurrentLevelOfWater or ToxCurrentLvlOfPoison. Trzeba podać wartość która będzie w niższym "progresbarze". Aktualny WaterCurrentLevelOfWater albo ToxCurrentLvlOfPoison. </param>
        /// </summary>
        public virtual void AtrybiutesRunning(double waterOrToxicMax, double waterOrToxicCurr)
        {
            WhatActionIsBeingTaken();
            if (this.Age <= this.MaxAge)
                this.Age += this.SpeedOfGettingOlder; 

            if (this.WaterCurrentLevelOfWater > 0)
                this.WaterCurrentLevelOfWater -= this.WaterRateOfWaterLos; 
            else
                this.WaterCurrentLevelOfWater = 0;

            if (this.WaterCurrentLevelOfWater > 100)
                this.WaterCurrentLevelOfWater = 100; 

            if (this.FoodCurrentLevelOfFood > 0)
                this.FoodCurrentLevelOfFood -= this.FoodAppetite; 
            else
                this.FoodCurrentLevelOfFood = 0; 

            if (this.ToxCurrentLvlOfPoison <= this.ToxPoisonTank)
            {
                this.ToxCurrentLvlOfPoison += this.ToxRateOfPoisonRegeneration;
                if (this.ToxCurrentLvlOfPoison > this.ToxPoisonTank) { this.ToxCurrentLvlOfPoison = this.ToxPoisonTank; }
                if (this.ToxCurrentLvlOfPoison < 0) { this.ToxCurrentLvlOfPoison = 0; }
            }
            this.FoodBar.Maximum = (int)this.FoodSizeOfStomach;
            this.FoodBar.Value = (int)this.FoodCurrentLevelOfFood;

            this.WaterBar.Maximum = (int)waterOrToxicMax;
            this.WaterBar.Value = (int)waterOrToxicCurr;
        }

        /// <summary>
        /// Increase the value of the animal's statistics by the SpeedOfLife value.
        /// Zwiększenie wartości statystyk zwierzęcia o wartość SpeedOfLife.
        /// </summary>
        /// <param name="x">SpeedOfLife</param>
        public void FastLife(double x)
        {
            this.SpeedOfGettingOlder *= x;
            this.WaterRateOfDrinking *= x;
            this.WaterRateOfWaterLos *= x;
            this.FoodRateOfEating *= x;
            this.FoodAppetite *= x;
            this.ToxRateOfPoisonRegeneration *= x;
            this.FisCurrentSpeed *= x;
            this.FisMaxLvlOfSpeed *= x;
        }

        /// <summary>
        /// Return to the value of the animal's statistics to basic, by dividing by the digit that was previously raised.
        /// Powrót do  wartości statystyk zwierzęcia do podstawowych, poprzez dziele o cyfrę którą wcześniej było podnoszone.
        /// </summary>
        /// <param name="x">SpeedOfLife</param>
        public void SlowLife(double x)
        {
            this.SpeedOfGettingOlder /= x;
            this.WaterRateOfDrinking /= x;
            this.WaterRateOfWaterLos /= x;
            this.FoodRateOfEating /= x;
            this.FoodAppetite /= x;
            this.ToxRateOfPoisonRegeneration /= x;
            this.FisCurrentSpeed /= x;
            this.FisMaxLvlOfSpeed /= x;
        }

        protected class Moving
        {
            protected List<int> distanceToTarget = new List<int>();

            /// <summary>
            /// Movement of the animal towards the other animal.
            /// Poruszanie się zwierzęcia względem drugiego zwierzęcia.
            /// </summary>
            /// <param name="a">A list of animals that stand or where a particular animal is heading. |  Lista zwierząt które stoją, lub do których zmierza określone zwierze.</param>
            /// <param name="b">The animal that moves. | Zwierze które się porusza.</param>
            public void MoveAnimals<T, U>(List<T> a, Animal movingAnimal) where T : Animal
                                                                          where U : Animal
            {
                for (int z = 0; z < a.Count; z++) { CheckDistance(a[z].Rectangle, movingAnimal.Rectangle); }
                for (int i = 0; i < distanceToTarget.Count; i++)
                    if (distanceToTarget[i] == distanceToTarget.Min())
                        movingAnimal.Rectangle = Rec(movingAnimal.Rectangle.X, movingAnimal.Rectangle.Y, a[i].Rectangle.X, a[i].Rectangle.Y, movingAnimal.FisMaxLvlOfSpeed);
                distanceToTarget.Clear();
            }

            /// <summary>
            /// Move the animal in relation to the standing thing.
            /// Poruszanie się zwierzaka względem stojącej rzeczy.
            /// </summary>
            /// <typeparam name="T">It accepts elements inherited from the IRectangleble interface | Przyjmuje elementy dziedziczone z interfejsu IRectangleble</typeparam>
            /// <typeparam name="U">It accepts only inherited from animals. | Przyjmuje tylko dziedziczone ze zwierząt.</typeparam>
            /// <param name="a"> List with objects to which he will follow. | Lista z obiektami do którego będzie podąrzać.</param>
            /// <param name="movingAnimal"> An animal that moves. | Zwierzę które się porusza.</param>
            public void MoveAnimalsToPint<T, U>(List<T> a, Animal movingAnimal) where T : IRectangleble
                                                                                where U : Animal
            {
                for (int z = 0; z < a.Count(); z++) { CheckDistance(new Rectangle(a[z].X(),a[z].Y(),25,25) , movingAnimal.Rectangle); }
                for (int i = 0; i < a.Count(); i++)
                {
                    if ( a.Count == 1 ) movingAnimal.Rectangle = Rec(movingAnimal.Rectangle.X, movingAnimal.Rectangle.Y, a[0].X(), a[0].Y(), movingAnimal.FisMaxLvlOfSpeed);
                    else if (distanceToTarget[i] == distanceToTarget.Min())
                    {
                        movingAnimal.Rectangle = Rec(movingAnimal.Rectangle.X, movingAnimal.Rectangle.Y, a[i].X(), a[i].Y(), movingAnimal.FisMaxLvlOfSpeed);
                        distanceToTarget.Clear();
                        break;
                    }
                }
                distanceToTarget.Clear();
            }

            /// <summary>
            /// Checks the diagonal distances between selected Rectangles.
            /// Sprawdza odległości po przekątnej między wybranymi Rectanglami.
            /// </summary>
            /// <param name="a">Object a.</param>
            /// <param name="b">Object b.</param>
            public void CheckDistance(Rectangle a, Rectangle b)
            { distanceToTarget.Add((int)Math.Sqrt((int)Math.Pow((a.X - b.X), 2) + (int)Math.Pow((a.Y - b.Y), 2))); }

            public Rectangle Rec(int movingX, int movingY, int x2, int y2, double speed)
            {
                //CHODZENIE
                if (movingX > x2 && x2 > 0) { movingX -= (int)speed; }
                else if (movingX < x2)
                    if ((movingX - x2) < 5 && (movingX - x2) < -5)
                        movingX += (int)speed;

                if (movingY > y2 && y2 > 0) { movingY -= (int)speed; }
                else if (movingY < y2)
                    if ((movingY - y2) < 5 && (movingY - y2) < -5)
                        movingY += (int)speed;

                return new Rectangle(movingX, movingY, 25, 25);
            }
        }
    }
}
