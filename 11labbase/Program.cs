using System;
using HouseClasses;

public class Program
{
    public static void Main(string[] args)
    {
        House house1 = new House(1, 50, 1980);
        house1.PrintInfo();

        CityHouse house2 = new CityHouse(2, 100, 2000, "Центр");
        house2.PrintInfo();

        CityHouse house3 = new CityHouse(3, 75, 2010, "Окраина");
        house3.PrintInfo();
    }
}
