using EM_HW14.Source.Cities;
using EM_HW14.Source.Utils;
using System;
using System.Collections.Generic;

namespace EM_HW14.Source.LifeInCountry.Buildings
{
    public interface IResourceProducer
    {
        Dictionary<ResourceType, int> Produce();
    }

    public abstract class Building : IResourceProducer
    {
        // fields
        private static int autoInc = 1;
        public readonly int id = 0;
        protected string _name = "";
        protected double _price = 0;

        // init
        public Building(string name)
        {
            this.id = autoInc++;
            //
            this.name = name;
        }

        // getset
        public string name
        {
            get { return this._name; }
            set
            {
                if (value.Trim().Length < 3) { throw new Exception("Building name has to be at least 3 characters."); }
                this._name = value.Trim();
            }
        }
        public double price
        {
            get { return this._price; }
            set
            {
                if (ValidationHelper.IsNegative(value)) { throw new Exception("Building price can't be negative."); }
                this._price = value;
            }
        }

        // funcs
        public abstract Dictionary<ResourceType, int> Produce();
    }
}
