using System;
using System.Collections.Generic;

namespace EM_HW14.Source.Buildings.Children
{
    public class Mine : Building
    {
        // init
        public Mine(string name) : base(name)
        {

        }

        // funcs
        public override Dictionary<ResourceType, int> Produce()
        {
            return new Dictionary<ResourceType, int>() { { ResourceType.Money, 40 }, { ResourceType.Happiness, -10 } };
        }
    }
}