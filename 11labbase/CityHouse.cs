using System;
using HouseClasses;

namespace HouseClasses
{
    public class CityHouse : House
    {
        public string District { get; set; }

        public CityHouse(int houseNumber, int numberOfApartments, int yearOfConstruction, string district) : base(houseNumber, numberOfApartments, yearOfConstruction)
        {
            District = district;
        }

        public override void PrintInfo()
        {
            int currentYear = DateTime.Now.Year;
            double baseQuality = NumberOfApartments + 2 * (currentYear - YearOfConstruction);
            double quality = (District.ToLower() == "центр") ? 2 * baseQuality : baseQuality;
            Console.WriteLine($"Номер дома: {HouseNumber}, Количество квартир: {NumberOfApartments}, Год постройки: {YearOfConstruction}, Район: {District}, Качество: {quality}");
        }
    }
}
