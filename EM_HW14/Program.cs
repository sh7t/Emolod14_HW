using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace EM_HW14
{
    public enum FuelType
    {
        A95 = 0,
        A100,
        Gas,
        Diesel
    }
    // // // // // // // // //
    public static class ConsoleHelper
    {
        public static readonly string currency = "$";
        // funcs
        public static void ChangeEncodingToUTF8()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
        }
        public static string StringInput(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine().Trim();
        }
        public static string StringInput(string message, string errorMessage)
        {
            string str = StringInput(message);
            if (str.Trim().Length == 0) { throw new Exception(errorMessage); }
            return str;
        }
        public static int IntegerInput(string message)
        {
            return Convert.ToInt32(StringInput(message));
        }
        public static int IntegerLineInput(string message)
        {
            Console.Write(message);
            return Convert.ToInt32(Console.ReadLine());
        }
        public static void ShowError(string message)
        {
            Console.WriteLine("Error: " + message);
        }
        public static void ShowSeparator()
        {
            Console.WriteLine("-=============================-");
        }
    }
    public static class ValidationHelper
    {
        // funcs
        public static bool IsPositive(int value) { return value > 0; }
        public static bool IsNegative(int value) { return value < 0; }
        public static bool IsNonPositive(int value) { return value <= 0; }
        public static bool IsNonNegative(int value) { return value >= 0; }
        public static void CheckForNull<T>(T value)
        {
            if (value == null) { throw new NullReferenceException("Null can't be a value here."); }
        }
    }
    public static class CustomRandom
    {
        // fields
        private static Random random = new Random();

        // funcs
        public static int Next(int min, int max)
        {
            return random.Next(min, max);
        }
        public static int Next(int max)
        {
            return random.Next(max);
        }
    }

    public static class CarGenerator
    {
        private static string GenerateLicensePlate()
        {
            const string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            // kludge
            return $"{letters[CustomRandom.Next(letters.Length)]}" + $"{letters[CustomRandom.Next(letters.Length)]}" +
                $"{CustomRandom.Next(10)}" + $"{CustomRandom.Next(10)}" + $"{CustomRandom.Next(10)}" + $"{CustomRandom.Next(10)}" +
                $"{letters[CustomRandom.Next(letters.Length)]}" + $"{letters[CustomRandom.Next(letters.Length)]}";
        }
        private static string GenerateCarName()
        {
            List<string> carNames = new List<string>()
            {
                "Model X", "M5 F90", "Civic Type R", "Corolla GR", "Octavia RS", "Mustang GT", "Charger SRT", "Camry TRD", "Aventador SVJ", "Huracan EVO",
                "911 Carrera", "Panamera GTS", "F-150 Raptor", "Ranger Raptor", "G63 AMG", "GLE 63 S", "Taycan Turbo", "i8 Roadster", "Supra A90",
                "Stelvio Quadrifoglio", "Giulia Veloce", "Bronco Wildtrak", "Tucson N-Line", "Elantra N", "Veloster N", "Cayenne Turbo", "Macan GTS",
                "X5 M", "X6 M", "M4 Competition", "M2 CS", "RS6 Avant", "RS7 Sportback", "S63 AMG", "E63 S", "Mustang Mach 1", "Camaro SS",
                "Challenger R/T", "Wrangler Rubicon", "Defender 110", "G-Class 63", "A4 Avant", "A6 Allroad", "Q8", "Touareg R",
                "XC90 T8", "Polestar 2", "Model 3 Performance", "Roadster 2023"
            };

            return carNames[CustomRandom.Next(carNames.Count)];
        }
        private static int GenerateTankCapacity(int minTankCapacity = 35, int maxTankCapacity = 86)
        {
            return CustomRandom.Next(minTankCapacity, maxTankCapacity);
        }
        private static int GenerateTankFullness(int tankCapacity, int minTankFullnessPercentage = 3, int maxTankFullnessPercentage = 100)
        {
            return (int)(tankCapacity * (CustomRandom.Next(minTankFullnessPercentage, maxTankFullnessPercentage) / 100.0));
        }
        private static Fuel GenerateFuel()
        {
            List<string> fuelNames = new List<string>()
            {
                "Ignite", "Pulse", "Velocity", "Overdrive", "Momentum", "Kinetic", "Afterburn", "Throttle", "Boost", "PowerFlow", "PrimeFuel",
                "UltraFuel", "Elite", "Supreme", "Apex", "Vertex", "Summit", "Infinity", "Noble", "NeoFuel", "HyperFuel", "Quantum", "Flux", "Ion",
                "Plasma", "Core", "Fusion", "PulseX", "Rapid", "Storm", "Blaze", "Ignition", "Rush", "VelocityX", "Fireline", "Redline", "Fastlane",
                "EcoFlow", "GreenCore", "PureDrive", "CleanMotion", "Balance", "BlueFuel", "Phoenix", "Titan", "Vortex", "Eclipse", "Nova", "Zenith",
            };

            return new Fuel(fuelNames[CustomRandom.Next(fuelNames.Count)],
                (FuelType)CustomRandom.Next(0, Enum.GetValues(typeof(FuelType)).Length),
                CustomRandom.Next(45, 52),
                CustomRandom.Next(50, 60));
        }

        public static Car GenerateCar()
        {
            string licensePlate = GenerateLicensePlate();
            string name = GenerateCarName();
            int tankCapacity = GenerateTankCapacity();
            int tankFullness = GenerateTankFullness(tankCapacity);
            Fuel fuelType = GenerateFuel();

            return new Car(licensePlate, name, tankCapacity, tankFullness, fuelType);
        }
        public static Car[] GenerateCars(int lengthOfCarsArray)
        {
            Car[] cars = new Car[lengthOfCarsArray];
            for (int i = 0; i < lengthOfCarsArray; i++)
            {
                cars[i] = GenerateCar();
            }
            return cars;
        }
    }
    public class Fuel
    {
        // fields
        private static int autoInc = 1;
        public readonly int id = 0;
        private string _name = "";
        private FuelType _fuelType;
        private int _b2b = 0;
        private int _b2c = 0;

        // init
        public Fuel(string name, FuelType fuelType, int b2b, int b2c)
        {
            this.id = autoInc++;

            this.name = name;
            this.fuelType = fuelType;
            this.b2b = b2b;
            this.b2c = b2c;
        }

        // getset
        public string name
        {
            get { return _name; }
            set
            {
                if (value.Trim().Length < 2) { throw new Exception("Fuel name has to be at least 2 characters!"); }
                _name = value.Trim();
            }
        }

        public FuelType fuelType
        {
            get { return _fuelType; }
            private set { _fuelType = value; }
        }

        public int b2b
        {
            get { return _b2b; }
            set
            {
                if (ValidationHelper.IsPositive(value)) { _b2b = value; }
                else { throw new Exception("Business price has to be a positive value."); }
            }
        }

        public int b2c
        {
            get { return _b2c; }
            set
            {
                if (ValidationHelper.IsPositive(value)) { _b2c = value; }
                else { throw new Exception("Customer price has to be a positive value."); }
            }
        }

    }
    public class GasStation
    {
        // fields
        private static int autoInc = 1;
        private static readonly int maximumFuelStorage = 20000;
        public readonly int id = 0;
        private string _name = "";
        private Dictionary<Fuel, int> _availableFuel = new Dictionary<Fuel, int>();
        private int _balance = 100000;

        private List<Log> _logs = new List<Log>(); // TODO

        // init
        public GasStation(string name, Dictionary<Fuel, int> availableFuel)
        {
            this.id = autoInc++;

            this.name = name;
            this.availableFuel = availableFuel;
        }

        // getset
        public string name
        {
            get { return _name; }
            set
            {
                if (value.Trim().Length < 2) { throw new Exception("Gas station name has to be at least 2 characters!"); }
                _name = value.Trim();
            }
        }
        public Dictionary<Fuel, int> availableFuel
        {
            get { return _availableFuel; }
            set { _availableFuel = value; }
        }
        public int balance
        {
            get { return _balance; }
            private set { _balance = value; }
        }

        // funcs
        public void Expense(int expense)
        {
            if (ValidationHelper.IsNonPositive(expense)) { throw new Exception("Invalid value of expenses. Expense has to be positive."); }
            if (balance < expense) { throw new Exception("Not enough balance to do expense!"); }

            balance -= expense;
        }
        public void ReplenishStocks(int id)
        {
            Fuel fuelById = null;
            foreach (Fuel fuel in availableFuel.Keys)
            {
                if (fuel.id == id) { fuelById = fuel; break; }
            }

            Expense((maximumFuelStorage - availableFuel[fuelById]) * fuelById.b2b);
            availableFuel[fuelById] = maximumFuelStorage;
        }
        public void ShowAvailableFuel()
        {
            if (availableFuel.Count == 0) { throw new Exception("There's no available fuel. Come back later!"); }

            Console.WriteLine("ID |   Fuel information");
            foreach (KeyValuePair<Fuel, int> fuel in availableFuel)
            {
                Console.WriteLine($"{fuel.Key.id} | {fuel.Key.name}({fuel.Key.fuelType}), {fuel.Key.b2c}{ConsoleHelper.currency} per liter." +
                    $" Liters available: {fuel.Value}l.");
            }
        }
        public void RefuelCar(Car car, int liters)
        {
            if (ValidationHelper.IsNonPositive(liters)) { throw new Exception("Invalid liters value. Has to be a positive number."); }

            Fuel fuelInStation = null;
            foreach (Fuel fuel in availableFuel.Keys)
            {
                if (fuel.fuelType == car.fuelType.fuelType) { fuelInStation = fuel; break; }
            }

            if (fuelInStation == null) { throw new Exception("Fuel type hasn't found in station."); }
            if (availableFuel[fuelInStation] < liters) { throw new Exception("Not enough fuel in stock, come back later."); }
            if (liters > car.tankCapacity - car.tankFullness) { throw new Exception("Liters exceed free space in tank."); }

            car.tankFullness += liters;
            availableFuel[fuelInStation] -= liters;
            balance += liters * fuelInStation.b2c;
            _logs.Add(new Log(car.fuelType, liters, car.licensePlate));
        }
        private void CheckLogs()
        {
            if (_logs.Count == 0) { throw new Exception("Logs are empty for now, check later."); }
            Console.WriteLine("ID  |  Date  | Information ");
            foreach (Log log in _logs)
            {
                log.ShowLogInfo();
            }
        }
        public void AuthorizationForLogs(string userLogin, string userPassword)
        {
            const string login = "admin";
            const string password = "admin";

            if (userLogin != login || userPassword != password) { throw new Exception("Incorrect login information."); }
            CheckLogs();
        }

        class Log
        {
            // fields
            private static int autoInc = 1;
            public readonly int id = 0;
            private Fuel _fuelType = null;
            private int _pouredLiters = 0;
            private string _licensePlate = "";
            private DateTime _pouredAt = DateTime.Now;

            // init
            public Log(Fuel fuelType, int pouredLiters, string licensePlate)
            {
                id = autoInc++;

                this.fuelType = fuelType;
                this.pouredLiters = pouredLiters;
                this.licensePlate = licensePlate;
            }

            // getset
            public Fuel fuelType
            {
                get { return _fuelType; }
                private set { _fuelType = value; }
            }
            public int pouredLiters
            {
                get { return _pouredLiters; }
                private set
                {
                    if (ValidationHelper.IsNonPositive(value)) { throw new Exception("Poured liters value has to be a positive number."); }
                    _pouredLiters = value;
                }
            }
            public string licensePlate
            {
                get { return _licensePlate; }
                private set
                {
                    if (value.Trim().Length != 8) { throw new Exception("Invalid license plate!"); }
                    if (Regex.IsMatch(value.Trim(), @"^[A-Z]{2}\d{4}[A-Z]{2}$"))
                    {
                        _licensePlate = value.Trim();
                    }
                }
            }
            public DateTime pouredAt
            {
                get { return _pouredAt; }
            }

            // funcs

            public void ShowLogInfo()
            {
                ValidationHelper.CheckForNull(fuelType);
                ValidationHelper.CheckForNull(licensePlate);

                Console.WriteLine($"{id} | {pouredAt.ToString("g")} | {licensePlate} poured {pouredLiters} liters of {fuelType.name}({fuelType.fuelType}).");
            }
        }
    }
    public class Car
    {
        // fields
        private static int autoInc = 1;
        public readonly int id = 0;
        private string _licensePlate = "";
        private string _name = "";
        private int _tankCapacity = 0;
        private int _tankFullness = 0;
        private Fuel _fuelType = null;

        public Car(string licensePlate, string name, int tankCapacity, int tankFullness, Fuel fuelType)
        {
            this.id = autoInc++;

            this.licensePlate = licensePlate;
            this.name = name;
            this.tankCapacity = tankCapacity;
            this.tankFullness = tankFullness;
            this.fuelType = fuelType;
        }

        public string licensePlate
        {
            get { return _licensePlate; }
            set
            {
                if (value.Trim().Length != 8) { throw new Exception("Invalid license plate!"); }
                if (Regex.IsMatch(value.Trim(), @"^[A-Z]{2}\d{4}[A-Z]{2}$"))
                {
                    _licensePlate = value.Trim();
                }
            }
        }
        public string name
        {
            get { return _name; }
            set
            {
                if (value.Trim().Length < 2) { throw new Exception("Car name has to be at least 2 characters!"); }
                _name = value.Trim();
            }
        }
        public int tankCapacity
        {
            get { return _tankCapacity; }
            set
            {
                if (ValidationHelper.IsNonPositive(value)) { throw new Exception("Tank capacity has to be positive."); }
                _tankCapacity = value;
            }
        }
        public int tankFullness
        {
            get { return _tankFullness; }
            set
            {
                if (ValidationHelper.IsNonPositive(value)) { throw new Exception("Current tank fullness has to be positive."); }
                _tankFullness = value;
            }
        }
        public Fuel fuelType
        {
            get { return _fuelType; }
            set
            {
                _fuelType = value;
            }
        }
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
