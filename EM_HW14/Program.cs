using EM_HW14.Source.LifeInCountry.Buildings;
using EM_HW14.Source.LifeInCountry.Buildings.Children;
using EM_HW14.Source.Cities;
using EM_HW14.Source.Countries;
using EM_HW14.Source.Utils;
using System;
using System.Collections.Generic;
using EM_HW14.Source.IDevices.Devices;

namespace EM_HW14
{
    
    

    internal class Program
    {
        public interface IConnectableDevice
        {
            void Connect();
            void Disconnect();
        }

        public static void TestConnection(IConnectableDevice device)
        {
            Console.WriteLine("TEST");
            device.Connect();
            device.Disconnect();
            Console.WriteLine("ENDTEST");
        }
        
        static void Main(string[] args)
        {
            try
            {
                // 1.
                List<IConnectableDevice> devices = new List<IConnectableDevice >()
                {
                    new Smartphone(),
                    new BluetoothSpeaker(),
                    new USBStorageDevice()
                };
                foreach (IConnectableDevice device in devices)
                {
                    TestConnection(device);
                }
                
                // 2.
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
