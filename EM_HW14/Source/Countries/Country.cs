using System;
using System.Collections.Generic;
using System.Linq;
using EM_HW14.Source.Cities;
using EM_HW14.Source.Services;
using EM_HW14.Source.Utils;

namespace EM_HW14.Source.Countries
{
    public enum GovernmentType
    {
        Monarchy = 1,
        Democracy,
        Dictatorship
    }
    public class Country
    {
        // fields
        private static int autoInc = 1;
        public readonly int id = 0;
        protected ResourceManager resourceManager;
        protected string _name = "";
        protected GovernmentType _governmentType;
        protected List<City> _cities = new List<City>();

        protected const int MONARCHY_BONUS = 10;
        protected const int DEMOCRACY_BONUS = 10;
        protected const int DICTATORSHIP_BONUS = 20;


        // init
        public Country(string name, GovernmentType governmentType)
        {
            this.id = autoInc++;
            //
            this.name = name;
            this.governmentType = governmentType;
            //
            resourceManager = new ResourceManager();
        }

        // getset
        public string name
        {
            get { return _name; }
            set
            {
                if (value.Trim().Length < 3) { throw new Exception("Country name has to be at least 3 characters."); }
                _name = value.Trim();
            }
        }
        public GovernmentType governmentType
        {
            get { return _governmentType; }
            protected set { _governmentType = value; }
        }
        public List<City> cities
        {
            get { return _cities; }
        }
        public double money
        {
            get { return GetResourceQuantity(ResourceType.Money); }
        }

        // funcs
        public int GetResourceQuantity(ResourceType type)
        {
            return resourceManager.GetResourceQuantity(type);
        }
        public void AddCity(City city)
        {
            if (cities.Any(c => c.id == city.id)) { throw new Exception($"City already exists in {name}"); }
            ApplyGovernmentEffects(governmentType, 1);
            cities.Add(city);
        }

        public void ChangeGovernmentType(GovernmentType governmentType)
        {
            if (this.governmentType == governmentType) { throw new Exception($"Country {name} is already {this.governmentType.ToString()}"); }

            ApplyGovernmentEffects(this.governmentType, -1);
            ApplyGovernmentEffects(governmentType, 1);
            
            this.governmentType = governmentType;
        }

        private void ApplyGovernmentEffects(GovernmentType governmentType, int multiplier)
        {
            foreach (City city in cities)
            {
                switch (governmentType)
                {
                    case GovernmentType.Monarchy:
                        city.AddResource(ResourceType.Taxes,MONARCHY_BONUS * multiplier);
                        break;

                    case GovernmentType.Democracy:
                        city.AddSize(DEMOCRACY_BONUS * multiplier);
                        break;

                    case GovernmentType.Dictatorship:
                        city.AddResource(ResourceType.Happiness,DICTATORSHIP_BONUS * multiplier);
                        break;
                }
            }
        }
        public void CollectResources()
        {
            foreach (City city in cities)
            {
                resourceManager.MergeResources(city.ReturnResources());
            }
        }
        public void MonthlyCycle()
        {
            foreach (City city in cities)
            {
                city.GrowPopulation(resourceManager);
            }
            CollectResources();
        }

    }
}
