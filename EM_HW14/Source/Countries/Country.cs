using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Xml.Schema;
using EM_HW14.Source.Cities;
using EM_HW14.Source.Utils;

namespace EM_HW14.Source.Countries
{
    public abstract class Country
    {
        // fields
        private static int autoInc = 1;
        public readonly int id = 0;
        protected string _name = "";
        protected GovernmentType _governmentType;
        protected Dictionary<ResourceType, int> _resources = new Dictionary<ResourceType, int>();
        protected List<City> _cities = new List<City>();
        protected double _money = 0;


        // init
        public Country(string name, GovernmentType governmentType)
        {
            this.id = autoInc++;
            //
            this.name = name;
            this.governmentType = governmentType;
            //
            InitializeResources();
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
            set { _governmentType = value; }
        }
        public Dictionary<ResourceType, int> resources
        {
            get { return _resources; }
        }
        public List<City> cities
        {
            get { return _cities; }
        }
        public double money
        {
            get { return _money; }
            set
            {
                if (ValidationHelper.IsNegative(value)) { throw new Exception("Happiness value can't be negative."); }
                _money = value;
            }
        }

        // funcs
        public int GetResourceQuantity(ResourceType type)
        {
            return this.resources[type];
        }
        public void AddResource(ResourceType type, int quantity)
        {
            resources[type] = Math.Max(0, resources[type] + quantity);
        }

        private void InitializeResources()
        {
            foreach (ResourceType type in Enum.GetValues(typeof(ResourceType)))
            {
                resources[type] = 0;
            }
        }
        private void MergeResources(Dictionary<ResourceType, int> resources)
        {
            foreach (KeyValuePair<ResourceType, int> resource in resources)
            {
                AddResource(resource.Key, resource.Value);
            }
        }
        public void AddCity(City city)
        {
            if (cities.Contains(city)) { throw new Exception($"City already exists in {this.name}"); }
            
            switch (governmentType)
            {
                case GovernmentType.Monarchy:
                    city.AddResource(ResourceType.Taxes, 10);
                    break;
                case GovernmentType.Democracy:
                    city.AddSize(10);
                    break;
                case GovernmentType.Dictatorship:
                    city.AddResource(ResourceType.Happiness, 20);
                    break;
            }
            cities.Add(city);
        }

        public void CollectResources()
        {
            foreach (City city in cities)
            {
                Dictionary<ResourceType, int> collected = city.ReturnResources();
                MergeResources(collected);
            }
        }
        public void MonthlyCycle()
        {
            foreach (City city in cities)
            {
                city.GrowPopulation();
            }
            CollectResources();
        }

    }
}
