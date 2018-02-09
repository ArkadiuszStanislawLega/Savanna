using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using Sawanna.Properties;


namespace Sawanna
{
    using static MakeWorld;

    public partial class Sawanna : Form
    {
        /// <summary>
        /// Main window where the savanna is created.
        /// There are drawing the map, every animals and active elements of the map. (water and trees)
        /// The lower menu bar with the selection of animals and settings.
        /// THE RIGHT MENU BAR with statistic of animals is in the static class MakeWorld!!
        /// ==========================================================================================
        /// Główne okno w którym powstaje sawanna. 
        /// Rysowana jest mapa, wszystkie zwierzęta i aktywne elementy mapy. (woda i drzewa)
        /// Dolny pasek menu z wyborem zwierząt oraz ustawieniami.
        /// BOCZNY PASEK ze statystykami zwierząt jest w klasie statycznej MakeWorld!!!
        /// </summary>
        private int birthCounter = 0;       //Needed to convert the births of animals. | Potrzebny do przeliczania rodzenia się zwierząt.
        private int sec = 0;                //Needed to delay the refreshing of animal attributes. | Potrzebny do opóźniania odświerzania atrybutów zwierząt.
        private bool info = false;          //For the purpose of displaying information about the program. | Na potrzeby wyświetlenia informacji o programie.

        public Sawanna()
        {
            InitializeComponent();
            this.Controls.Add(MakeWorld.Klicked);

            this.BackgroundImage = new Bitmap(Resources.mapa);
            EventHandler button = new EventHandler(this.ButtonsClick);

            MakingWorld();
            AddWater();
            AddGrass();
            AddTrees();

            AllAddAnimalForms();
            AllAddControls();

            this.timer1.Start();
        }

        /// <summary>
        /// Add all Windows Forms.
        /// Dodaje wszystkie windowsFormsy.
        /// </summary>
        private void AllAddAnimalForms()
        {
            AddAnimalForms(manyAntylopes, 0, 400, 0, 200);
            AddAnimalForms(manyLions, 400, 600, 250, 450);
            AddAnimalForms(manyTokos, 500, 650, 0, 70);
            AddAnimalForms(manyHyenas, 0, 100, 500, 700);
            AddAnimalForms(manySnakes, 575, 625, 675, 700);
        }

        /// <summary>
        /// Add all Windows Forms to the Window.
        /// Dodaje wszystkie windowsformsy do okna.
        /// </summary>
        private void AllAddControls()
        {
            manyAntylopes.ForEach(a => AddControls(a));
            manyLions.ForEach(a => AddControls(a));
            manyTokos.ForEach(a => AddControls(a));
            manyHyenas.ForEach(a => AddControls(a));
            manySnakes.ForEach(a => AddControls(a));
        }

        /// <summary>
        /// The order of the activities performed.
        /// Kolejność wykonywanych czynności.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void T_Tick(object sender, EventArgs e)
        {
            if (!info) { info = true;  InfoAboutAutor();  }
            MakeNamesOfMenuBar();
            AllMenuBarChenger();
            AllCheckingBites();
            AllCheckingWhatWasEaten();
            AllRemoveTooMuchAnimalas();
            AllRemoveUnsizebleCorpses();
            AllRemoveOldAnimals();
            AllAddCorpses();
            AllRefreshAnimals();
            AllThreadSynchronizer();
            /*AllActionChoosers();       Method that works without division into threads. 
                                         If this method is on, you should turn off AllThreadSynchronizer. 
                                         Metoda która działa bez podziału na wątki. 
                                         Jeżeli ta jest włączona to AllThreadSynchronizer powinna być wyłączona.*/
            AllAddAnimals();
            InhibitorOfLeftBar(sender, e);
        }

