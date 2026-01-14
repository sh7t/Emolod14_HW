using EM_HW14.Source.LifeInCountry.Buildings;
using EM_HW14.Source.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using EM_HW14.Source.Services;

namespace EM_HW14.Source.Cities
{
    public enum ResourceType
    {
        Food = 1,
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
    public class City
    {
        // fields
        private static int autoInc = 1;
        public readonly int id = 0;
        protected ResourceManager resourceManager;
        protected string _name = "";
        protected int _buildingSlots = 0;
        protected CitySize _citySize;
        protected List<Building> _buildings;
        protected int _population = 100000;
        protected int _populationGrowth = 0;

        protected const int MONEY_INCOME = 10;
        protected const int HAPPINESS_EXPENDITURE = -10;

        // init
        public City(string name, CitySize size, List<Building> buildings = null)
        {
            this.id = autoInc++;
            //
            this.name = name.Trim();
            _citySize = size;
            buildingSlots = (int)size;
            _buildings = buildings ?? new List<Building>();
            //
            resourceManager = new ResourceManager();
        }

        // getset
        public string name
        {
            get { return _name; }
            set
            {
                if (value.Trim().Length < 3) { throw new Exception("City name has to be at least 3 characters."); }
                _name = value.Trim();
            }
        }
        public int buildingSlots
        {
            get { return this._buildingSlots; }
            protected set
            {
                if (!Enum.IsDefined(typeof(CitySize), value)) { throw new Exception("Undefined city size."); }
                this._buildingSlots = value;
            }
        }
        public List<Building> buildings
        {
            get { return _buildings; }
        }
        public int population
        {
            get { return this._population; }
            protected set
            {
                if (ValidationHelper.IsNegative(value)) { throw new Exception("Population value can't be negative."); }
                this._population = value;
            }
        }
        public int populationGrowth
        {
            get { return this._populationGrowth; }
            protected set
            {
                if (ValidationHelper.IsNegative(value)) { throw new Exception("Population growth value can't be negative."); }
                this._populationGrowth = value;
            }
        }
        public int buildingCount
        {
            get { return this.buildings.Count; }
        }

        // funcs
        public void AddSize(int size)
        {
            if (ValidationHelper.IsNonPositive(size)) { throw new Exception("Added size must be greater than zero."); }
            this._buildingSlots += size;
        }
        public void AddResource(ResourceType type, int quantity)
        {
            resourceManager.AddResource(type, quantity);
        }
        public void ProduceResources()
        {
            foreach (Building building in buildings) { resourceManager.MergeResources(building.Produce()); }
        }
        public void Build(Building building)
        {
            if (this.buildings.Any(bldng => bldng.id == building.id)) { throw new Exception("Building is already exist."); }
            if (this.buildingCount >= this.buildingSlots) { throw new Exception("Not enough space for building."); }
            this.buildings.Add(building);
        }
        public bool ConsumeFood(ResourceManager resourceManager)
        {
            int required = Math.Max(1, population / 1000);

            if (required > resourceManager.GetResourceQuantity(ResourceType.Food))
            {
                this.resourceManager.AddResource(ResourceType.Happiness, HAPPINESS_EXPENDITURE);
                return false;
            }
            resourceManager.AddResource(ResourceType.Food, -required);
            this.resourceManager.AddResource(ResourceType.Money, MONEY_INCOME * required);
            return true;
        }
        public void GrowPopulation(ResourceManager resourceManager)
        {
            if (ConsumeFood(resourceManager) && ValidationHelper.IsPositive(this.resourceManager.happiness))
            {
                population += (population * this.resourceManager.happiness / 100) / 10;
            }
        }
        public void CollectTaxes()
        {
            if (ValidationHelper.IsPositive(resourceManager.happiness))
            {
                resourceManager.AddResource(ResourceType.Money, (population / 1000) * 10 * resourceManager.tax / 100);
            }
            return;
        }

        public Dictionary<ResourceType, int> ReturnResources()
        {
            ProduceResources();
            CollectTaxes();

            Dictionary<ResourceType, int> returnable = new Dictionary<ResourceType, int>();
            List<ResourceType> retunableTypes = new List<ResourceType>() {
                ResourceType.Food,
                ResourceType.Money
            };

            foreach (ResourceType retunableType in retunableTypes)
            {
                returnable[retunableType] = resourceManager.resources[retunableType];
                resourceManager.AddResource(retunableType, -resourceManager.resources[retunableType]);
            }

            return returnable;
        }
    }
}
