using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Sawanna
{
    /// <summary>
    /// Keeps all settings. Numbers of animals, trees, water, corpses, grasses.
    /// Przeznaczona do rozpoczęcia wszystkiego, ustawienia ilości zwierząt i wszystkich pozostałych atrybutów.
    /// </summary>
    static class MakeWorld
    {
        /// <summary>
        /// Keeps all settings. Numbers of animals, trees, water, corpses, grasses.
        /// Can change speed of the world.
        /// Klasa w której zmienić można ilości zwierząt, wody, drzew, trawie oraz szybkość świata.
        /// </summary>
        public class SettingsOfTheWorld
        {
            public static int waterInMap { get; private set; }              //Keeps numbers of water... so only seriously here we have 1. | Zmienna wskazująca ilość wody na mapie... tak na prawdę tylko 1.

            public static int numberOfTrees { get; private set; }           //Keeps number of trees. | Zmienna wskazująca ilość drzew na mapie.

            public static int numberOfGrasses { get; private set; }         //Keeps number of grasses. | Zmienne które wskazują początkowe ustawienie ilości trawy.       
            public static int numberOfCorpses { get; private set; }         //Keeps number of cropses. | Zmienne które wskazują początkowe ustawienie ilości padliny.
            public static int numberOfSnakeCorpses { get; private set; }

            public static int numbersOfAntelopes { get; private set; }      //Veriables whith numbers of initial settings animals on the map.
            public static int numbersOfLions { get; private set; }          //Zmienne które wskazują początkowe ustawienie
            public static int numbersOfTokos { get; private set; }          //ilości zwierząt na mapie.
            public static int numbersOfHyenas { get; private set; }         
            public static int numbersOfSnakes { get; private set; }

            public static int chanceForLionBite { get; private set; }       //Variables which are needed to counting chance for bite or hunt. Random number in the range  from 0 to the given number.
            public static int chanceForSnakeBite { get; private set; }      //Zmienne które są używane do przeliczania szansy na ugryzie czy też polowanie. Jest losowana liczba
            public static int chanceForTokoAttack { get; private set; }     //w zakresie od 0 do podanej tutaj.
                                                                           
            public static int maxCounterOfAnimalBirth { get; private set; } //Veribles which are needed to count speed of birth. The maximum number is 200 and 
            public static int antelopesBirthControl{ get; private set; }    //the rest is divided modulo by the given numbers in the range from 0 to 200.
            public static int lionsBirhControl { get; private set; }        //Zmienne dzięki którym jest obliczana szybkość
            public static int tokosBirthControl { get; private set; }       //narodzin. Liczba maksymalna jest 200, a reszta 
            public static int hyenasBirthControl { get; private set; }      //jest dzielona modulo przez podane liczby w zakresie
            public static int snakesBirthControl { get; private set; }      //liczb od 0 do 200.

            public static double speedOfLife { get; private set; }          //Every animals use this variable for count speed of eat, etching, drinking and walking | inzmienna której używają zwierzęta do przeliczania szybkości pochłaniania, trawienia, picia, chodzenia ...
            public static double speedEx { get; private set; }              //Save the last setting of speed of time. | Zmienna do zapisywania ostatniego prześpieszenia czasu.


            /// <summary>
            /// Ceeps new speed of each attribiutes that passes or grows.
            /// Przpisanie nowej prędkości działania regeracji trucizny, szybkości jedzenia, szybkości picia, utraty jedzenia, utraty wody, szybkości poruszania się.
            /// </summary>
            /// <param name="newSpeed">SpeedOfLife</param>
            public static void NewSpeedOfLife(double newSpeed)
            {
                speedOfLife = newSpeed;
            }

            /// <summary>
            /// Ceeps the last setting of speed of time, is requaired to return to he initial settings.
            /// Przypisanie wartości poprzedniej zmiany szybkości życia, żeby można było powrócić do stanardowej prędkości.
            /// </summary>
            /// <param name="newSpeedex"></param>
            public static void NewSpeedex(double newSpeedex)
            {
                speedEx = newSpeedex;
            }
            /// <summary>
            /// Set new values for chances of attacks.
            /// Przypisuje nowe wartości dla szans ataków zwierzą.
            /// </summary>
            /// <param name="lion">Zmienia wartość chanceForLionBite.</param>
            /// <param name="snake">Zmienia wartość chanceForSnakeBite.</param>
            /// <param name="toko">Zmienia wartość chanceForTokoAttack.</param>
            public static void SetChansesOfAttacks(int lion, int snake, int toko)
            {
                chanceForLionBite = lion;
                chanceForSnakeBite = snake;
                chanceForTokoAttack = toko;
            }

            /// <summary>
            /// Sets new values for numbers of animals on maps.
            /// Przypisuje nowe wartości dla ilości zwierząt na mapie.
            /// </summary>
            /// <param name="antelopes">Zmienia wartość numbersOfAntelopes.</param>
            /// <param name="lions">Zmienia wartość numbersOfLions.</param>
            /// <param name="tokos">Zmienia wartość numbersOfTokos.<param>
            /// <param name="hyenas">Zmienia wartość numbersOfHyenas.<param>
            /// <param name="snakes">Zmienia wartość numbersOfSnakes.</param>
            public static void SetNumbersOfAnimals(int antelopes, int lions, int tokos, int hyenas, int snakes)
            {
                numbersOfAntelopes = antelopes;
                numbersOfLions = lions;
                numbersOfTokos = tokos;
                numbersOfHyenas = hyenas;
                numbersOfSnakes = snakes;
            }
            /// <summary>
            /// Sets standard values of all settings.
            /// Nadaje standardowe wartości ustawień sawanny.
            /// </summary>
            public static void SetStandardSettings()
            {
                waterInMap = 1;

                numberOfTrees = 4;

                numberOfGrasses = 385;
                numberOfCorpses = 0;
                numberOfSnakeCorpses = 0;

                numbersOfAntelopes = 10;
                numbersOfLions = 5;
                numbersOfTokos = 5;
                numbersOfHyenas = 5;
                numbersOfSnakes = 5;

                chanceForLionBite = 3;
                chanceForSnakeBite = 3;
                chanceForTokoAttack = 3;

                speedOfLife = 1;
                speedEx = 1;
            }

            /// <summary>
            /// Sets standards values of births.
            /// Nadaje standardowe wartośći częstotliwości urodzeń.
            /// </summary>
            public static void SetStandardBirthControl()
            {
                maxCounterOfAnimalBirth = 200;
                antelopesBirthControl = 100;
                lionsBirhControl = 200;
                tokosBirthControl = 50;
                hyenasBirthControl = 200;
                snakesBirthControl = 200;
            }

            /// <summary>
            /// Sets the frequency of birth entered by the user.
            /// Ustawia częstotliwość narodzin wprowadzone przez użytkownika.
            /// </summary>
            public static void SetBirthControl(int antBirthCntrl, int lionBirthCntrl, int tokosBirthCntrl, int hyenasBirthCntrl,
                int snakeBirthCntrl)
            {
                antelopesBirthControl = antBirthCntrl;
                lionsBirhControl = lionBirthCntrl;
                tokosBirthControl = tokosBirthCntrl;
                hyenasBirthControl = hyenasBirthCntrl;
                snakesBirthControl = snakeBirthCntrl;
            }
        }


        public static List<Corpse> corpses { get; private set; }                //Keeps all corpses on map. | Przechowuje całą padline z mapy.
        public static List<SnakeCorpse> snakeCorpses { get; private set; }      //Keeps all snake corpses on map. | Przechowuje całą padline węży z mapy.
        public static List<Grass> grass { get; private set; }                   //Keeps all grasses on map. | Przechowuje wszystkie kępy trawy na mapie.

        public static List<CheckPoint> checkpoints { get; private set; }        //Keeps all Przechowuje checkpointy po których zwierzęta się poruszają jest ich 9.
        public static List<Water> water { get; private set; }                   //Keeps all water on map. | Przechowuje wodę z mapy.
        public static List<Tree> trees { get; private set; }                    //Keeps all trees ona map. | Przechowuje drzewa akacji z mapy.
        //Animals
        public static List<Antelope> manyAntylopes { get; private set; }        //Keeps all antelopes on map. | Przechowuje żywe antylopy z mapy.
        public static List<Lion> manyLions { get; private set; }                //Keeps all lions on map. | Przechowuje żywe lwy z mapy.
        public static List<Toko> manyTokos { get; private set; }                //Keeps all tokos on map. | Przechowuje żywe ptaki toko z mapy.
        public static List<Hyena> manyHyenas { get; private set; }              //Keeps all hyenas on map. | Przechowuje żywe hieny z mapy.
        public static List<Snake> manySnakes { get; private set; }              //Keeps all snakes on map. | Przechowuje żywe węże z mapy.

        public static List<float> BitedAnimalId = new List<float>();            //Keeps all ID numbers of bited animals. Required by multithreding. | Przechowuje numery ID zwierząt które zostały ugryzione. Wymagane przez wielowątkowść.
        public static List<int> NumberIdOfEatenCorpses = new List<int>();       //Keeps all numbers of corpses which was eaten. Required by multithreding. | Przechowuje numery padlin które zostały zjedzone. Wymagane przez wielowątkowść.

        public static int IdAnimalCouter = 1;                                   //Number ID which grows everytime when new animal born. | Numer ID zwierzęcia który się powiększa za każdym razem jak powstaje nowe zwierze.
        public static int CorpsNumberID = 1;                                    //Number of corpse which grows everytime when new corps shows on map. | Numer zwłok który powiększa się gdy powstają nowe zwłoki.
        
        public static bool UserChangesAntylopes = false;                        //Veriables needed to indicate if the animal settings have been change by the user.
        public static bool UserChangesLions = false;                            //When they are on true, uses veriable from UserAnimals Class for births.
        public static bool UserChangesTokos = false;                            //Zmienne potrzebne do wskazywania czy zostały zmienione
        public static bool UserChangesHyenas = false;                           //ustawienia zwierząt przez użytkownika.
        public static bool UserChangesSnakes = false;                           //Gdy są na true, używa zmiennych z klasy UserAnimals do narodzin.

        public static GroupBox Klicked = new GroupBox();

        /// <summary>
        /// Makes all requaired lists. Gives start settings for all of them. 
        /// Sets location for trees, grasses, water and every checkpoints.
        /// Creates first animals.
        /// Tworzy wszystkie niezbędne tablice i przydziela początkowe ustawienia trawie, drzewom, wodzie, 
        /// punktom które muszę odwiedzić zwierzęta w podróży do wody(Checkpointom). 
        /// Przypisuje ilości tablicom w których są zwierzęta, tworzy pierwsze 2 zwierzęta z każdej rasy.
        /// </summary>
        public static void MakingWorld()
        {
            Klicked.BackColor = System.Drawing.Color.Gray;
            Klicked.Dock = System.Windows.Forms.DockStyle.Right;
            Klicked.Location = new System.Drawing.Point(1084, 0);
            Klicked.Name = "Klicked";
            Klicked.Size = new System.Drawing.Size(250, 738);
            Klicked.TabIndex = 0;
            Klicked.TabStop = false;

            corpses = new List<Corpse>();
            snakeCorpses = new List<SnakeCorpse>();
            grass = new List<Grass>();

            checkpoints = new List<CheckPoint>();
            water = new List<Water>();
            trees = new List<Tree>();
       
            manyAntylopes = new List<Antelope>();
            manyLions = new List<Lion>();
            manyTokos = new List<Toko>();
            manyHyenas = new List<Hyena>();
            manySnakes = new List<Snake>();

            SettingsOfTheWorld.SetStandardSettings();
            SettingsOfTheWorld.SetStandardBirthControl();

            checkpoints.Add(new CheckPoint(400, 450));//0 Lion exit. | wyjście od lwów
            checkpoints.Add(new CheckPoint(230, 630));//1 Hyenas exit. | wyjście od hien
            checkpoints.Add(new CheckPoint(600, 685));//2 Lower checkpoint near antelopes. | niżej koło antylop dół
            checkpoints.Add(new CheckPoint(820, 550));//3 Antelopes exit, down. | wyjście od antylop dół
            checkpoints.Add(new CheckPoint(900, 260));//4 Checpoint near water. | ten koło wody
            checkpoints.Add(new CheckPoint(860, 100));//5 Checpoint higher near water. | wyżej koło wody
            checkpoints.Add(new CheckPoint(500, 80)); //6 Higher near antelope enter. | wyżej koło wyjścia antylop
            checkpoints.Add(new CheckPoint(250, 250));//7 Antelope exit. | wyjście od antylop góra
            checkpoints.Add(new CheckPoint(100, 500));//8 Higher near hyenas exit. | wyżej koło hien

            for (int i = 0; i < SettingsOfTheWorld.waterInMap; i++) { water.Add(new Water()); }

            for (int i = 0; i < SettingsOfTheWorld.numberOfGrasses; i++) { grass.Add(new Grass()); }
            for (int i = 0; i < SettingsOfTheWorld.numberOfTrees; i++) { trees.Add(new Tree()); }

            for (int i = 0; i < SettingsOfTheWorld.numberOfCorpses; i++) { corpses.Add(new Corpse(CorpsNumberID ,100, 300, 450)); CorpsNumberID++; }
            for (int i = 0; i < SettingsOfTheWorld.numberOfSnakeCorpses; i++) { snakeCorpses.Add(new SnakeCorpse(CorpsNumberID, 100, 350, 450)); CorpsNumberID++; }

            Random r = new Random();

            if (SettingsOfTheWorld.numbersOfAntelopes > 0)
            {
                for (int i = 0; i < 2; i++)
                {
                    manyAntylopes.Add(new Antelope(IdAnimalCouter, r.Next(0, (int)new Antelope(1, 1, 1).FoodSizeOfStomach),
                        r.Next(0, (int)new Antelope(1, 1, 1).WaterAreaOfWaterInStomach)));
                    IdAnimalCouter++;
                }
            }

            if (SettingsOfTheWorld.numbersOfLions > 0)
            {
                for (int i = 0; i < 2; i++)
                {
                    manyLions.Add(new Lion(IdAnimalCouter, r.Next(0, (int)new Lion(1, 1, 1).FoodSizeOfStomach),
                        r.Next(0, (int)new Lion(1, 1, 1).WaterAreaOfWaterInStomach)));
                    IdAnimalCouter++;
                }
            }

            if (SettingsOfTheWorld.numbersOfTokos > 0)
            {
                for (int i = 0; i < 2; i++)
                {
                    manyTokos.Add(new Toko(IdAnimalCouter, r.Next(0, (int)new Toko(1, 1).FoodSizeOfStomach)));
                    IdAnimalCouter++;
                }
            }

            if (SettingsOfTheWorld.numbersOfHyenas > 0)
            {
                for (int i = 0; i < 2; i++)
                {
                    manyHyenas.Add(new Hyena(IdAnimalCouter, r.Next(0, (int)new Hyena(1, 1, 1).FoodSizeOfStomach),
                        r.Next(0, (int)new Hyena(1, 1, 1).WaterAreaOfWaterInStomach)));
                    IdAnimalCouter++;
                }
            }

            if (SettingsOfTheWorld.numbersOfSnakes > 0)
            {
                for (int i = 0; i < 0; i++)
                {
                    manySnakes.Add(new Snake(IdAnimalCouter, (int)new Hyena(1, 1, 1).FoodSizeOfStomach));
                    IdAnimalCouter++;
                }
            }
        }

        /// <summary>
        /// Sets location of grass.
        /// Przydziela miejsca kępom traw.
        /// </summary>
        public static void AddGrass()
        {
            // int be - How many pixels along the X-axis should draw another club of grass and from which pixel should start another row of clumps. 
            // | Wskazuje co ile pikseli wzdłóż osi X ma rysować kolejne kępę trawy i od którego piksela ma zaczynać kolejny szereg kęp.
            // int ce - Number of index from the list with grasses. | Numer indeksu z listy objektów trawy.
            // int de -  How many pixels along the Y-axis should draw another club of grass and from which pixel should start another column of clumps. 
            // | Wskazuje co ile pikseli wzdłóż osi Y ma rysować kolejne kępę trawy i od którego piksela ma zaczynać kolejny kolumnę kęp.
            int be = 0; 
            int ce = 0; 
            int de = 0;    
            for (int i = 0; i < 15; i++)
            {
                for (int z = 0; z < 16; z++)
                {
                    grass[ce].Rectangle.Location = new Point(be, de);
                    be += 30;
                    ce += 1;
                }
                if (be == 480) { be = 15; }
                else { be = 0; }
                de += 15;
            }

            be = 615;
            de = 580;
            for (int i = 0; i < 9; i++)
            {
                for (int z = 0; z < 15; z++)
                {
                    grass[ce].Rectangle.Location = new Point(be, de);
                    be += 30;
                    ce += 1;
                }
                if (be == 1065) { be = 600; } // The number 1065 is getting from (be = 615) + ((z for z < 15) * (30 wielkość trawy)) and is the size of the screen below. | cyfra 1065 bierze się z (be = 615) plus ((z for z < 15) razy (30 wielkość trawy)) i stanowi wielkość pola poniżej ekranu
                else { be = 615; }
                de += 15;
            }
        }

        /// <summary>
        /// Gives location of water.
        /// Przydziela miejsce wodzie.
        /// </summary>
        public static void AddWater()
        {
            water[0].Rectangle.Location = new Point(900, 0);
        }

        /// <summary>
        /// Gives location of trees.
        /// Przydziela miejsce drzewom.
        /// </summary>
        public static void AddTrees()
        {
            trees[0].Rectangle.Location = new Point(600, 50);
            trees[1].Rectangle.Location = new Point(950, 300);
            trees[2].Rectangle.Location = new Point(200, 250);
            trees[3].Rectangle.Location = new Point(400, 650);
        }

        /// <summary>
        /// Remove all to old animals and every which are dead from list.
        /// Usuwa za stare zwierzęta i te które nieżyją z list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="x"></param>
        public static void RemoveOldAnimals<T>(List<T> x) where T : Animal
        {
            for (int i = 0; i < x.Count; i++)
            {
                if (x[i].Age >= x[i].MaxAge)
                {
                    x[i].AnimalRadioButton.Visible = false;
                    x[i].FoodBar.Visible = false;
                    x[i].WaterBar.Visible = false;
                    x[i].Lives = false;
                }

                if (!x[i].Lives)
                {
                    if (x[i].GetType() == new Snake(1, 1).GetType()) { snakeCorpses.Add(new SnakeCorpse(CorpsNumberID,x[i].SizeOfCorps, x[i].Rectangle.Location.X, x[i].Rectangle.Location.Y)); CorpsNumberID++; }
                    else { corpses.Add(new Corpse(CorpsNumberID ,x[i].SizeOfCorps, x[i].Rectangle.Location.X, x[i].Rectangle.Location.Y)); CorpsNumberID++; }
                    x.RemoveAt(i);
                }
            }
        }

        /// <summary>
        /// Births of new animals.
        /// Narodziny nowych zwierzaków.
        /// </summary>
        /// <typeparam name="T">Accepts only animal class. | Klasa Animal tylko i wyłącznie.</typeparam>
        /// <param name="x">List with animals which is needed to add, the last one is added. | Lista ze zwierzakami, które trzeba dodać, ostatni z list jest dodawany.</param>
        /// <param name="minX">Min X on map where is going to birth. | Minimalny X na mapie w którym ma się urodzić.</param>
        /// <param name="maxX">Max X on map where is going to birth. | Maksymalny X na mapie w którym ma się urodzić.</param>
        /// <param name="minY">Min Y on map where is going to birth. | Minimalny Y na mapie w którym ma się urodzić.</param>
        /// <param name="maxY">Max Y on map where is going to birth. | Minimalny Y na mapie w którym ma się urodzić.</param>
        public static void AddNewAnimals<T>(T x, int minX, int maxX, int minY, int maxY) where T : Animal
        {
            Random r = new Random();
            EventHandler button = new EventHandler(ButtonsClick);

            x.AnimalRadioButton.Location = new Point(r.Next(minX, maxX), r.Next(minY, maxY));
            x.AnimalRadioButton.Click += button;
            x.Rectangle.Location = x.AnimalRadioButton.Location;
            x.FoodBar.Location = new Point(x.AnimalRadioButton.Location.X + 10, x.AnimalRadioButton.Location.Y - 10);
            x.WaterBar.Location = new Point(x.AnimalRadioButton.Location.X + 10, x.AnimalRadioButton.Location.Y - 5);
        }

        /// <summary>
        /// Event handler of animals RadioButtons.
        /// EventHendler Radiobuttonów animalsów.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void ButtonsClick(object sender, EventArgs e)
        {
            AnimalInformation(manyAntylopes);
            AnimalInformation(manyLions);
            AnimalInformation(manyTokos);
            AnimalInformation(manyHyenas);
            AnimalInformation(manySnakes);
            CorpseInformations(corpses);
            CorpseInformations(snakeCorpses);
        }

        /// <summary>
        /// Displays Information about the clicked animal.
        /// Wyświetla informacje na temat klikniętego zwierzęcia.
        /// </summary>
        /// <param name="x">Animal about whom information will be display in right menu bar. | Zwierzę którego informację się będą wyświetlać.</param>
        public static void AnimalInformation<T>(List<T> x) where T : Animal
        {
            for (int i = 0; i < x.Count(); i++) //Checks RadioButtons. | Sprawdza RadioButtony.
            {
                if (x[i].AnimalRadioButton.Checked)
                {
                    x[i].AnimalRadioButton.ForeColor =  Color.Red;
                    x[i].FoodBar.BackColor = Color.Red;
                    x[i].WaterBar.BackColor = Color.Red;
                    MakeWorld.Klicked.Text = x[i].AnimalRadioButton.Name
                         + "\n\nWiek: " + Decimal.Round((decimal)x[i].Age, 2)                       //Age:
                         + "\nMaksymalny wiek życia: " + x[i].MaxAge                                //Max age:
                         + "\nSzybkość starzenia: " + x[i].SpeedOfGettingOlder                      //Speed of getting older:
                         + "\n\nROZMIARY\nWielkość zwierzęcia: " + x[i].SizeOfAnimal                //SIZES\nSize of the animal:
                         + "\nWielkość ciała po śmierci: " + x[i].SizeOfCorps                       //Size of corpse:
                         + "\n\nWODA\nAktualny poziom wody: " + Decimal.Round((decimal)x[i].WaterCurrentLevelOfWater,2)   //WATER\nCurrent level of water:
                         + "\nSzybkośći picia wody: " + x[i].WaterRateOfDrinking                                          //Speed of drinking:
                         + "\nUtraty wody z organizmu: " + x[i].WaterRateOfWaterLos                                       //Rate of water los:
                         + "\nPojemność wody: " + x[i].WaterAreaOfWaterInStomach                                          //Space for water:
                         + "\n\nPOKARM\nAktualny poziom jedzenia w żołądku: " + Decimal.Round((decimal)x[i].FoodCurrentLevelOfFood,2)   //FOOD\nCurrent level of food:
                         + "\nSzybkość jedzenia: " + x[i].FoodRateOfEating                                                              //Rate of eating:        
                         + "\nSzybkość trawienia: " + x[i].FoodAppetite                                                                 //Appetite:
                         + "\nWielkość żołądka: " + x[i].FoodSizeOfStomach                                                              //Size of stomach:
                         + "\nRodzaj pokarmu: " + x[i].FoodTypeOfFood                                                                   //Type of food:
                         + "\n\nTRUCIZNA\nAktualny poziom trucizny: " + Decimal.Round((decimal)x[i].ToxCurrentLvlOfPoison,2)            //TOXIC\nCurrent level of poison:
                         + "\nWymagana ilość trucizny do ugryzienia: " + x[i].ToxLevelOfPosionToBite                                    //Poison required to bite:
                         + "\nMax ilość trucizny: " + x[i].ToxPoisonTank                                                                //Space for poison:
                         + "\nSzybkość regneracji trucizny: " + x[i].ToxRateOfPoisonRegeneration                                        //Speed of poison regeneration:
                         + "\n\nFIZYKA\nAktualna wysokość: " + x[i].FisCurrentAltitude                                                  //PHYSICS\n Current altitude:
                         + "\nMax prędkość: " + x[i].FisMaxLvlOfSpeed                                                                   //Maximum speed:
                         + "\nWspółrzędne: " + x[i].AnimalRadioButton.Location                                                          //Location:
                         + "\n\nPunkty kontrolne: " + x[i].CheckpointsGained                                                            //Checkpoints gainted:
                         + "\nIlość Toksycznych ugryzień: " + x[i].NumberOfToxicBites                                                   //Number of toxic bites:
                         + "\n\nCzynność wykonywana:\n" + x[i].WhatIsGoingOn;                                                           //Operation carried out:
                }

                if (x[i].AnimalRadioButton.ForeColor == Color.Red && !x[i].AnimalRadioButton.Checked)
                {
                    x[i].AnimalRadioButton.ForeColor = Color.Black;
                    x[i].FoodBar.BackColor = Color.Black;
                    x[i].WaterBar.BackColor = Color.Black;
                }
            }
        }

        /// <summary>
        /// Displays Information about the clicked corps.
        /// Wyświetla informacje po boku ekranu na temat zwłok.
        /// </summary>
        /// <typeparam name="T">Accepts only food class. | Przyjmuję tylko jedzenie.</typeparam>
        /// <param name="x">List with corpses. | Lista ze zwłokami.</param>
        public static void CorpseInformations<T>(List<T> x) where T : Food
        {
            for (int i = 0; i < x.Count(); i++) //Sprawdza RadioButtony
            {
                {
                    if (x[i].RadioButton.Checked)
                    {
                        MakeWorld.Klicked.Text = x[i].RadioButton.Name
                              + "\n\nWielkość zwłok: " + Decimal.Round((decimal)x[i].CurrentSize, 2)                //Size of corpse:
                              + "\nMaksymalny czas rozkładu: " + x[i].MaxTimeOfEgzist                               //The maximum time of decomposition:
                              + "\nAktualny czas rozkładu: " + Decimal.Round((decimal)x[i].CurrentTimeOFEgsist, 2)  //Current time of decomposition:
                              + "\nPrędkość rozkładu: " + x[i].RateOFGettingOlder;                                  //Speed of decomposition:
                    }
                }
            }
        }

        /// <summary>
        /// Add animals to the map.
        /// RadioButtons, progress bars.
        /// Dodawanie zwierząt do mapy.
        /// Radiobuttony, progress bary.
        /// </summary>
        /// <param name="x">Zwierzę które trzeba dodać.</param>
        public static void AddAnimalForms<T>(List<T> x, int minX, int maxX, int minY, int maxY) where T : Animal
        {
            EventHandler button = new EventHandler(ButtonsClick);
            Random r = new Random();
            for (int i = 0; i < x.Count; i++)
            {
                x[i].AnimalRadioButton.Location = new Point(r.Next(minX, maxX), r.Next(minY, maxY));
                x[i].AnimalRadioButton.Click += button;
                x[i].Rectangle.Location = x[i].AnimalRadioButton.Location;
                x[i].FoodBar.Location = new Point(x[i].AnimalRadioButton.Location.X + 10, x[i].AnimalRadioButton.Location.Y - 17);
                x[i].WaterBar.Location = new Point(x[i].AnimalRadioButton.Location.X + 10, x[i].AnimalRadioButton.Location.Y - 10); 
            }
        }

        /// <summary>
        /// Refreshes animal on the map.
        /// Odświerzanie zwierząt na mapie.
        /// </summary>
        /// <param name="x">Animal whom will be refreshed. | Zwierzę do odświerzenia.</param>
        public static void RefreshAnimals<T>(List<T> x) where T : Animal
        {
            for (int i = 0; i < x.Count; i++)
            {
                x[i].AnimalRadioButton.Location = new Point(x[i].Rectangle.X, x[i].Rectangle.Y);
                x[i].FoodBar.Location = new Point(x[i].AnimalRadioButton.Location.X + 10, x[i].AnimalRadioButton.Location.Y - 17);
                x[i].WaterBar.Location = new Point(x[i].AnimalRadioButton.Location.X + 10, x[i].AnimalRadioButton.Location.Y - 10);
                if (x[i].GetType() == new Snake(1, 1).GetType()) { x[i].AtrybiutesRunning(x[i].ToxPoisonTank, x[i].ToxCurrentLvlOfPoison); }
                else { x[i].AtrybiutesRunning(x[i].WaterAreaOfWaterInStomach, x[i].WaterCurrentLevelOfWater); }
            }
        }

        /// <summary>
        /// Replaces bite animal to the  corpse.
        /// Dodaje padline w miejsca zwierząt które zostały ugryzione, zabite.
        /// </summary>
        /// <typeparam name="T">Accepts only animal class. | Przyjmuje tylko zwierzęta(Animal).</typeparam>
        /// <param name="a">Animal whom you want replace. | Zwierze które trzeba zastąpić.</param>
        /// <param name="size">Size of the animal whom you want replace. | Rozmiar zwięrzęcia które ma zostać zastąpione.</param>
        /// <param name="x">X of the replaced animal Radio Button. | X radio buttona zastąpianego zwierzęcia.</param>
        /// <param name="y">Y of the replaced animal Radio Button. | Y radio buttona zastąpianego zwierzęcia.</param>
        public static void AddCorpse<T>(T a, double size, int x, int y) where T : Animal
        {
            if (a.GetType() != new Snake(1, 1).GetType())
            {
                corpses.Add(new Corpse(CorpsNumberID, size, x, y));
                CorpsNumberID++;
            }
            else
            {
                snakeCorpses.Add(new SnakeCorpse(CorpsNumberID, size, x, y));
                CorpsNumberID++;
            }
        }
    }
}