        /// <summary>
        /// Calculates the time of adding animals and adds them until they reach the amount given by the user, 
        /// or they will have the amount given in the basic settings.
        /// Oblicza czas dodawania zwierząt i je dodaje do czasu aż osiągną ilość podaną przez użytkowanika, 
        /// lub będą miały ilość podaną w ustawieniach podstawowych.
        /// </summary>
        public void AllAddAnimals()
        {
            Random r = new Random();

            if (this.birthCounter <= SettingsOfTheWorld.maxCounterOfAnimalBirth)
            {
                if (this.birthCounter % SettingsOfTheWorld.antelopesBirthControl == 0 && manyAntylopes.Count < SettingsOfTheWorld.numbersOfAntelopes)
                {
                    if (UserChangesAntylopes)
                    {
                        manyAntylopes.Add(new Antelope(IdAnimalCouter, UserAnimals.AAge, UserAnimals.AMaxAge, UserAnimals.ASpeedOfGettingOlder,
                            UserAnimals.ASizeOfAnimal, UserAnimals.ASizeOfCorps, UserAnimals.AWaterAreaOfWaterInStomach, UserAnimals.AWaterCurrentLevelOfWater,
                            UserAnimals.AWaterRateOfDrinking, UserAnimals.AWaterRateOfWaterLos, UserAnimals.AFoodSizeOfStomach, UserAnimals.AFoodCurrentLevelOfFood,
                            UserAnimals.AFoodRateOfEating, UserAnimals.AFoodAppetite, UserAnimals.AFisMaxLvlOfSpeed));
                    }
                    else
                    {
                        manyAntylopes.Add(new Antelope(IdAnimalCouter, r.Next(0, (int)new Antelope(1, 1, 1).FoodSizeOfStomach), (int)new Antelope(1, 1, 1).WaterAreaOfWaterInStomach));
                    }

                    IdAnimalCouter++;
                    AddNewAnimals(manyAntylopes.Last(), 0, 400, 0, 200);
                    AddControls(manyAntylopes.Last());
                }

                if (this.birthCounter % SettingsOfTheWorld.lionsBirhControl == 0 && manyLions.Count < SettingsOfTheWorld.numbersOfLions)
                {
                    if (UserChangesLions)
                    {
                        manyLions.Add(new Lion(IdAnimalCouter, UserAnimals.LAge, UserAnimals.LMaxAge, UserAnimals.LSpeedOfGettingOlder,
                            UserAnimals.LSizeOfAnimal, UserAnimals.LSizeOfCorps, UserAnimals.LWaterAreaOfWaterInStomach, UserAnimals.LWaterCurrentLevelOfWater,
                            UserAnimals.LWaterRateOfDrinking, UserAnimals.LWaterRateOfWaterLos, UserAnimals.LFoodSizeOfStomach, UserAnimals.LFoodCurrentLevelOfFood,
                            UserAnimals.LFoodRateOfEating, UserAnimals.LFoodAppetite, UserAnimals.LFisMaxLvlOfSpeed));
                    }
                    else
                    {
                        manyLions.Add(new Lion(IdAnimalCouter, r.Next(0, (int)new Lion(1, 1, 1).FoodSizeOfStomach),
                        (int)new Lion(1, 1, 1).WaterAreaOfWaterInStomach));
                    }
                    IdAnimalCouter++;
                    AddNewAnimals(manyLions.Last(), 400, 600, 250, 450);
                    AddControls(manyLions.Last());
                }

                if (this.birthCounter % SettingsOfTheWorld.tokosBirthControl == 0 && manyTokos.Count < SettingsOfTheWorld.numbersOfTokos)
                {
                    if (UserChangesTokos)
                    {
                        manyTokos.Add(new Toko(IdAnimalCouter, UserAnimals.TAge, UserAnimals.TMaxAge, UserAnimals.TSpeedOfGettingOlder,
                            UserAnimals.TSizeOfAnimal, UserAnimals.TSizeOfCorps, UserAnimals.TFoodSizeOfStomach, UserAnimals.TFoodCurrentLevelOfFood,
                            UserAnimals.TFoodRateOfEating, UserAnimals.TFoodAppetite, UserAnimals.TFisMaxLvlOfSpeed, UserAnimals.TFisMaxLvlOfSpeed));
                    }
                    else
                    {
                        manyTokos.Add(new Toko(IdAnimalCouter, r.Next(0, (int)new Toko(1, 1).FoodSizeOfStomach)));
                    }
                    IdAnimalCouter++;
                    AddNewAnimals(manyTokos.Last(), 500, 650, 0, 70);
                    AddControls(manyTokos.Last());
                }

                if (this.birthCounter % SettingsOfTheWorld.hyenasBirthControl == 0 && manyHyenas.Count < SettingsOfTheWorld.numbersOfHyenas)
                {
                    if (UserChangesHyenas)
                    {
                        manyHyenas.Add(new Hyena(IdAnimalCouter, UserAnimals.HAge, UserAnimals.HMaxAge, UserAnimals.HSpeedOfGettingOlder,
                            UserAnimals.HSizeOfAnimal, UserAnimals.HSizeOfCorps, UserAnimals.HWaterAreaOfWaterInStomach, UserAnimals.HWaterCurrentLevelOfWater,
                            UserAnimals.HWaterRateOfDrinking, UserAnimals.HWaterRateOfWaterLos, UserAnimals.HFoodSizeOfStomach, UserAnimals.HFoodCurrentLevelOfFood,
                            UserAnimals.HFoodRateOfEating, UserAnimals.HFoodAppetite, UserAnimals.HFisMaxLvlOfSpeed));
                    }
                    else
                    {
                        manyHyenas.Add(new Hyena(IdAnimalCouter, r.Next(0, (int)new Hyena(1, 1, 1).FoodSizeOfStomach), r.Next(0, (int)new Hyena(1, 1, 1).WaterAreaOfWaterInStomach)));
                    }
                    IdAnimalCouter++;
                    AddNewAnimals(manyHyenas.Last(), 0, 100, 500, 700);
                    AddControls(manyHyenas.Last());
                }

                if (this.birthCounter % SettingsOfTheWorld.snakesBirthControl == 0 && manySnakes.Count < SettingsOfTheWorld.numbersOfSnakes)
                {
                    if (UserChangesSnakes)
                    {
                        manySnakes.Add(new Snake(IdAnimalCouter, UserAnimals.SAge, UserAnimals.SMaxAge, UserAnimals.SSpeedOfGettingOlder,
                            UserAnimals.SSizeOfAnimal, UserAnimals.SSizeOfCorps, UserAnimals.SToxicTank, UserAnimals.SToxicCurrentLvl,
                            UserAnimals.SToxicRateOfRegeneration, UserAnimals.SToxicLvlToBite, UserAnimals.SFisMaxLvlOfSpeed));
                    }
                    else
                    {
                        manySnakes.Add(new Snake(IdAnimalCouter, r.Next(0, (int)new Snake(1, 1).ToxPoisonTank)));
                    }
                    IdAnimalCouter++;
                    AddNewAnimals(manySnakes.Last(), 575, 625, 675, 700);
                    AddControls(manySnakes.Last());
                }
            }
            else { this.birthCounter = 0; }
            this.birthCounter++;
        }

