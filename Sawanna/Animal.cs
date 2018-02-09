using System.Collections;
using System.Collections.Generic;
using System.Drawing;

/// <summary>
/// WIELKOŚĆ ZWIERZĄT, 
///     - ptak - 5
///     - wąż - 20
///     - hiena - 30
///     - antylopa - 30 
///     - lew - 40
/// WIELKOŚĆ ŻOŁĄDKÓW
///     - ptak - 2
///     - wąż - 40
///     - hiena - 10
///     - antylopa - 10 
///     - lew - 15
/// </summary>
class Animal 
{
    public Rectangle animalRectangle = new Rectangle(10, 10, 25, 25);
    public Bitmap image;
    //LIFE DATA
    public float AnimalID;
    public float Age;
    public float MaxAge;
    public float SpeedOfGettingOlder;
    //BIO DATA
    public float SizeOfAnimal;
    public float SizeOfCorps;
    //WATER DATA
    public float WaterAreaOfWaterInStomach;
    public float WaterCurrentLevelOfWater;
    public float WaterRateOfDrinking;
    public float WaterRateOfWaterLos;
    //FOOD DATA
    public float FoodSizeOfStomach;
    public float FoodCurrentLevelOfFood;
    public float FoodRateOfEating;
    public float FoodAppetite;
    public string FoodTypeOfFood; //padlina, rośliny, antylopy, węże
    //TOX DATA
    public float ToxCurrentLvlOfPoison;
    public float ToxPoisonTank;
    public float ToxRateOfPoisonRegeneration;
    public float ToxLevelOfPosionToBite;
    //FIZ DATA
    public float FisCurrentHigh;
    public float FisMaxLvlOfAltitude;
    public float FisCurrentSpeed;
    public float FisMaxLvlOfSpeed;

    //public int FisX;
    //public int FisY;

    protected Animal()
        : this( 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "",  0, 0, 0, 0, 0, 0, 0, 0)
    { }

    /// <summary>
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
    protected Animal(float animalID, float age, float maxAge, float speedOfGettingOlder, 
        float sizeOfAnimal, float sizeOfCorps, float waterAreaOfWaterInStomach, float waterCurrentLevelOfWater, float waterRateOfDrinking, float waterRateOfWaterLos,
        float foodSizeOfStomach, float foodCurrentLevelOfFood, float foodRateOfEating, float foodAppetite, string foodTypeOfFood,
        float toxCurrentLvlOfPoison,  float toxPoisonTank, float toxRateOFPosionRegeneration, float toxLevelOfPosionToBite,
        float fisCurrentHigh, float fisMaxLvlOfAltutude, float fisCurrentSpeed, float fisMaxLvlOfSpeed
        )
    {
        SetPersonalities(animalID, age, maxAge, speedOfGettingOlder);
        SetBioData(sizeOfAnimal, sizeOfCorps, waterAreaOfWaterInStomach, waterCurrentLevelOfWater, waterRateOfDrinking, waterRateOfWaterLos,
            foodSizeOfStomach, foodCurrentLevelOfFood, foodRateOfEating, foodAppetite, foodTypeOfFood,
            toxCurrentLvlOfPoison, toxPoisonTank, toxRateOFPosionRegeneration, toxLevelOfPosionToBite);
        FisData( fisCurrentHigh, fisMaxLvlOfAltutude, fisCurrentSpeed, fisMaxLvlOfSpeed);
    }

    /// <summary>
    /// Ustawia atrybuty ustalające numer zwierzęcia, wiek, max wiek, szybkość starzenia i szybkość narodzin.
    /// </summary>
    /// <param name="animalID">Numer identyfikacyjny zwierzęcia, każdy inny.</param>
    /// <param name="age">Aktualny wiek zwierzęcia.</param>
    /// <param name="maxAge">Maksymalny wiek zwierzęcia.</param>
    /// <param name="speedOfGettingOlder">Szybkość stażenia się.</param>
    public virtual void SetPersonalities(float animalID, float age, float maxAge, float speedOfGettingOlder)
    {
        this.AnimalID = animalID;
        this.Age = age;
        this.MaxAge = maxAge;
        this.SpeedOfGettingOlder = speedOfGettingOlder;
    }

    /// <summary>
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
    public virtual void SetBioData(float sizeOfAnimal, float sizeOfCorps, float waterAreaOfWaterInStomach, float waterCurrentLevelOfWater, float waterRateOfDrinking, float waterRateOfWaterLos,
        float foodSizeOfStomach, float foodCurrentLevelOfFood, float foodRateOfEating, float foodAppetite, string foodTypeOfFood,
        float toxCurrentLvlOfPoison, float toxPoisonTank, float toxRateOFPosionRegeneration, float toxLevelOfPosionToBite)
    {
        this.SizeOfAnimal = sizeOfAnimal;
        this.SizeOfCorps = sizeOfCorps;
        SetWaterAtributes(waterAreaOfWaterInStomach, waterCurrentLevelOfWater, waterRateOfDrinking, waterRateOfWaterLos);
        SetFoodAtributes(foodSizeOfStomach, foodCurrentLevelOfFood, foodRateOfEating, foodAppetite, foodTypeOfFood);
        SetPoisonAtribute(toxCurrentLvlOfPoison, toxPoisonTank, toxRateOFPosionRegeneration, toxLevelOfPosionToBite);
    }

