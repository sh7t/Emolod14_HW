using System;
using EM_HW14.Source.Buildings;
using EM_HW14.Source.Cities;
using EM_HW14.Source.Countries;
using EM_HW14.Source.Utils;

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
                // testing environment
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