        /// <summary>
        /// Add single Windows Forms of animal to the window.
        /// Dodaje pojedyncze WindowsFormy zwierząt do okna.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a"></param>
        public void AddControls<T>(T a) where T : Animal
        {
            Controls.Add(a.AnimalRadioButton);
            Controls.Add(a.FoodBar);
            Controls.Add(a.WaterBar);
        }

        /// <summary>
        /// If the user changes the number of animals to less than it is currently, then the excess of these animals is removed.
        /// Jeżeli użytkownik zmieni ilość zwierząt na mniejszą niż aktualnie jest, to  jest usuwany nadmiar tych zwierząt.
        /// </summary>
        /// <typeparam name="T">It accepts only the Animal class. | Przyjmuje tylko i wyłącznie klase Animal.</typeparam>
        /// <param name="x">List with animals. | Lista z zwierzętami.</param>
        /// <param name="y">Number of animals which currently should be on the map. | Ilość zwierząt które powinny być na mapie.</param>
        private void RemoveTooMuchAnimalas<T>(List<T> x, int y) where T : Animal
        {
            if (x.Count > y)
            {
                x[x.Count - 1].AnimalRadioButton.Visible = false;
                x[x.Count - 1].FoodBar.Visible = false;
                x[x.Count - 1].WaterBar.Visible = false;
                x[x.Count - 1].Lives = false;
                x.RemoveAt(x.Count - 1);
            }
        }

