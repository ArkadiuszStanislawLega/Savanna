using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sawanna
{
    /// <summary>
    /// Variable animals that the user will give.
    /// Zmienne zwierząt które nada użytkownik.
    /// </summary>
    public static class UserAnimals
    {
        //ANTELOPES | ANTYLOPY
        public static double AAge { get; private set; }
        public static double AMaxAge { get; private set; }
        public static double ASpeedOfGettingOlder { get; private set; }

        public static double ASizeOfAnimal{ get; private set; }
        public static double ASizeOfCorps { get; private set; }
  
        public static double AWaterAreaOfWaterInStomach { get; private set; }
        public static double AWaterCurrentLevelOfWater { get; private set; }
        public static double AWaterRateOfDrinking { get; private set; }
        public static double AWaterRateOfWaterLos { get; private set; }
    
        public static double AFoodSizeOfStomach { get; private set; }
        public static double AFoodCurrentLevelOfFood { get; private set; }
        public static double AFoodRateOfEating { get; private set; }
        public static double AFoodAppetite { get; private set; }

        public static double AFisMaxLvlOfSpeed { get; private set; }
        //LIONS | LWY
        public static double LAge { get; private set; }
        public static double LMaxAge { get; private set; }
        public static double LSpeedOfGettingOlder { get; private set; }

        public static double LSizeOfAnimal { get; private set; }
        public static double LSizeOfCorps { get; private set; }

        public static double LWaterAreaOfWaterInStomach { get; private set; }
        public static double LWaterCurrentLevelOfWater { get; private set; }
        public static double LWaterRateOfDrinking { get; private set; }
        public static double LWaterRateOfWaterLos { get; private set; }

        public static double LFoodSizeOfStomach { get; private set; }
        public static double LFoodCurrentLevelOfFood { get; private set; }
        public static double LFoodRateOfEating { get; private set; }
        public static double LFoodAppetite { get; private set; }

        public static double LFisMaxLvlOfSpeed { get; private set; }
        //TOKOS | TOKO
        public static double TAge { get; private set; }
        public static double TMaxAge { get; private set; }
        public static double TSpeedOfGettingOlder { get; private set; }

        public static double TSizeOfAnimal { get; private set; }
        public static double TSizeOfCorps { get; private set; }

        public static double TFoodSizeOfStomach { get; private set; }
        public static double TFoodCurrentLevelOfFood { get; private set; }
        public static double TFoodRateOfEating { get; private set; }
        public static double TFoodAppetite { get; private set; }

        public static double TFisMaxLvlOfSpeed { get; private set; }
        //HYENAS | HIENY
        public static double HAge { get; private set; }
        public static double HMaxAge { get; private set; }
        public static double HSpeedOfGettingOlder { get; private set; }

        public static double HSizeOfAnimal { get; private set; }
        public static double HSizeOfCorps { get; private set; }

        public static double HWaterAreaOfWaterInStomach { get; private set; }
        public static double HWaterCurrentLevelOfWater { get; private set; }
        public static double HWaterRateOfDrinking { get; private set; }
        public static double HWaterRateOfWaterLos { get; private set; }

        public static double HFoodSizeOfStomach { get; private set; }
        public static double HFoodCurrentLevelOfFood { get; private set; }
        public static double HFoodRateOfEating { get; private set; }
        public static double HFoodAppetite { get; private set; }

        public static double HFisMaxLvlOfSpeed { get; private set; }
        //SNAKES | WĘŻE
        public static double SAge { get; private set; }
        public static double SMaxAge { get; private set; }
        public static double SSpeedOfGettingOlder { get; private set; }
        public static double SSizeOfAnimal { get; private set; }
        public static double SSizeOfCorps { get; private set; }

        public static double SWaterAreaOfWaterInStomach { get; private set; }
        public static double SWaterCurrentLevelOfWater { get; private set; }
        public static double SWaterRateOfDrinking { get; private set; }
        public static double SWaterRateOfWaterLos { get; private set; }

        public static double SFoodSizeOfStomach { get; private set; }
        public static double SFoodCurrentLevelOfFood { get; private set; }
        public static double SFoodRateOfEating { get; private set; }
        public static double SFoodAppetite { get; private set; }

        public static double SToxicTank { get; private set; }
        public static double SToxicCurrentLvl { get; private set; }
        public static double SToxicLvlToBite { get; private set; }
        public static double SToxicRateOfRegeneration { get; private set; }

        public static double SFisMaxLvlOfSpeed { get; private set; }

        public static void Antelope(double age, double maxAge, double speedOfGettingOlder,
            double sizeOfAnimal, double sizeOfCorps, double areaOfWaterInStomach, double currentLevelOfWater, double rateOfDrinking, double rateOfWaterLos,
            double sizeOfStomach, double currentLevelOfFood, double rateOfEating, double appetite, double maxLvlOfSpeed)
        {
            AAge = age;
            AMaxAge = maxAge;
            ASpeedOfGettingOlder = speedOfGettingOlder;
            ASizeOfAnimal = sizeOfAnimal;
            ASizeOfCorps = sizeOfCorps;

            AWaterAreaOfWaterInStomach = areaOfWaterInStomach;
            AWaterCurrentLevelOfWater = currentLevelOfWater;
            AWaterRateOfDrinking = rateOfDrinking;
            AWaterRateOfWaterLos = rateOfWaterLos;

            AFoodSizeOfStomach = sizeOfStomach;
            AWaterCurrentLevelOfWater = currentLevelOfFood;
            AFoodRateOfEating = rateOfEating;
            AFoodAppetite = appetite;
            AFisMaxLvlOfSpeed = maxLvlOfSpeed;
        }

        public static void Lion(double age, double maxAge, double speedOfGettingOlder,
            double sizeOfAnimal, double sizeOfCorps, double areaOfWaterInStomach, double currentLevelOfWater, double rateOfDrinking, double rateOfWaterLos,
            double sizeOfStomach, double currentLevelOfFood, double rateOfEating, double appetite, double maxLvlOfSpeed)
        {
            LAge = age;
            LMaxAge = maxAge;
            LSpeedOfGettingOlder = speedOfGettingOlder;
            LSizeOfAnimal = sizeOfAnimal;
            LSizeOfCorps = sizeOfCorps;

            LWaterAreaOfWaterInStomach = areaOfWaterInStomach;
            LWaterCurrentLevelOfWater = currentLevelOfWater;
            LWaterRateOfDrinking = rateOfDrinking;
            LWaterRateOfWaterLos = rateOfWaterLos;

            LFoodSizeOfStomach = sizeOfStomach;
            LWaterCurrentLevelOfWater = currentLevelOfFood;
            LFoodRateOfEating = rateOfEating;
            LFoodAppetite = appetite;
            LFisMaxLvlOfSpeed = maxLvlOfSpeed;
        }

        public static void Toko(double age, double maxAge, double speedOfGettingOlder, double sizeOfAnimal, 
            double sizeOfCorps, double sizeOfStomach, double currentLevelOfFood, double rateOfEating, double appetite, 
            double maxLvlOfSpeed)
        {
            TAge = age;
            TMaxAge = maxAge;
            TSpeedOfGettingOlder = speedOfGettingOlder;
            TSizeOfAnimal = sizeOfAnimal;
            TSizeOfCorps = sizeOfCorps;

            TFoodSizeOfStomach = sizeOfStomach;
            TFoodRateOfEating = rateOfEating;
            TFoodAppetite = appetite;
            TFisMaxLvlOfSpeed = maxLvlOfSpeed;
        }

        public static void Hyena(double age, double maxAge, double speedOfGettingOlder,
            double sizeOfAnimal, double sizeOfCorps, double areaOfWaterInStomach, double currentLevelOfWater, double rateOfDrinking, double rateOfWaterLos,
            double sizeOfStomach, double currentLevelOfFood, double rateOfEating, double appetite, double maxLvlOfSpeed)
        {
            HAge = age;
            HMaxAge = maxAge;
            HSpeedOfGettingOlder = speedOfGettingOlder;
            HSizeOfAnimal = sizeOfAnimal;
            HSizeOfCorps = sizeOfCorps;

            HWaterAreaOfWaterInStomach = areaOfWaterInStomach;
            HWaterCurrentLevelOfWater = currentLevelOfWater;
            HWaterRateOfDrinking = rateOfDrinking;
            HWaterRateOfWaterLos = rateOfWaterLos;

            HFoodSizeOfStomach = sizeOfStomach;
            HWaterCurrentLevelOfWater = currentLevelOfFood;
            HFoodRateOfEating = rateOfEating;
            HFoodAppetite = appetite;
            HFisMaxLvlOfSpeed = maxLvlOfSpeed;
        }

        public static void Snake(double age, double maxAge, double speedOfGettingOlder,
            double sizeOfAnimal, double sizeOfCorps, double ttank, double tcurrent , double tLvlToBite, double tRateOfRegen,
            double maxLvlOfSpeed)
        {
            SAge = age;
            SMaxAge = maxAge;
            SSpeedOfGettingOlder = speedOfGettingOlder;
            SSizeOfAnimal = sizeOfAnimal;
            SSizeOfCorps = sizeOfCorps;

            SToxicTank = ttank;
            SToxicCurrentLvl = tcurrent;
            SToxicLvlToBite = tLvlToBite;
            SToxicRateOfRegeneration = tRateOfRegen;

            SFisMaxLvlOfSpeed = maxLvlOfSpeed;
        }
    }
}
