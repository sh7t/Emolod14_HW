using EM_HW14.Source.Cities;
using System.Collections.Generic;

namespace EM_HW14.Source.LifeInCountry.Buildings.Children
{
    public class Museum : Building, IResourceProducer
    {
        // init
        public Museum(string name) : base(name)
        {

        }

        // funcs
        public override Dictionary<ResourceType, int> Produce()
        {
            return new Dictionary<ResourceType, int>() { { ResourceType.Happiness, 40 } };
        }
    }
}