        /// <summary>
        /// In the bottom menu bar changes numbers of animals which user can select, this is number of currently live animals.
        /// W menu u dołu ekranu, zmienia ilości zwierząt możliwych do zaznaczenia, aktualnie żyjących zwierząt.
        /// </summary>
        /// <typeparam name="T">It accepts only the Animal class. | Przyjmuję tylko Animal.</typeparam>
        /// <param name="x">"Table" with Windows Formses, next buttons of the drop-down list in the menu. | "Tablica" z windowsFormamy, kolejnymi przyciskami listy rozwijalnej w menu.</param>
        /// <param name="y">List with specific animals. | Lista z konkretnymi zwierzętami.</param>
        private void MenuBarChanger<T>(ToolStripItemCollection x, List <T> y) where T : Animal                                                                     
        {
            if (x.Count != y.Count)
            {
                if (x.Count > 0) { do { x[0].Dispose(); } while (x.Count != 0); }

                for (int i = 0; i < y.Count; i++)
                {
                    ToolStripMenuItem elementlisty = new ToolStripMenuItem();
                    elementlisty.Name = "" + i;
                    elementlisty.Size = new System.Drawing.Size(82, 20);
                    elementlisty.Text = y[i].AnimalRadioButton.Name;
                    elementlisty.Click += new EventHandler(AllMenuClicker);
                    x.Add(elementlisty);
                }
            }
        }

        /// <summary>
        /// Turning on every ActionChoosers in all animals.
        /// Włącza wszystkie ActionChoosery zwierząt;
        /// </summary>
        private void AllActionChoosers()
        {
            manyAntylopes.ForEach(a => a.ActionChooser());
            manyLions.ForEach(a => a.ActionChooser());
            manyTokos.ForEach(a => a.ActionChooser());
            manyHyenas.ForEach(a => a.ActionChooser());
            manySnakes.ForEach(a => a.ActionChooser());
        }

        /// <summary>
        /// Makes all names of animals in bottom menu bar.
        /// Robi nazwy z ilościami zwierząt na dolnym pasku.
        /// </summary>
        private void MakeNamesOfMenuBar()
        {
            this.tsmiAntelopes.Text = "Antylopy " + MakeWorld.manyAntylopes.Count;
            this.tsmiLions.Text = "Lwy " + MakeWorld.manyLions.Count;
            this.tsmiTokos.Text = "Toko " + MakeWorld.manyTokos.Count;
            this.tsmiHyenas.Text = "Hieny " + MakeWorld.manyHyenas.Count;
            this.tsmiSnakes.Text = "Węże " + MakeWorld.manySnakes.Count;
        }

        /// <summary>
        /// Changes all buttons with animals names in bottom menu bar.
        /// Zmienia wszystkie przyciski zwierząt na dalnym pasku menu.
        /// </summary>
        public void AllMenuBarChenger()
        {
            MenuBarChanger(tsmiAntelopes.DropDownItems, manyAntylopes);
            MenuBarChanger(tsmiLions.DropDownItems, manyLions);
            MenuBarChanger(tsmiTokos.DropDownItems, manyTokos);
            MenuBarChanger(tsmiHyenas.DropDownItems, manyHyenas);
            MenuBarChanger(tsmiSnakes.DropDownItems, manySnakes);
        }

        /// <summary>
        /// Removes ALL excess animals when the user changes the number of animals smaller than the current state on the map.
        /// Usuwa zwierzęta jeżeli jest ich za dużo względem ustawień zmienionych przez użytkownika.
        /// </summary>
        public void AllRemoveTooMuchAnimalas()
        {
            RemoveTooMuchAnimalas(manyAntylopes, MakeWorld.SettingsOfTheWorld.numbersOfAntelopes);
            RemoveTooMuchAnimalas(manyLions, MakeWorld.SettingsOfTheWorld.numbersOfLions);
            RemoveTooMuchAnimalas(manyTokos, MakeWorld.SettingsOfTheWorld.numbersOfTokos);
            RemoveTooMuchAnimalas(manyHyenas, MakeWorld.SettingsOfTheWorld.numbersOfHyenas);
            RemoveTooMuchAnimalas(manySnakes, MakeWorld.SettingsOfTheWorld.numbersOfSnakes);
        }