    /// <summary>
    /// Ustawienia atrybutów związanych z wodą/nawodnieniem. Przedrostek Water dla ułatwienia wyszukiwania.
    /// </summary>
    /// <param name="waterAreaOfWaterInStomach">Miejsce przeznaczone dla wody w żołądku.</param>
    /// <param name="waterCurrentLevelOfWater">Aktualny poziom wody w żołądku.</param>
    /// <param name="waterRateOfDrinking">Szybkość picia wody.</param>
    /// <param name="waterRateOfWaterLos">Szybkość utraty wody z żołądka.</param>
    public virtual void SetWaterAtributes(float waterAreaOfWaterInStomach, float watercurRentLevelOfWater, float waterRateOfDrinking, float waterRateOfWaterLos)
    {
        this.WaterAreaOfWaterInStomach = waterAreaOfWaterInStomach;
        this.WaterCurrentLevelOfWater = watercurRentLevelOfWater;
        this.WaterRateOfDrinking = waterRateOfDrinking;
        this.WaterRateOfWaterLos = waterRateOfWaterLos;
    }

    /// <summary>
    /// Ustawienie atrybutów jedzenia. Przedrostek Food dla ułatwienia wyszukiwania.
    /// </summary>
    /// <param name="foodSizeOfStomach">Rozmiar żołądka. </param>
    /// <param name="foodCurrentLevelOfFood">Aktualny poziom jedzenia w żołądku.</param>
    /// <param name="foodRateOfEating">Szybkość pochłaniania jedzenia.</param>
    /// <param name="foodAppetite">Apetyt. Szybkość zmniejszania się pokarmu w żoładku.</param>
    /// <param name="foodTypeOfFood">Typ jedzenia.</param>
    public virtual void SetFoodAtributes(float foodSizeOfStomach, float foodCurrentLevelOfFood, float foodRateOfEating, float foodAppetite, string foodTypeOfFood)
    {
        this.FoodSizeOfStomach = foodSizeOfStomach;
        this.FoodCurrentLevelOfFood = foodCurrentLevelOfFood;
        this.FoodRateOfEating = foodRateOfEating;
        this.FoodAppetite = foodAppetite;
        this.FoodTypeOfFood = foodTypeOfFood;
    }

    /// <summary>
    /// Ustawienia atrybutów trucizny. Przedrostek Tox dla ułatwienia wyszukiwania.
    /// </summary>
    /// <param name="toxCurrentLvlOfPoison">Aktulny poziom jadu.</param>
    /// <param name="toxPoisonTank">Ilość jadu którą możne wyprodukować.</param>
    /// <param name="toxRateOFPosionRegeneration">Tempo produkowania jadu.</param>
    /// <param name="toxLevelOfPosionToBite">Poziom jadu wymagany na jedno ugryzienie.</param>
    public virtual void SetPoisonAtribute(float toxCurrentLvlOfPoison, float toxPoisonTank, float toxRateOFPosionRegeneration, float toxLevelOfPosionToBite)
    {
        this.ToxCurrentLvlOfPoison = toxCurrentLvlOfPoison;
        this.ToxPoisonTank = toxPoisonTank;
        this.ToxRateOfPoisonRegeneration = toxRateOFPosionRegeneration;
        this.ToxLevelOfPosionToBite = toxLevelOfPosionToBite;
    }

    /// <summary>
    /// Ustawia atrybuty fizyczne. Przedrostek Fis dla ułatwienia wyszukiwania.
    /// </summary>
    /// <param name="fisCurrentHigh">Aktualna wysokość.</param>
    /// <param name="fisMaxLvlOfAltutude">Maksymalny poziom wysokośći.</param>
    /// <param name="fisCurrentSpeed">Aktualna prędkość.</param>
    /// <param name="fisMaxLvlOfSpeed">Maksymalna szybkość poruszania się.</param>
    /// <param name="fisX">Położenie względem osi x.</param>
    /// <param name="fisY">Położenie względem osi y.</param>
    public virtual void FisData(float fisCurrentHigh,  float fisMaxLvlOfAltutude, float fisCurrentSpeed, float fisMaxLvlOfSpeed)
    {
        this.FisCurrentHigh = fisCurrentHigh;
        this.FisMaxLvlOfAltitude = fisMaxLvlOfAltutude;
        this.FisCurrentSpeed = fisCurrentSpeed;
        this.FisMaxLvlOfSpeed = fisMaxLvlOfSpeed;
    }
}
