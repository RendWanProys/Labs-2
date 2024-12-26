using System;

namespace HouseClasses
{
    public class House
    {
        public int HouseNumber { get; set; }
        public int NumberOfApartments { get; set; }
        public int YearOfConstruction { get; set; }

        public House(int houseNumber, int numberOfApartments, int yearOfConstruction)
        {
            HouseNumber = houseNumber;
            NumberOfApartments = numberOfApartments;
            YearOfConstruction = yearOfConstruction;
        }

        public virtual void PrintInfo()
        {
            int currentYear = DateTime.Now.Year;
            double quality = NumberOfApartments + 2 * (currentYear - YearOfConstruction);
            Console.WriteLine($"Номер дома: {HouseNumber}, Количество квартир: {NumberOfApartments}, Год постройки: {YearOfConstruction}, Качество: {quality}");
        }
    }
}