        /// <summary>
        /// Remove ALL to old animals from the map.
        /// Usuwa za stare zwierzęta z mapy.
        /// </summary>
        private void AllRemoveOldAnimals()
        {
            RemoveOldAnimals(manyAntylopes);
            RemoveOldAnimals(manyLions);
            RemoveOldAnimals(manyTokos);
            RemoveOldAnimals(manyHyenas);
            RemoveOldAnimals(manySnakes);
        }

        /// <summary>
        /// Refresh position of ALL animals in the map.
        /// refreshing: buttons, bars, rectangles 
        /// lapse: food, water, years ...
        /// ===========================================
        /// Odświerza pozycje wszystich zwierząt.
        /// odświerzanie: buttonów, barów, rectanglów
        /// upływanie: jedzenia, wody, lat ...
        /// </summary>
        private void AllRefreshAnimals()
        {
            RefreshAnimals(manyAntylopes);
            RefreshAnimals(manyLions);
            RefreshAnimals(manyTokos);
            RefreshAnimals(manyHyenas);
            RefreshAnimals(manySnakes);
        }

        /// <summary>
        /// Add new created corpses to the map, lapse of attributes of corpses.
        /// Dodaje nowo powstałą padline, zmiana atrybutów zwłok.
        /// </summary>
        private void AllAddCorpses()
        {
            EventHandler button = new EventHandler(this.ButtonsClick);

            foreach (Corpse corpse in corpses)
            { corpse.AtributesRunning(); this.Controls.Add(corpse.RadioButton); corpse.RadioButton.Click += button; }

            foreach (SnakeCorpse snakeCorpse in snakeCorpses)
            { snakeCorpse.AtributesRunning(); this.Controls.Add(snakeCorpse.RadioButton); snakeCorpse.RadioButton.Click += button; }
        }

        /// <summary>
        /// Removes corpses which was eaten and they doesn't have any size already.
        /// Usuwa zwłoki które zostały zjedzone i nie mają rozmairu już.
        /// </summary>
        private void AllRemoveUnsizebleCorpses()
        {
            for (int i = 0; i < snakeCorpses.Count; i++) { { if (snakeCorpses[i].CurrentSize <= 0) { snakeCorpses.RemoveAt(i); } } }
            for (int i = 0; i < corpses.Count; i++) { { if (corpses[i].CurrentSize <= 0) { corpses.RemoveAt(i); } } }
        }

        /// <summary>
        /// Retarder of refreshing right bar with stats.
        /// Opóźniacz odświerzania prawego paska.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InhibitorOfLeftBar(object sender, EventArgs e)
        {
            if (sec == 7) 
            {
                ButtonsClick(sender, e);
                sec = 0;
            }
            sec++;
        }

