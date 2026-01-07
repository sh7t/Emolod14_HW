using EM_HW14.Source.Buildings;
using EM_HW14.Source.Buildings.Children;
using EM_HW14.Source.Cities;
using EM_HW14.Source.Countries;
using EM_HW14.Source.Utils;
using System;
using System.Collections.Generic;

namespace EM_HW14
{
    public enum ResourceType
    {
        Straw = 0,
        Stick,
        Brick,
        Food,
        Money,
        Taxes,
        Happiness,
    }
    public enum CitySize
    {
        Small = 12,
        Medium = 20,
        Large = 36,
    }
    public enum GovernmentType
    {
        Monarchy = 0,
        Democracy,
        Dictatorship
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Country country = new Country("Kauntri", GovernmentType.Monarchy);

                country.AddCity(new City("Atlanta", CitySize.Small, new List<Building>() { new Theatre("Opera House") }));
                country.AddCity(new City("Philadelphia", CitySize.Medium, new List<Building>() { new Market("ATB") }));
                country.AddCity(new City("New-York", CitySize.Large, new List<Building>(){ new Farm("Diddly Squat Farm"), new Mine("DaMine")}));

                for (int month = 1; month <= 12; month++)
                {
                    country.MonthlyCycle();
                    Console.WriteLine($"Month {month}: Money = {country.money}, Food = {country.GetResourceQuantity(ResourceType.Food)}");
                }
            }
            catch (NullReferenceException)
            {
                ConsoleHelper.ShowError("Null can't be a valid value here!");
            }
            catch (Exception ex)
            {
                ConsoleHelper.ShowError(ex.Message);
            }
        }
    }
}
