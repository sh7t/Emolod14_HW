using EM_HW14.Source.Buildings;
using EM_HW14.Source.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EM_HW14.Source.Cities
{
    
    public class City
    {
        // fields
        private static int autoInc = 1;
        public readonly int id = 0;
        protected Dictionary<ResourceType, int> resources = new Dictionary<ResourceType, int>();
        private string _name = "";
        private int _size = 0;
        private List<Building> _buildings = new List<Building>();
        private int _population = 10;
        private int _populationGrowth = 0;

        // init
        public City(string name, CitySize size)
        {
            this.id = autoInc++;
            //
            this.name = name.Trim();
            this.size = (int)size;
            //
            this.InitializeResources();
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
        public int size
        {
            get { return this._size; }
            protected set
            {
                if (!Enum.IsDefined(typeof(CitySize), value)) { throw new Exception("Undefined city size."); }
                this._size = value;
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
        public int happiness
        {
            get { return GetResourceQuantity(ResourceType.Happiness); }
        }
        public int food
        {
            get { return GetResourceQuantity(ResourceType.Food); }
        }
        public int tax
        {
            get { return GetResourceQuantity(ResourceType.Taxes); }
        }

        // funcs
        public void AddSize(int size)
        {
            if (ValidationHelper.IsNonPositive(size)) { throw new Exception("Added size must be greater than zero."); }
            this.size += size;
        }
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
        public void ProduceResources()
        {
            foreach (Building building in buildings) { MergeResources(building.Produce()); }
        }
        public void Build(Building building)
        {
            if (this.buildings.Any(bldng => bldng.id == building.id)) { throw new Exception("Building is already exist."); }
            if (this.buildingCount >= this.size) { throw new Exception("Not enough space for building."); }
            this.buildings.Add(building);
        }
        public bool ConsumeFood()
        {
            const int MONEY_INCOME = 10;
            const int HAPPINESS_EXPENDITURE = -10;

            int required = Math.Max(1, population / 1000);

            if (required > GetResourceQuantity(ResourceType.Food))
            {
                AddResource(ResourceType.Happiness, HAPPINESS_EXPENDITURE);
                return false;
            }
            AddResource(ResourceType.Food, -required);
            AddResource(ResourceType.Money, MONEY_INCOME * required);
            return true;
        }
        public void GrowPopulation()
        {
            if (ConsumeFood() && ValidationHelper.IsPositive(happiness))
            {
                population += (population * happiness / 100) / 10;
            }
        }
        public void CollectTaxes()
        {
            if (ValidationHelper.IsPositive(happiness))
            {
                AddResource(ResourceType.Money, (population / 1000) * 10 * tax / 100);
            }
            return;
        }

        public Dictionary<ResourceType, int> ReturnResources()
        {
            ProduceResources();
            CollectTaxes();

            Dictionary<ResourceType, int> returnable = new Dictionary<ResourceType, int>();
            List<ResourceType> retunableTypes = new List<ResourceType>() {
                ResourceType.Straw,
                ResourceType.Stick,
                ResourceType.Brick,
                ResourceType.Food,
                ResourceType.Money
            };

            foreach (ResourceType retunableType in retunableTypes)
            {
                returnable[retunableType] = resources[retunableType];
                AddResource(retunableType, -resources[retunableType]);
            }

            return returnable;
        }
    }
}
