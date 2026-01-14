using EM_HW14.Source.Cities;
using System.Collections.Generic;

namespace EM_HW14.Source.LifeInCountry.Buildings.Children
{
    public class Factory : Building, IResourceProducer
    {
        // init
        public Factory(string name) : base(name)
        {

        }

        // funcs
        public override Dictionary<ResourceType, int> Produce()
        {
            return new Dictionary<ResourceType, int>() { { ResourceType.Money, 50 }, { ResourceType.Happiness, -10 } };
        }
    }
}