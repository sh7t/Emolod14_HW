using EM_HW14.Source.Cities;
using System.Collections.Generic;

namespace EM_HW14.Source.Buildings.Children
{
    public class Farm : Building
    {
        // init
        public Farm(string name) : base(name)
        {

        }

        // funcs
        public override Dictionary<ResourceType, int> Produce()
        {
            return new Dictionary<ResourceType, int>() { {ResourceType.Food, 50 } };
        }
    }
}
