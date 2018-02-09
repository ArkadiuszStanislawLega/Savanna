using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sawanna
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();

            this.cbChoseAnimal.SelectedIndexChanged += new EventHandler(this.SwitchAnimal);

            this.nUdAntelopes.Value = MakeWorld.SettingsOfTheWorld.numbersOfAntelopes;
            this.nUdLions.Value = MakeWorld.SettingsOfTheWorld.numbersOfLions;
            this.nUdTokos.Value = MakeWorld.SettingsOfTheWorld.numbersOfTokos;
            this.nUdHyenas.Value = MakeWorld.SettingsOfTheWorld.numbersOfHyenas;
            this.nUdSnakes.Value = MakeWorld.SettingsOfTheWorld.numbersOfSnakes;

            this.nUdChanceToLionAttack.Value = MakeWorld.SettingsOfTheWorld.chanceForLionBite;
            this.nUdChanceToSnakeBite.Value = MakeWorld.SettingsOfTheWorld.chanceForSnakeBite;
            this.nUdChanceToTokoAttack.Value = MakeWorld.SettingsOfTheWorld.chanceForTokoAttack;

            this.npdBirthAntelopes.Value = MakeWorld.SettingsOfTheWorld.antelopesBirthControl;
            this.npdBirthLwy.Value = MakeWorld.SettingsOfTheWorld.lionsBirhControl;
            this.npdBirthTokos.Value = MakeWorld.SettingsOfTheWorld.tokosBirthControl;
            this.npdBirthHyenas.Value = MakeWorld.SettingsOfTheWorld.hyenasBirthControl;
            this.npdBirthSnakes.Value = MakeWorld.SettingsOfTheWorld.snakesBirthControl;
        }

        /// <summary>
        /// Zapoczątkowuje zmiane informacji w pierwszym oknie.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SwitchAnimal(object sender, EventArgs e)
        {
            if (this.cbChoseAnimal.SelectedIndex == 0){ this.AnimalInfoChange(new Antelope(1, 1, 1));  }
            else if (this.cbChoseAnimal.SelectedIndex == 1) { this.AnimalInfoChange(new Lion(1, 1, 1)); }
            else if (this.cbChoseAnimal.SelectedIndex == 2) { this.AnimalInfoChange(new Toko(1, 1)); }
            else if (this.cbChoseAnimal.SelectedIndex == 3) { this.AnimalInfoChange(new Hyena(1,1,1)); }
            else if (this.cbChoseAnimal.SelectedIndex == 4) { this.AnimalInfoChange(new Snake(1, 1)); }
        }

        /// <summary>
        /// Zmiana informacji w pierwszym oknie.
        /// </summary>
        /// <param name="a">Bierze ustawienia ze zwierzęcia które się poda.</param>
        private void AnimalInfoChange(Animal a)
        {
            this.nUdAge.Value = (decimal)a.Age;
            this.nUdMaxAge.Value = (decimal)a.MaxAge;
            this.nUdSpeedOfGettingOlder.Value = Decimal.Round((decimal)a.SpeedOfGettingOlder, 5);
            this.nUdSizeOfAnimal.Value = Decimal.Round((decimal)a.SizeOfAnimal, 5);
            this.nUdSizeOfCorpse.Value = Decimal.Round((decimal)a.SizeOfCorps, 5);

            this.nUdCurrentAltitude.Value = (decimal)a.FisCurrentAltitude;
            this.nUdMaxAltitude.Value = (decimal)a.FisMaxLvlOfAltitude;
            this.nUdMaxSpeed.Value = Decimal.Round((decimal)a.FisMaxLvlOfSpeed, 5);

            this.nUdPlaceForWater.Value = (decimal)a.WaterAreaOfWaterInStomach;
            this.nUdCurrentLvlOfWater.Value = Decimal.Round((decimal)a.WaterCurrentLevelOfWater, 1);
            this.nUdSpeedOfDrinking.Value = Decimal.Round((decimal)a.WaterRateOfDrinking, 5);
            this.nUdSpeedOfWaterLose.Value = Decimal.Round((decimal)a.WaterRateOfWaterLos, 5);

            this.nUdSizeOfStomach.Value = (decimal)a.FoodSizeOfStomach;
            this.nUdCurrentLvlOfFood.Value = Decimal.Round((decimal)a.FoodCurrentLevelOfFood, 2);
            this.nUdSpeedOfEating.Value = Decimal.Round((decimal)a.FoodRateOfEating, 5);
            this.nUdSpeedOfFoodRun.Value = Decimal.Round((decimal)a.FoodAppetite, 5);

            this.nUdPlaceForToxic.Value = (decimal)a.ToxPoisonTank;
            this.nUdCurrentLvlOfToxic.Value = Decimal.Round((decimal)a.ToxCurrentLvlOfPoison,5);
            this.nUdSpeedOfRegenrationToxic.Value = Decimal.Round((decimal)a.ToxRateOfPoisonRegeneration, 5);
            this.nUdLvlOfNeededToxicForBite.Value = (decimal)a.ToxLevelOfPosionToBite;

        }

        /// <summary>
        /// Wywołuje metode w Animals, do zmian atrybutów wszystkich zweierzą na zmiany wprowadzone przez użytkownika.
        /// </summary>
        /// <typeparam name="T">Przyjmuje tylko i wyłącznie Animal.</typeparam>
        /// <param name="x">Lista ze zwierzętami do zmiany ustawień na te podane przez użytkownika.</param>
        private void ChangeAllAtributes<T>(List <T> x) where T : Animal
        {
            for (int i = 0; i < x.Count; i++)
            {
                x[i].SetFoodAtributes((double)this.nUdSizeOfStomach.Value, (double)this.nUdCurrentLvlOfFood.Value, (double)this.nUdSpeedOfEating.Value, (double)this.nUdSpeedOfFoodRun.Value, x[i].FoodTypeOfFood);
                x[i].SetWaterAtributes((double)this.nUdPlaceForWater.Value, (double)this.nUdCurrentLvlOfWater.Value, (double)this.nUdSpeedOfDrinking.Value, (double)this.nUdSpeedOfWaterLose.Value);
                x[i].SetAgeAndSize((double)this.nUdAge.Value, (double)this.nUdMaxAge.Value, (double)this.nUdSpeedOfGettingOlder.Value, (double)this.nUdSizeOfAnimal.Value, (double)this.nUdSizeOfCorpse.Value,(double)nUdMaxSpeed.Value);
                if (x[i].GetType() == new Toko(1,1).GetType())
                {
                    x[i].FisData(x[i].FisCurrentAltitude, (double)this.nUdMaxAltitude.Value, (double)this.nUdMaxSpeed.Value, (double)this.nUdMaxSpeed.Value);
                }

                if (x[i].GetType() == new Snake(1,1).GetType())
                {
                    x[i].SetPoisonAtribute((double)this.nUdCurrentLvlOfToxic.Value, (double)this.nUdPlaceForToxic.Value, (double)this.nUdSpeedOfRegenrationToxic.Value, (double)this.nUdLvlOfNeededToxicForBite.Value);
                }
            }
        }

        /// <summary>
        /// Wszystko to co dzieje się po wciśnięciu "OK" lub "Zatwierdź" w oknie Ustawień w pierwszje zakładce.
        /// </summary>
        private void CheckOkOrConfirm()
        {
            if (this.cbChoseAnimal.SelectedIndex == 0)
            {
                UserAnimals.Antelope((double)this.nUdAge.Value, (double)this.nUdMaxAge.Value, (double)this.nUdSpeedOfGettingOlder.Value,
                     (double)this.nUdSizeOfAnimal.Value, (double)this.nUdSizeOfCorpse.Value, (double)this.nUdPlaceForWater.Value,
                     (double)this.nUdCurrentLvlOfWater.Value, (double)this.nUdSpeedOfDrinking.Value, (double)this.nUdSpeedOfWaterLose.Value,
                     (double)this.nUdSizeOfStomach.Value, (double)this.nUdCurrentLvlOfFood.Value, (double)this.nUdSpeedOfEating.Value, (double)this.nUdSpeedOfFoodRun.Value,
                     (double)this.nUdMaxSpeed.Value);

                this.ChangeAllAtributes(MakeWorld.manyAntylopes);
                MakeWorld.UserChangesAntylopes = true;
            }
            else if (this.cbChoseAnimal.SelectedIndex == 1)
            {
                UserAnimals.Lion((double)this.nUdAge.Value, (double)this.nUdMaxAge.Value, (double)this.nUdSpeedOfGettingOlder.Value,
                   (double)this.nUdSizeOfAnimal.Value, (double)this.nUdSizeOfCorpse.Value, (double)this.nUdPlaceForWater.Value,
                   (double)this.nUdCurrentLvlOfWater.Value, (double)this.nUdSpeedOfDrinking.Value, (double)this.nUdSpeedOfWaterLose.Value,
                   (double)this.nUdSizeOfStomach.Value, (double)this.nUdCurrentLvlOfFood.Value, (double)this.nUdSpeedOfEating.Value, (double)this.nUdSpeedOfFoodRun.Value,
                   (double)this.nUdMaxSpeed.Value);

                this.ChangeAllAtributes(MakeWorld.manyLions);
                MakeWorld.UserChangesLions = true;
            }
            else if (this.cbChoseAnimal.SelectedIndex == 2)
            {
                UserAnimals.Toko((double)this.nUdAge.Value, (double)this.nUdMaxAge.Value, (double)this.nUdSpeedOfGettingOlder.Value,
                    (double)this.nUdSizeOfAnimal.Value, (double)this.nUdSizeOfCorpse.Value, (double)this.nUdSizeOfStomach.Value, 
                    (double)this.nUdCurrentLvlOfFood.Value, (double)this.nUdSpeedOfEating.Value,  (double)this.nUdSpeedOfFoodRun.Value, 
                    (double)this.nUdMaxSpeed.Value);

                this.ChangeAllAtributes(MakeWorld.manyTokos);
                MakeWorld.UserChangesTokos = true;
            }
            else if (this.cbChoseAnimal.SelectedIndex == 3)
            {
                UserAnimals.Hyena((double)this.nUdAge.Value, (double)this.nUdMaxAge.Value, (double)this.nUdSpeedOfGettingOlder.Value,
                   (double)this.nUdSizeOfAnimal.Value, (double)this.nUdSizeOfCorpse.Value, (double)this.nUdPlaceForWater.Value,
                   (double)this.nUdCurrentLvlOfWater.Value, (double)this.nUdSpeedOfDrinking.Value, (double)this.nUdSpeedOfWaterLose.Value,
                   (double)this.nUdSizeOfStomach.Value, (double)this.nUdCurrentLvlOfFood.Value, (double)this.nUdSpeedOfEating.Value, 
                   (double)this.nUdSpeedOfFoodRun.Value, (double)this.nUdMaxSpeed.Value);

                this.ChangeAllAtributes(MakeWorld.manyHyenas);
                MakeWorld.UserChangesHyenas = true;
            }
            else if (this.cbChoseAnimal.SelectedIndex == 4)
            {
                UserAnimals.Snake((double)this.nUdAge.Value, (double)this.nUdMaxAge.Value, (double)this.nUdSpeedOfGettingOlder.Value,
                   (double)this.nUdSizeOfAnimal.Value, (double)this.nUdSizeOfCorpse.Value, (double)this.nUdPlaceForToxic.Value,
                   (double)this.nUdCurrentLvlOfToxic.Value, (double)this.nUdLvlOfNeededToxicForBite.Value, (double)this.nUdSpeedOfRegenrationToxic.Value,
                   (double)this.nUdMaxSpeed.Value);

                this.ChangeAllAtributes(MakeWorld.manySnakes);
                MakeWorld.UserChangesSnakes = true;
            }
        }

        /// <summary>
        /// Okej button pierwszego okna.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.CheckOkOrConfirm();
            this.Close();
        }

        /// <summary>
        /// Cancel button pierwszego okna.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Zatwierdź button pierwszego okna
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            this.CheckOkOrConfirm();
        }

        /// <summary>
        /// Zwalnia wszystkie zwierzęta o wartość podaną przez użytkownika.
        /// </summary>
        private void AllSetSlowLife()
        {
            MakeWorld.manyAntylopes.ForEach(a => a.SlowLife(MakeWorld.SettingsOfTheWorld.speedEx));
            MakeWorld.manyLions.ForEach(a => a.SlowLife(MakeWorld.SettingsOfTheWorld.speedEx));
            MakeWorld.manyTokos.ForEach(a => a.SlowLife(MakeWorld.SettingsOfTheWorld.speedEx));
            MakeWorld.manyHyenas.ForEach(a => a.SlowLife(MakeWorld.SettingsOfTheWorld.speedEx));
            MakeWorld.manySnakes.ForEach(a => a.SlowLife(MakeWorld.SettingsOfTheWorld.speedEx));
        }

        /// <summary>
        /// Przyśpiesza wszystkie zwierzęta o wartość podaną przez użytkownika.
        /// </summary>
        private void AllSetFastLife()
        {
            MakeWorld.manyAntylopes.ForEach(a => a.FastLife((double)this.nUdSpeedOfLife.Value));
            MakeWorld.manyLions.ForEach(a => a.FastLife((double)this.nUdSpeedOfLife.Value));
            MakeWorld.manyTokos.ForEach(a => a.FastLife((double)this.nUdSpeedOfLife.Value));
            MakeWorld.manyHyenas.ForEach(a => a.FastLife((double)this.nUdSpeedOfLife.Value));
            MakeWorld.manySnakes.ForEach(a => a.FastLife((double)this.nUdSpeedOfLife.Value));
        }

        /// <summary>
        /// Wszystkim zwierzątom których jest nadstan przez zmiane wprowadzoną przez użytkownika,
        /// przełącza wskaźnik Lives na false. Dzięki czemu później automatyczny czyściciel takich zwierząt
        /// usunie je z mapy.
        /// </summary>
        private void ToManyAnimalsLiveFalse()
        {
            if (MakeWorld.manyAntylopes.Count > MakeWorld.SettingsOfTheWorld.numbersOfAntelopes) { MakeWorld.manyAntylopes[MakeWorld.manyAntylopes.Count - 1].Lives = false; }
            if (MakeWorld.manyLions.Count > MakeWorld.SettingsOfTheWorld.numbersOfLions) { MakeWorld.manyLions[MakeWorld.manyLions.Count - 1].Lives = false; }
            if (MakeWorld.manyTokos.Count > MakeWorld.SettingsOfTheWorld.numbersOfTokos) { MakeWorld.manyTokos[MakeWorld.manyTokos.Count - 1].Lives = false; }
            if (MakeWorld.manyHyenas.Count > MakeWorld.SettingsOfTheWorld.numbersOfHyenas) { MakeWorld.manyHyenas[MakeWorld.manyHyenas.Count - 1].Lives = false; }
            if (MakeWorld.manySnakes.Count > MakeWorld.SettingsOfTheWorld.numbersOfSnakes) { MakeWorld.manySnakes[MakeWorld.manySnakes.Count - 1].Lives = false; }
        }

        /// <summary>
        /// Przyśpieszanie i zwalnianie zwierzaków.
        /// </summary>
        private void CheckOrConfirm2()
        {
            MakeWorld.SettingsOfTheWorld.SetNumbersOfAnimals((int)this.nUdAntelopes.Value, (int)this.nUdLions.Value, 
                (int)this.nUdTokos.Value,  (int)this.nUdHyenas.Value, (int)this.nUdSnakes.Value);
            MakeWorld.SettingsOfTheWorld.SetChansesOfAttacks((int)this.nUdChanceToLionAttack.Value, (int)this.nUdChanceToSnakeBite.Value,
                (int)this.nUdChanceToTokoAttack.Value);

            ToManyAnimalsLiveFalse();

            MakeWorld.SettingsOfTheWorld.NewSpeedOfLife((double)this.nUdSpeedOfLife.Value);

            AllSetSlowLife();
            AllSetFastLife();

            MakeWorld.SettingsOfTheWorld.SetBirthControl((int)this.npdBirthAntelopes.Value, (int)this.npdBirthLwy.Value, 
                (int)this.npdBirthTokos.Value, (int)this.npdBirthHyenas.Value, (int)this.npdBirthSnakes.Value);

            MakeWorld.SettingsOfTheWorld.NewSpeedex((double)this.nUdSpeedOfLife.Value);
        }

        /// <summary>
        /// Wciśnięcie przycisku "OK".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonOk2_Click(object sender, EventArgs e)
        {
            this.CheckOrConfirm2();
            this.Close();
        }

        /// <summary>
        /// Wciśnięcie przycisku "Anuluj".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCancel2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Wciśnięcie przycisku "Zatwierdź".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonConfirm2_Click(object sender, EventArgs e)
        {
            this.CheckOrConfirm2();
        }

        /// <summary>
        /// Ustawia w Ustawieniach pierwszej zakładki opcje jadu nieaktywne na zmiany.
        /// </summary>
        private void ToxicReadOnlyTrue()
        {
            this.nUdPlaceForToxic.ReadOnly = true;
            this.nUdCurrentLvlOfToxic.ReadOnly = true;
            this.nUdSpeedOfRegenrationToxic.ReadOnly = true;
            this.nUdLvlOfNeededToxicForBite.ReadOnly = true;
        }

        /// <summary>
        /// Ustawia w Ustawieniach pierwszej zakładki opcje wysokości lotu nieaktywne na zmiany.
        /// </summary>
        private void AltitudeReadOnlyTrue()
        {
            this.nUdCurrentAltitude.ReadOnly = true;
            this.nUdMaxAltitude.ReadOnly = true;
        }

        /// <summary>
        /// Ustawia w Ustawieniach pierwszej zakładki opcje wody nieaktywne na zmiany.
        /// </summary>
        private void WaterReadOnlyTrue()
        {
            this.nUdPlaceForWater.ReadOnly = true;
            this.nUdCurrentLvlOfWater.ReadOnly = true;
            this.nUdSpeedOfDrinking.ReadOnly = true;
            this.nUdSpeedOfWaterLose.ReadOnly = true;
        }

        /// <summary>
        /// Ustawia w Ustawieniach pierwszej zakładki opcje jedzenia nieaktywne na zmiany.
        /// </summary>
        private void FoodReadOnlyTrue()
        {
            this.nUdSizeOfStomach.ReadOnly = true;
            this.nUdCurrentLvlOfFood.ReadOnly = true;
            this.nUdSpeedOfEating.ReadOnly = true;
            this.nUdSpeedOfFoodRun.ReadOnly = true;
        }

        /// <summary>
        /// W zależności od wyboru zwierzęcia przez użytkownika zmienia ustawienia w oknie "Ustawienia".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbChoseAnimal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbChoseAnimal.SelectedIndex == 0) { this.WaterReadOnlyFalse(); this.FoodReadOnlyFalse(); this.ToxicReadOnlyTrue(); this.AltitudeReadOnlyTrue(); }
            else if (this.cbChoseAnimal.SelectedIndex == 1) { this.WaterReadOnlyFalse(); this.FoodReadOnlyFalse(); this.ToxicReadOnlyTrue(); this.AltitudeReadOnlyTrue(); }
            else if (this.cbChoseAnimal.SelectedIndex == 2) { this.ToxicReadOnlyTrue(); this.WaterReadOnlyTrue(); this.AltitudeReadOnlyFalse(); this.FoodReadOnlyFalse(); }
            else if (this.cbChoseAnimal.SelectedIndex == 3) { this.WaterReadOnlyFalse(); this.FoodReadOnlyFalse(); this.ToxicReadOnlyTrue(); this.AltitudeReadOnlyTrue(); }
            else if (this.cbChoseAnimal.SelectedIndex == 4) { this.WaterReadOnlyTrue(); this.FoodReadOnlyTrue(); this.AltitudeReadOnlyTrue(); this.ToxicReadOnlyFalse(); }
        }

        /// <summary>
        /// Ustawia w Ustawieniach pierwszej zakładki opcje jadu aktywne na zmiany.
        /// </summary>
        private void ToxicReadOnlyFalse()
        {
            this.nUdPlaceForToxic.ReadOnly = false;
            this.nUdCurrentLvlOfToxic.ReadOnly = false;
            this.nUdSpeedOfRegenrationToxic.ReadOnly = false;
            this.nUdLvlOfNeededToxicForBite.ReadOnly = false;
        }

        /// <summary>
        /// Ustawia w Ustawieniach pierwszej zakładki opcje wysokości lotu aktywne na zmiany.
        /// </summary>
        private void AltitudeReadOnlyFalse()
        {
            this.nUdCurrentAltitude.ReadOnly = false;
            this.nUdMaxAltitude.ReadOnly = false;
        }

        /// <summary>
        /// Ustawia w Ustawieniach pierwszej zakładki opcje wody aktywne na zmiany.
        /// </summary>
        private void WaterReadOnlyFalse()
        {
            this.nUdPlaceForWater.ReadOnly = false;
            this.nUdCurrentLvlOfWater.ReadOnly = false;
            this.nUdSpeedOfDrinking.ReadOnly = false;
            this.nUdSpeedOfWaterLose.ReadOnly = false;
        }

        /// <summary>
        /// Ustawia w Ustawieniach pierwszej zakładki opcje jedzenia aktywne na zmiany.
        /// </summary>
        private void FoodReadOnlyFalse()
        {
            this.nUdSizeOfStomach.ReadOnly = false;
            this.nUdCurrentLvlOfFood.ReadOnly = false;
            this.nUdSpeedOfEating.ReadOnly = false;
            this.nUdSpeedOfFoodRun.ReadOnly = false;
        }
    }
}
