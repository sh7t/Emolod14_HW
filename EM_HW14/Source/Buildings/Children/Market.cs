using EM_HW14.Source.Cities;
using System.Collections.Generic;

namespace EM_HW14.Source.Buildings.Children
{
    public class Market : Building
    {
        // init
        public Market(string name) : base(name)
        {

        }

        // funcs
        public override Dictionary<ResourceType, int> Produce()
        {
            return new Dictionary<ResourceType, int>() { { ResourceType.Money, 20 } };
        }
    }
}