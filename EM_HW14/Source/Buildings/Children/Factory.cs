using System;
using System.Collections.Generic;

namespace EM_HW14.Source.Buildings.Children
{
    public class Factory : Building
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