        /// <summary>
        /// Different variants of dividing into threads.
        /// Creates all threads for every single animal and synchronize them.
        /// An empty space "\n" between the blocks of notes indicates a separate case to be divided into threads.
        /// If one is turned on the rest should be commented on.
        /// ======================================================================================================
        /// Różne warianty podzielenia wątków.
        /// Tworzy wszystkie wątki na każde zwierzę i synchronizuje je.
        /// Przedział pusty "\n" między blokami notatek świadczy o samodzielnym oddzielnym przypadku 
        /// do podzielenia na wątki. Jeżeli jeden jest włączony resztę należy zakomentować.
        /// </summary>
        private void AllThreadSynchronizer()
        {
            Parallel.ForEach(manyAntylopes, a => a.ActionChooser());
            Parallel.ForEach(manyLions, a => a.ActionChooser());
            Parallel.ForEach(manyTokos, a => a.ActionChooser());
            Parallel.ForEach(manyHyenas, a => a.ActionChooser());
            Parallel.ForEach(manySnakes, a => a.ActionChooser());

            //Task t = Task.Factory.StartNew(() =>
            //{
            //    Task.Factory.StartNew(() => manyAntylopes.ForEach(a => a.ActionChooser()),
            //    TaskCreationOptions.AttachedToParent);
            //    Task.Factory.StartNew(() => manyLions.ForEach(a => a.ActionChooser()),
            //    TaskCreationOptions.AttachedToParent);
            //    Task.Factory.StartNew(() => manyTokos.ForEach(a => a.ActionChooser()),
            //    TaskCreationOptions.AttachedToParent);
            //    Task.Factory.StartNew(() => manyHyenas.ForEach(a => a.ActionChooser()),
            //    TaskCreationOptions.AttachedToParent);
            //    Task.Factory.StartNew(() => manySnakes.ForEach(a => a.ActionChooser()),
            //    TaskCreationOptions.AttachedToParent);
            //});
            //t.Wait();

            //Task.Factory.StartNew(() => manyAntylopes.ForEach(a => a.ActionChooser()));
            //Task.Factory.StartNew(() => manyLions.ForEach(a => a.ActionChooser()));
            //Task.Factory.StartNew(() => manyTokos.ForEach(a => a.ActionChooser()));
            //Task.Factory.StartNew(() => manyHyenas.ForEach(a => a.ActionChooser()));
            //Task.Factory.StartNew(() => manySnakes.ForEach(a => a.ActionChooser()));

            //List<Thread> threads = new List<Thread>();
            //foreach (Antelope a in MakeWorld.manyAntylopes) { threads.Add(new Thread(a.ActionChooser)); }
            //foreach (Lion l in MakeWorld.manyLions) { threads.Add(new Thread(l.ActionChooser)); }
            //foreach (Toko t in MakeWorld.manyTokos) { threads.Add(new Thread(t.ActionChooser)); }
            //foreach (Hyena h in MakeWorld.manyHyenas) { threads.Add(new Thread(h.ActionChooser)); }
            //foreach (Snake s in MakeWorld.manySnakes) { threads.Add(new Thread(s.ActionChooser)); }
            //threads.ForEach(t => t.Start());
            //threads.ForEach(t => t.Join());
        }

        /// <summary>
        /// The result of clicking on the animal.
        /// Wynik kliknięcia na zwierze.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ButtonsClick(Object sender, EventArgs e)
        {
            MakeWorld.ButtonsClick(sender, e);
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1 = new System.Windows.Forms.Timer();
            timer1.Interval = 40;
            timer1.Tick += new EventHandler(T_Tick);
            timer1.Start();
        }
           
        /// <summary>
        /// Drawing background, earier prepared: water, trees and grases.  
        /// Rysowanie tła, wcześniej utworzonych: wody, drzew i trawy.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Sawanna_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            for (int i = 0; i < trees.Count(); i++) { g.DrawImage(trees[i].imageTree, trees[i].Rectangle); }

            //for (int i = 0; i < grass.Count(); i++) { g.DrawImage(grass[i].bmp, grass[i].Rectangle); }//Shows place where the antelopes can eat. | Pokazuje miejsca gdzie antylopy mogą jeść.
            //for (int i = 0; i < checkpoints.Count(); i++) { g.FillRectangle(Brushes.Red, checkpoints[i].Rectangle); }//Shows checkpoints. | Pokazują miejsca dojść do punktów.
        }

        /// <summary>
        /// Event handler of buttom menu bar.
        /// Łapacz zdarzenia na menu u dołu ekranu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SettingsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
        }

        /// <summary>
        /// Checking which button menu bar is selected by user.
        /// Sprawdza który z menu u dołu ekranu jest zaznaczony przez użytkownika.
        /// </summary>
        /// <typeparam name="T">It accepts only the Animal class. | Przyjmuję tylko Animal.</typeparam>
        /// <param name="x">List with windows formses to check. | Lista z "WindowsFormami" do sprawdzenia.</param>
        /// <param name="y">List with specific animals. | Lista z konkretnymi zwierzętami.</param>
        private void CheckWhoIsClicked<T>(ToolStripItemCollection x, List<T> y) where T : Animal
        {
            for (int i = 0; i < x.Count; i++)
                if (x[i].Pressed) y[i].AnimalRadioButton.Checked = true;
        }

        /// <summary>
        /// When you choose animal from bottom menu bar, these change Radio Button of chosen animal as selected.
        /// Kiedy wybieramy z menu antylope to zmienia radioButtona animala, na tego którego wybraliśmy.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AllMenuClicker(object sender, EventArgs e)
        {
            CheckWhoIsClicked(tsmiAntelopes.DropDownItems, manyAntylopes);
            CheckWhoIsClicked(tsmiLions.DropDownItems, manyLions);
            CheckWhoIsClicked(tsmiTokos.DropDownItems, manyTokos);
            CheckWhoIsClicked(tsmiHyenas.DropDownItems, manyHyenas);
            CheckWhoIsClicked(tsmiSnakes.DropDownItems, manySnakes);
        }

        /// <summary>
        /// Checks which ID of animal was bitten.
        /// Whan if someone was bitten, then he send a method HitDoTeath 
        /// which couses desepire of animal from map and shows the corpse.
        /// If any, give him the use of the HitToDeath method which 
        /// causes the animal to be removed from the map and the corpse appears for them.
        /// =============================================================================
        /// Sprawdza jakie numery zwierząt były ugryzione.
        /// Jeżeli któryś był, podaje mu użycie metody HitToDeath która powoduje
        /// że zwierze jest usuwane z mapy i pojawia się za nie padlina.
        /// </summary>
        /// <typeparam name="T">It accepts only the Animal class. | Przyjmuje tylko Animal. </typeparam>
        /// <param name="x">List with specific animals. | Lista z konkretnmi zwierzętami. </param>
        private void CheckBites<T>(List <T> x) where T: Animal
        {
            try
            {
                for (int z = 0; z < x.Count; z++)
                {
                    for (int i = 0; i < BitedAnimalId.Count; i++)
                    {
                        if (x[z].AnimalID == BitedAnimalId[i])
                        {
                            x[z].HitToDeath();
                            AddCorpse(x[z], x[z].SizeOfCorps, x[z].AnimalRadioButton.Location.X, x[z].AnimalRadioButton.Location.Y);
                            BitedAnimalId.RemoveAt(i);
                            x.RemoveAt(z);
                        }
                    }
                }
            }
            catch (Exception) {  }
        }

        /// <summary>
        /// Checks ALL animals if they have been bitten. 
        /// Sprawdza wszystkie zwierzęta czy były ugryzione.
        /// </summary>
        private void AllCheckingBites()
        {
            if (MakeWorld.BitedAnimalId.Count > 0)
            {
                CheckBites(manyAntylopes);
                CheckBites(manyLions);
                CheckBites(manyTokos);
                CheckBites(manyHyenas);
                CheckBites(manySnakes);
            }
        }

        /// <summary>
        /// Remove eaten corpses.
        /// Usuwa padline zjedzoną.
        /// </summary>
        /// <typeparam name="T">It accepts only the Food class. | Przyjmuje tylko Food.</typeparam>
        /// <param name="x">List whith ID of eaten animals. | Lista z numerami ID padlin które zostały zjedzone.</param>
        private void CheckingWhatWasEaten<T>(List<T> x) where T : Food
        {
            for (int z = 0; z < x.Count; z++)
            {
                for (int i = 0; i < NumberIdOfEatenCorpses.Count; i++)
                {
                    if (x[z].numberID == NumberIdOfEatenCorpses[i])
                    {
                        x[z].RadioButton.Visible = false;
                        NumberIdOfEatenCorpses.RemoveAt(i);
                    }
                }
            }
        }

        /// <summary>
        /// He checks both types of corpses (corpses and snake corpses) in terms of eating.
        /// Sprwadza obydwa rodzaje padliny pod względem zjedzenia.
        /// </summary>
        private void AllCheckingWhatWasEaten()
        {
            CheckingWhatWasEaten(snakeCorpses);
            CheckingWhatWasEaten(corpses);
        }

        /// <summary>
        /// Information about author.
        /// Informacje o autorze.
        /// </summary>
        private void InfoAboutAutor()
        {
            //MessageBox.Show("The savannah was written for the purpose of passing the object \"Programming Object\".\n\n\n The author is: Arkadiusz Łęga" , "Information about Author");
              MessageBox.Show("Sawanna została napisana na potrzeby zaliczenia przedmiotu \"Programowanie Obiektowe\".\n\n\nAutorem jest: Arkadiusz Łęga", "Informacje o Autorze");
        }

        /// <summary>
        /// Event handler info about author.
        /// Łapacz zdarzenia kliknięcia informacji o autorze.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiInfoAboutAuthor_Click(object sender, EventArgs e)
        {
            InfoAboutAutor();
        }
    }
}
